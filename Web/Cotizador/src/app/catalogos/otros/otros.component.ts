import { Component, OnInit, OnDestroy } from '@angular/core';
import {
  OrderTypes,
  IPageConfig,
  ICatalogResponse,
  CatalogosService,
  Column,
  IOtro,
  ROUTE_OTROS,
} from '../../catalogos.service';
import { Subscription } from 'rxjs';
import { UsuariosService } from '../../usuarios.service';
import { MatDialog } from '@angular/material';
import { DialogService } from '../../dialog.service';
import { DialogResults } from '../../dialog.component';
import { AddEditOtrosComponent } from './add-edit-otros/add-edit-otros.component';

@Component({
  selector: 'cat-otros',
  templateUrl: './otros.component.html',
  styleUrls: ['./otros.component.scss'],
})
export class OtrosComponent implements OnInit, OnDestroy {
  /**
   * Contenido del Catalogo
   */
  catalogPage: ICatalogResponse<IOtro> = {
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
    private dialog: MatDialog,
    private dialogService: DialogService,
  ) {
    this.needRefresh$ = this.catalogosService.needRefresh.subscribe(p => {
      this.fillCatalog();
    });

    this.subIsAdmin$ = this.usuariosService.isAdmin().subscribe(o => {
      this.isAdmin = o;
      this.fillCatalog();
    });
  }

  ngOnInit() {}
  ngOnDestroy() {
    this.subIsAdmin$.unsubscribe();
    this.needRefresh$.unsubscribe();
  }

  /**
   * Llena el catalogo
   */
  async fillCatalog() {
    this.isLoading = true;
    this.catalogPage = await this.catalogosService.getCollection<IOtro>(
      this.pagConfig,
      ROUTE_OTROS,
    );
    this.isLoading = false;
  }
  /**
   * Define la coleccion de las columnas
   */
  columsToView(): Column[] {
    return [
      // new Column('Id', 'Id', { flex: '100px' }),
      new Column('Nombre', 'Nombre'),
      new Column('Costo', 'Costo', { type: 'currency' }),
      new Column('Precio', 'Precio', { type: 'currency' }),
      new Column('ActionEdit', 'Acciones', { sortable: false, db: false }),
    ];
  }

  /**
   * Regresa el nombre de las columnas a mostrar
   */
  columns() {
    return this.columsToView().map(p => p.column);
  }

  AddOrEdit(entity: IOtro = null) {
    this.dialog
      .open<AddEditOtrosComponent, IOtro, DialogResults>(AddEditOtrosComponent, {
        disableClose: true,
        data: entity,
        width: '400px',
      })
      .afterClosed()
      .toPromise()
      .then(r => {
        if (r === DialogResults.Ok) {
          this.fillCatalog();
        }
      });
  }
}
