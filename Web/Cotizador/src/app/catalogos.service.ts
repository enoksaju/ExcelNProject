import { Injectable, Output, EventEmitter } from '@angular/core';
import {
  HttpClient,
  HttpParams,
  HttpErrorResponse
} from '../../node_modules/@angular/common/http';
import { UsuariosService } from './usuarios.service';
import { Observable, BehaviorSubject } from '../../node_modules/rxjs';
import { PageEvent, Sort } from '@angular/material';

export enum OrderTypes {
  ASC,
  DESC
}

export const prefixApi: string = '/api/Catalogos/';
export const rEstadoCatalogos: string = 'EstadoCatalogos';
export const rClientes: string = 'Clientes';
export const ROUTE_FAMILIA_MATERIALES: string = 'familiasmateriales';
export const ROUTE_MOVIMIENTOS_PRECIO_FAMILIA_MATERIALES: string =
  'familiasmateriales/mov';
export const ROUTE_MOVIMIENTOS_PRECIO_FAMILIA_MATERIALES_CHARTS: string =
  'familiasmateriales/mov/chartdata';
export const ROUTE_MATERIALES: string = 'materiales';

export const ROUTE_IMPRESORAS: string = 'impresoras';

//#region Interfaces

/**
 * Descripcion de un Elemento en el menu de catalogos.
 */
export interface CatalogoMenuItem {
  Nombre: string;
  Icono: string;
  Content?: string;
  Route?: string;
}

export class Column {
  column: string;
  text: string;
  db: boolean;
  sortable: boolean;
  flex: string;
  columnToShow: string;
  type: string;

  constructor(
    column: string,
    text: string,
    options?: {
      db?: boolean;
      sortable?: boolean;
      flex?: string;
      columnToShow?: string;
      type?: string;
    }
  ) {
    const defaults_ = {
      db: true,
      sortable: true,
      flex: '1 1 100%',
      columnToShow: column,
      type: 'default'
    };
    const options_ = Object.assign(defaults_, options);
    this.column = column;
    this.text = text;
    this.db = options_.db;
    this.flex = options_.flex;
    this.sortable = options_.sortable;
    this.columnToShow = options_.columnToShow;
    this.type = options_.type;
  }
}

/**
 * Interface con datos de paginacion y colecciones
 */
export interface ICatalogResponse<t> {
  TotalCount: number;
  TotalPages: number;
  Items: t[];
}

/**
 * Interface para la entidad Ciente
 */
export interface ICliente {
  Id?: number;
  NombreCliente?: string;
  ClaveCliente?: string;
  NombreContacto?: string;
  Telefono?: string;
  Email?: string;
  Domicilio?: string;
  Ciudad?: string;
  Estado?: string;
  AgenteId?: number;
  NombreEjecutivo?: string;
}

export interface IFamiliasMateriales {
  Id?: number;
  NombreFamilia?: string;
}

export enum UnidadesMaterial {
  Micras,
  CI
}

export interface IMaterial {
  Id?: number;
  FamiliaMateriales_Id?: number;
  Apariencia?: string;
  Caracteristicas?: string;
  Unidad?: UnidadesMaterial;
  FactorDensidad?: number;
  PrecioInicial?: number;
  CostoInicial?: number;
  Metalizado?: boolean;
  Convenio?: boolean;
  FechaRegistro?: Date;
  FechaOperacion?: Date;
  Calibres?: ICalibre[];
  PrecioActual?: number;
  NombreFamilia?: string;
}

export interface ICalibre {
  MaterialId: number;
  Valor: number;
}

export interface IImpresora {
  Id?: number;
  NombreMaquina?: string;
  ModeloMaquina?: string;
  CostoArranque?: number;
  CostoTurno?: number;
  PorcentajeDesperdicio?: number;
  MinutosTurno?: number;
  AnchoMinimoImpresion?: number;
  AnchoMaximoImpresion?: number;
  AnchoMinimoMaterial?: number;
  AnchoMaximoMaterial?: number;
  Velocidad?: number;
  Decks?: number;
  Linea_Id?: number;
  LineaNombre?: string;

  ConfiguracionTintas?: IConfigTintaMaquina[];
  Rodillos?: IRodillo[];
}

export interface IRodillo {
  Id?: number;
  Medida?: number;
  Cantidad?: number;
}

export interface IConfigTintaMaquina {
  Cantidad?: number;
  MinimoMetros?: number;
}

export interface ILinea {
  Id: number;
  Nombre: string;
  Responsable: string;
  EmailResponsable: string;
}

/**
 * Interface de Paginacion
 */
export interface IPageConfig {
  pageSize: number;
  pageNumber: number;
  orderType: OrderTypes;
  orderBy: string;
  query: string;
}

//#endregion

@Injectable({
  providedIn: 'root'
})
export class CatalogosService {
  @Output()
  needRefresh: EventEmitter<any> = new EventEmitter(true);

  @Output()
  onHttpComplete: EventEmitter<string> = new EventEmitter(true);

  @Output()
  onHttpError: EventEmitter<HttpErrorResponse> = new EventEmitter(true);

  constructor(
    private http: HttpClient,
    private usuariosService: UsuariosService
  ) {}

  /**
   * Retorna el estado de los catalogos.
   */
  getStatus(): Promise<CatalogoMenuItem[]> {
    return this.http
      .get<CatalogoMenuItem[]>(`${prefixApi}${rEstadoCatalogos}`)
      .toPromise();
  }

