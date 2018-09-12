import { Component, OnInit, OnDestroy } from '@angular/core';
import {
  CatalogosService,
  ICatalogResponse,
  IPageConfig,
  OrderTypes,
  Column,
  ROUTE_FAMILIA_MATERIALES,
  IFamiliasMateriales,
} from '../../catalogos.service';
import { UsuariosService } from '../../usuarios.service';
import { MatDialog } from '@angular/material';
import { AddEditFamiliaMaterialesComponent } from './add-edit-familia-materiales.component';
import { DialogResults, DialogButtonsFlags, DialogIcons } from '../../dialog.component';
import { DialogService } from '../../dialog.service';
import { Observable, Subscription } from 'rxjs';
import { MovimientosFamiliasMaterialesComponent } from './movimientos-familias-materiales.component';

@Component({
  selector: 'cat-familias-materiales.cc',
  templateUrl: './familias-materiales.component.html',
  styleUrls: ['./familias-materiales.component.scss'],
})
export class FamiliasMaterialesComponent implements OnInit, OnDestroy {
  /**
   * Contenido del Catalogo
   */
  catalogPage: ICatalogResponse<IFamiliasMateriales> = {
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

  /**
   * Constructor del componente
   * @param catalogosService
   * @param usuariosService
   */
  constructor(
    public catalogosService: CatalogosService,
    private usuariosService: UsuariosService,
    private dialog: MatDialog,
    private dialogService: DialogService
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
    this.catalogPage = await this.catalogosService.getCollection<IFamiliasMateriales>(
      this.pagConfig,
      ROUTE_FAMILIA_MATERIALES
    );
    this.isLoading = false;
  }

  /**
   * Define la coleccion de las columnas
   */
  columsToView(): Column[] {
    return [
      // new Column('Id', 'Id', { flex: '100px' }),
      new Column('NombreFamilia', 'Nombre de la Familia'),
      new Column('ActionEdit', 'Acciones', { sortable: false, db: false }),
    ];
  }

  /**
   * Regresa el nombre de las columnas a mostrar
   */
  columns() {
    return this.columsToView().map(p => p.column);
  }

  AddOrEdit(Id: number = null) {
    this.dialog
      .open<AddEditFamiliaMaterialesComponent, number, DialogResults>(
        AddEditFamiliaMaterialesComponent,
        {
          disableClose: true,
          data: Id,
          width: '450px',
        }
      )
      .afterClosed()
      .toPromise()
      .then(m => {
        if (m === DialogResults.Ok) {
          this.fillCatalog();
        }
      });
  }

  viewMovesToPrice(id: number) {
    this.dialog.open<MovimientosFamiliasMaterialesComponent, number, DialogResults>(
      MovimientosFamiliasMaterialesComponent,
      {
        data: id,
        disableClose: true,
        width: '100%',
        height: '100%',
        maxWidth: '100vw',
        maxHeight: '100vh',
      }
    );
  }

  delete(id: number) {
    this.dialogService
      .showDialog('Eliminar!!', 'Realmente desea Eliminar al cliente?', {
        buttons: DialogButtonsFlags.Yes | DialogButtonsFlags.No,
        Icon: DialogIcons.Question,
      })
      .then(r => {
        if (r === DialogResults.Yes) {
          this.catalogosService.delEntity(id, ROUTE_FAMILIA_MATERIALES);
        }
      });
  }
}
