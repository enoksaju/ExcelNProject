import { Component, OnInit, OnDestroy } from '@angular/core';
import {
  OrderTypes,
  IPageConfig,
  ICatalogResponse,
  ITinta,
  CatalogosService,
  ROUTE_TINTAS,
  Column,
} from '../../catalogos.service';
import { Subscription } from 'rxjs';
import { UsuariosService } from '../../usuarios.service';
import { MatDialog } from '@angular/material';
import { DialogService } from '../../dialog.service';
import { AddEditTintaComponent } from './add-edit-tinta/add-edit-tinta.component';
import { DialogResults } from '../../dialog.component';

@Component({
  selector: 'cat-tintas',
  templateUrl: './tintas.component.html',
  styleUrls: ['./tintas.component.scss'],
})
export class TintasComponent implements OnInit, OnDestroy {
  /**
   * Contenido del Catalogo
   */
  catalogPage: ICatalogResponse<ITinta> = {
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
    this.catalogPage = await this.catalogosService.getCollection<ITinta>(
      this.pagConfig,
      ROUTE_TINTAS,
    );
    this.isLoading = false;
  }

  /**
   * Define la coleccion de las columnas
   */
  columsToView(): Column[] {
    return [
      // new Column('Id', 'Id', { flex: '100px' }),
      new Column('Nombre', 'Nombre de la Tinta'),
      new Column('Tipo', 'Tipo'),
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

  AddOrEdit(entity: ITinta = null) {
    this.dialog
      .open<AddEditTintaComponent, ITinta, DialogResults>(AddEditTintaComponent, {
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