  /**
   * Regresa parametros para los metodos GET de paginacion de colecciones.
   * @param pageConfig Configuracion de paginacion
   */
  private getPageConfig(pageConfig: IPageConfig): HttpParams {
    return new HttpParams({
      fromObject: {
        pageSize: pageConfig.pageSize.toString(),
        pageNumber: pageConfig.pageNumber.toString(),
        orderType: pageConfig.orderType.toString(),
        orderBy: pageConfig.orderBy,
        query: pageConfig.query ? pageConfig.query : '%'
      }
    });
  }

  private getEntityByIdConfig(Id: any): HttpParams {
    return new HttpParams({ fromObject: { Id: Id.toString() } });
  }

  //#region ManagePaginator
  /**
   * Funcion de escucha para el evento de cambios en el paginador
   * @param pageEvent Propiedades del evento del paginador
   */
  async emitPaginator(pageEvent: PageEvent, pagConfig: IPageConfig) {
    pagConfig.pageSize = pageEvent.pageSize;
    pagConfig.pageNumber = pageEvent.pageIndex + 1;
    this.needRefresh.emit();
  }

  /**
   *Funcion de escucha para el eventento de cambio de orden
   * @param sort Propiedades del evento de ordenamiento
   */
  async emitSort(sort: Sort, pagConfig: IPageConfig) {
    pagConfig.orderBy = sort.active;
    pagConfig.orderType =
      sort.direction === 'asc' ? OrderTypes.ASC : OrderTypes.DESC;
    pagConfig.pageNumber = 1;
    this.needRefresh.emit();
  }
  //#endregion

  //#region Clientes

  /**
   * Regresa la coleccion de entidades Cliente y los datos de paginacion actuales.
   * @param pageConfig Configuracion de la paginacion
   */
  getClientes(pageConfig: IPageConfig, allUsers: boolean) {
    return this.http
      .get<ICatalogResponse<ICliente>>(`${prefixApi}${rClientes}`, {
        params: this.getPageConfig(pageConfig).append(
          'allUsers',
          String(allUsers)
        )
      })
      .toPromise();
  }

  getCliente(Id: number) {
    return this.http
      .get<ICliente>(`${prefixApi}${rClientes}`, {
        params: this.getEntityByIdConfig(Id)
      })
      .toPromise();
  }

  postCliente(cliente: ICliente): Observable<string> {
    return this.http.post<string>(`${prefixApi}${rClientes}`, cliente);
  }

  putCliente(cliente: ICliente): Observable<string> {
    return this.http.put<string>(`${prefixApi}${rClientes}`, cliente);
  }

  delCliente(Id: number): Observable<string> {
    return this.http.delete<string>(`${prefixApi}${rClientes}`, {
      params: this.getEntityByIdConfig(Id)
    });
  }

  //#endregion

  //#region General Collections
  getCollection<t>(pageConfig: IPageConfig, apiRoute: string) {
    return this.http
      .get<ICatalogResponse<t>>(`${prefixApi}${apiRoute}`, {
        params: this.getPageConfig(pageConfig)
      })
      .toPromise();

    /* pageSize: number;
pageNumber: number;
orderType: OrderTypes;
orderBy: string;
query: string; */
  }

  getAllCollection<t>(
    apiRoute: string,
    _orderType: OrderTypes = OrderTypes.ASC,
    _orderBy: string = 'Id'
  ) {
    return this.http.get<ICatalogResponse<t>>(`${prefixApi}${apiRoute}`, {
      params: this.getPageConfig({
        pageSize: 4000000,
        pageNumber: 1,
        orderType: _orderType,
        orderBy: _orderBy,
        query: '%'
      })
    });
  }

  getCollectionsOfEntity(Id: number, apiRoute: string) {
    return this.http.get<any>(`${prefixApi}${apiRoute}/${Id}`);
  }

  getEntity<t>(Id: number, apiRoute: string) {
    return this.http
      .get<t>(`${prefixApi}${apiRoute}`, {
        params: this.getEntityByIdConfig(Id)
      })
      .toPromise();
  }

  postEntity<t>(entidad: t, apiRoute: string) {
    return new Observable<string>(observer => {
      this.http
        .post<string>(`${prefixApi}${apiRoute}`, entidad)
        .toPromise()
        .then(u => {
          observer.next(u);
          this.onHttpComplete.emit(u);
          observer.complete();
        })
        .catch((e: HttpErrorResponse) => {
          observer.error(e);
          this.onHttpError.emit(e);
          observer.complete();
        });
    }).toPromise();
  }
  putEntity<t>(entidad: t, apiRoute: string) {
    return new Observable<string>(observer => {
      this.http
        .put<string>(`${prefixApi}${apiRoute}`, entidad)
        .toPromise()
        .then(u => {
          observer.next(u);
          this.onHttpComplete.emit();
          observer.complete();
        })
        .catch((e: HttpErrorResponse) => {
          observer.error(e);
          observer.complete();
        });
    }).toPromise();
  }

  delEntity(Id: number, apiRoute: string) {
    return new Observable<string>(observer => {
      this.http
        .delete<string>(`${prefixApi}${apiRoute}`)
        .toPromise()
        .then(u => {
          observer.next(u);
          this.onHttpComplete.emit();
          observer.complete();
        })
        .catch((e: HttpErrorResponse) => {
          observer.error(e);
          observer.complete();
        });
    }).toPromise();
  }
  //#endregion
}
