import { Component, OnInit, OnDestroy } from '@angular/core';
import {
  ICatalogResponse,
  IPageConfig,
  OrderTypes,
  CatalogosService,
  Column,
  ROUTE_IMPRESORAS,
  IImpresora,
} from '../../catalogos.service';
import { Subscription } from 'rxjs';
import { UsuariosService } from '../../usuarios.service';
import { DialogService } from '../../dialog.service';
import { MatDialog } from '@angular/material';
import { AddEditImpresoraComponent } from './add-edit-impresora/add-edit-impresora.component';
import { DialogResults, DialogButtonsFlags, DialogIcons } from '../../dialog.component';

@Component({
  selector: 'cat-impresoras',
  templateUrl: './impresoras.component.html',
  styleUrls: ['./impresoras.component.scss'],
})
export class ImpresorasComponent implements OnInit, OnDestroy {
  /**
   * Contenido del Catalogo
   */
  catalogPage: ICatalogResponse<IImpresora> = {
    TotalCount: 0,
    TotalPages: 0,
    Items: null,
  };

  /**
   * Configuracion del Paginador
   */
  pagConfig: IPageConfig = {
    pageSize: 10,
    pageNumber: 1,
    orderType: OrderTypes.ASC,
    orderBy: 'Id',
    query: '',
  };

  isLoading: boolean = false;
  isAdmin: boolean = false;

  needRefresh$: Subscription;
  subIsAdmin$: Subscription;

  constructor(
    public catalogosService: CatalogosService,
    private usuariosService: UsuariosService,
    private dialogService: DialogService,
    private dialog: MatDialog,
  ) {
    this.needRefresh$ = this.catalogosService.needRefresh.subscribe(p => {
      this.fillCatalog();
    });

    this.subIsAdmin$ = this.usuariosService.isAdmin().subscribe(o => {
      this.isAdmin = o;
      this.fillCatalog();
    });
  }

  ngOnInit(): void {}

  ngOnDestroy(): void {
    this.subIsAdmin$.unsubscribe();
    this.needRefresh$.unsubscribe();
  }

  /**
   * Llena el catalogo
   */
  async fillCatalog() {
    this.isLoading = true;
    this.catalogPage = await this.catalogosService.getCollection<IImpresora>(
      this.pagConfig,
      ROUTE_IMPRESORAS,
    );
    this.isLoading = false;
  }

  /**
   * Define la coleccion de las columnas
   */
  columsToView(): Column[] {
    return [
      //new Column('Id', 'Id', { flex: '100px' }),
      new Column('NombreMaquina', 'Maquina'),
      new Column('ModeloMaquina', 'Modelo'),
      new Column('Decks', 'Unidades', { flex: '100px' }),
      new Column('Velocidad', 'Velocidad', { flex: '100px' }),
      new Column('CostoArranque', 'Costo de Arranque', {
        type: 'currency',
        flex: '110px',
      }),
      new Column('CostoTurno', 'Costo por Turno', {
        type: 'currency',
        flex: '110px',
      }),
      new Column('Linea_Id', 'Linea', { columnToShow: 'LineaNombre' }),
      // new Column('Unidad', 'Unidad'),
      new Column('ActionEdit', 'Acciones', { sortable: false, db: false }),
    ];
  }

  /**
   * Regresa el nombre de las columnas a mostrar
   */
  columns() {
    return this.columsToView().map(p => p.column);
  }

  /**
   * Abre el dialogo de Edición, o el dialogo para agregar, solo lo puede hacer un administrador.
   * @param entity Entidad que se desea editar, si el valor es null se abre el dialogo en modo agregar, de lo contrario se abre en modo editar
   */
  AddOrEdit(entity?: IImpresora) {
    if (this.isAdmin) {
      this.dialog
        .open(AddEditImpresoraComponent, {
          disableClose: true,
          data: entity,
          width: '800px',
        })
        .afterClosed()
        .toPromise()
        .then(r => {
          this.fillCatalog();
        });
    }
  }

  /**
   * Elimina el elemento indicado por la llave principal.
   * @param id Clave Principal del elemento que se desea Eliminar
   */
  delete(id: number) {
    if (this.isAdmin) {
      this.dialogService
        .showDialog('Eliminar!!', 'Realmente desea Eliminar la Impresora?', {
          buttons: DialogButtonsFlags.Yes | DialogButtonsFlags.No,
          Icon: DialogIcons.Question,
        })
        .then(r => {
          if (r === DialogResults.Yes) {
            this.catalogosService.delEntity(id, ROUTE_IMPRESORAS);
          }
        });
    }
  }
}
