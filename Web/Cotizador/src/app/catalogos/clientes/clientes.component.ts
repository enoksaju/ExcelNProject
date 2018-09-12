import { Component, OnInit, OnDestroy } from '@angular/core';
import {
  ICatalogResponse,
  ICliente,
  IPageConfig,
  CatalogosService,
  OrderTypes,
} from '../../catalogos.service';
import { FormControl } from '@angular/forms';
import { MatDialog, PageEvent, Sort } from '@angular/material';
import { debounceTime, distinctUntilChanged } from 'rxjs/operators';
import { AddClienteComponent } from './add-cliente.component';
import { HttpParams } from '../../../../node_modules/@angular/common/http';
import { DialogService } from '../../dialog.service';
import { DialogButtonsFlags, DialogIcons, DialogResults } from '../../dialog.component';
import { UsuariosService } from '../../usuarios.service';
import { Subscription, Observable } from 'rxjs';

@Component({
  selector: 'cat-clientes.cc',
  templateUrl: './clientes.component.html',
  styleUrls: ['./clientes.component.scss'],
})
export class ClientesComponent implements OnInit, OnDestroy {
  clientesPage: ICatalogResponse<ICliente> = {
    TotalCount: 0,
    TotalPages: 0,
    Items: null,
  };
  clientes: ICliente[] = new Array<ICliente>();
  pagConfig: IPageConfig;
  searchControl: FormControl = new FormControl('');
  searchAll: boolean = false;
  loading: boolean = false;
  isAdmin: boolean = true;
  subIsAdmin$: Subscription;

  constructor(
    private catalogosService: CatalogosService,
    private dialog: MatDialog,
    private dialogServices: DialogService,
    public usuariosService: UsuariosService
  ) {
    this.pagConfig = {
      pageSize: 10,
      pageNumber: 1,
      orderType: OrderTypes.ASC,
      orderBy: 'Id',
      query: '',
    };

    this.searchControl.valueChanges
      .pipe(
        debounceTime(500),
        distinctUntilChanged()
      )
      .subscribe(query => {
        this.pagConfig.query = query;
        this.pagConfig.pageNumber = 1;
        this.getClientesPage();
      });
  }

  ngOnInit() {
    this.subIsAdmin$ = this.usuariosService.isAdmin().subscribe(o => {
      this.isAdmin = o;
      this.searchAll = o;
      this.getClientesPage();
    });
  }

  ngOnDestroy() {
    this.subIsAdmin$.unsubscribe();
  }

  columsToView(): string[] {
    if (this.isAdmin || this.searchAll) {
      return [
        'ClaveCliente',
        'NombreCliente',
        'AgenteId',
        'NombreContacto',
        'ActionsContact',
        'ActionEdit',
      ];
    } else {
      return ['ClaveCliente', 'NombreCliente', 'NombreContacto', 'ActionsContact', 'ActionEdit'];
    }
  }

  /**
   * Solicita la informacion al servicio.
   */
  async getClientesPage() {
    this.loading = true;
    this.catalogosService.getClientes(this.pagConfig, this.searchAll).then(o => {
      this.clientesPage = o;
      this.clientes = o.Items;
      this.loading = false;
    });
  }

  /**
   * Funcion de escucha para el evento de cambios en el paginador
   * @param pageEvent Propiedades del evento del paginador
   */
  async emitPaginator(pageEvent: PageEvent) {
    this.pagConfig.pageSize = pageEvent.pageSize;
    this.pagConfig.pageNumber = pageEvent.pageIndex + 1;
    this.getClientesPage();
  }

  /**
   *Funcion de escucha para el eventento de cambio de orden
   * @param sort Propiedades del evento de ordenamiento
   */
  async emitSort(sort: Sort) {
    this.pagConfig.orderBy = sort.active;
    this.pagConfig.orderType = sort.direction === 'asc' ? OrderTypes.ASC : OrderTypes.DESC;
    this.pagConfig.pageNumber = 1;
    this.getClientesPage();
  }

  /**
   * Muestra el cuadro de dialogo para agregar
   */
  add() {
    const ref = this.dialog.open<AddClienteComponent, any, DialogResults>(AddClienteComponent, {
      disableClose: true,
      width: '450px',
    });
    ref.afterClosed().subscribe(m => {
      if (m === DialogResults.Ok) {
        this.getClientesPage();
      }
    });
  }

  /**
   * Muestra el cuadro de dialogo para editar
   */
  edit(id: number) {
    const ref = this.dialog.open<AddClienteComponent, number, DialogResults>(AddClienteComponent, {
      disableClose: true,
      data: id,
      width: '450px',
    });
    ref.afterClosed().subscribe(m => {
      if (m === DialogResults.Ok) {
        this.getClientesPage();
      }
    });
  }

  /**
   * Elimina un cliente la Base de Datos.
   * @param id Id del cliente que se eliminara
   */
  delete(id: number) {
    this.dialogServices
      .showDialog('Eliminar!!', 'Realmente desea Eliminar al cliente?', {
        buttons: DialogButtonsFlags.Yes | DialogButtonsFlags.No,
        Icon: DialogIcons.Question,
      })
      .then(r => {
        if (r === DialogResults.Yes) {
          this.catalogosService
            .delCliente(id)
            .toPromise()
            .then(v =>
              this.dialogServices
                .showDialog('Correcto!!', v, { Icon: DialogIcons.Success })
                .then(() => this.getClientesPage())
            )
            .catch(e =>
              this.dialogServices.showDialog('Error!!', e, {
                Icon: DialogIcons.Error,
              })
            );
        }
      });
  }

  /**
   * Devuelve la url de busqueda de la direccion del cliente en google maps
   * @param v Cliente del que se obtendra la informacion
   */
  getURLLocation(v: ICliente): string {
    return `https://www.google.com/maps/search/?${new HttpParams()
      .set('api', '1')
      .set('query', `${v.Domicilio}, ${v.Ciudad}, ${v.Estado}`)
      .toString()}`;
  }
}
