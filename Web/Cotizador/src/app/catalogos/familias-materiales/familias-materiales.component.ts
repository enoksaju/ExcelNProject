import { Component, OnInit } from '@angular/core';
import {
  CatalogosService,
  ICatalogResponse,
  IPageConfig,
  OrderTypes,
  Column,
} from '../../catalogos.service';
import { UsuariosService } from '../../usuarios.service';

@Component({
  selector: 'cat-familias-materiales.cc',
  templateUrl: './familias-materiales.component.html',
  styleUrls: ['./familias-materiales.component.scss'],
})
export class FamiliasMaterialesComponent implements OnInit {
  /**
   * Contenido del Catalogo
   */
  catalogPage: ICatalogResponse = {
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

  /**
   * Constructor del componente
   * @param catalogosService
   * @param usuariosService
   */
  constructor(public catalogosService: CatalogosService, private usuariosService: UsuariosService) {
    this.catalogosService.needRefresh.subscribe(p => {
      this.fillCatalog();
    });

    this.usuariosService.CurrentIsInRol('Administrador,Sistemas,Develop').subscribe(p => {
      this.isAdmin = p;
      this.fillCatalog();
    });
  }

  ngOnInit() {}

  /**
   * Llena el catalogo
   */
  fillCatalog() {
    this.isLoading = true;
    this.catalogosService.getFamiliasMateriales(this.pagConfig).then(result => {
      this.catalogPage = result;
      this.isLoading = false;
    });
  }

  /**
   * Define la coleccion de las columnas
   */
  columsToView(): Column[] {
    return [
      new Column('Id', 'Id', { flex: '100px' }),
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

  add() {
    console.log('you press add button');
  }

  edit(id: number) {
    console.log('you press edit button on ' + id);
  }
  delete(id: number) {
    console.log('you press delete button on ' + id);
  }
}
