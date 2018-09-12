import { Component, OnInit, OnDestroy } from '@angular/core';
import {
  animate,
  state,
  style,
  transition,
  trigger
} from '@angular/animations';
import {
  CatalogosService,
  ICatalogResponse,
  IPageConfig,
  OrderTypes,
  ROUTE_MATERIALES,
  Column,
  IMaterial,
  IFamiliasMateriales
} from '../../catalogos.service';
import { UsuariosService } from '../../usuarios.service';
import { DialogService } from '../../dialog.service';
import { Subscription } from 'rxjs';
import { MatDialog } from '@angular/material';
import { AddEditMaterialComponent } from './add-edit-material.component';
import {
  DialogResults,
  DialogButtonsFlags,
  DialogIcons
} from '../../dialog.component';

@Component({
  selector: 'cat-materiales',
  templateUrl: './materiales.component.html',
  styles: []
})
export class MaterialesComponent implements OnInit, OnDestroy {
  /**
   * Contenido del Catalogo
   */
  catalogPage: ICatalogResponse<IMaterial> = {
    TotalCount: 0,
    TotalPages: 0,
    Items: null
  };

  /**
   * Configuracion del Paginador
   */
  pagConfig: IPageConfig = {
    pageSize: 10,
    pageNumber: 1,
    orderType: OrderTypes.ASC,
    orderBy: 'Id',
    query: ''
  };

  isLoading: boolean = false;
  isAdmin: boolean = false;

  needRefresh$: Subscription;
  subIsAdmin$: Subscription;

  constructor(
    public catalogosService: CatalogosService,
    private usuariosService: UsuariosService,
    private dialogService: DialogService,
    private dialog: MatDialog
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
    this.catalogPage = await this.catalogosService.getCollection<IMaterial>(
      this.pagConfig,
      ROUTE_MATERIALES
    );
    this.isLoading = false;
  }

  /**
   * Define la coleccion de las columnas
   */
  columsToView(): Column[] {
    return [
      // new Column('Id', 'Id', { flex: '100px' }),
      new Column('FamiliaMateriales_Id', 'Familia', {
        columnToShow: 'NombreFamilia'
      }),
      new Column('Apariencia', 'Apariencia'),
      new Column('Caracteristicas', 'Caracteristicas'),
      new Column('PrecioActual', 'Precio Actual', { type: 'currency' }),
      new Column('FechaRegistro', 'Fecha de Registro', { type: 'date' }),
      new Column('FechaOperacion', 'Fecha de Operacion', { type: 'date' }),
      // new Column('Unidad', 'Unidad'),
      new Column('ActionEdit', 'Acciones', { sortable: false, db: false })
    ];
  }

  /**
   * Regresa el nombre de las columnas a mostrar
   */
  columns() {
    return this.columsToView().map(p => p.column);
  }

  AddOrEdit(entity?: IMaterial) {
    this.dialog
      .open<AddEditMaterialComponent, IMaterial, DialogResults>(
        AddEditMaterialComponent,
        {
          disableClose: true,
          data: entity,
          width: '800px'
        }
      )
      .afterClosed()
      .toPromise()
      .then(r => {
        if (r === DialogResults.Ok) {
          this.fillCatalog();
        }
      });
  }
  delete(id: number) {
    this.dialogService
      .showDialog('Eliminar!!', 'Realmente desea Eliminar el material?', {
        buttons: DialogButtonsFlags.Yes | DialogButtonsFlags.No,
        Icon: DialogIcons.Question
      })
      .then(r => {
        if (r === DialogResults.Yes) {
          this.catalogosService.delEntity(id, ROUTE_MATERIALES);
        }
      });
  }
}
