import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '../../node_modules/@angular/common/http';
import { UsuariosService } from './usuarios.service';
import { Observable } from '../../node_modules/rxjs';

export enum OrderTypes { ASC, DESC }

const prefixApi: string = '/api/Catalogos/';
const rEstadoCatalogos: string = 'EstadoCatalogos';
const rClientes: string = 'Clientes';

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

/**
 * Interface con datos de paginacion y colecciones
 */
export interface ICatalogResponse {
  TotalCount: number;
  TotalPages: number;
  Items: ICliente[] | any[];
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

  constructor(private http: HttpClient, private usuariosService: UsuariosService) { }

  /**
   * Retorna el estado de los catalogos.
   */
  getStatus(): Promise<CatalogoMenuItem[]> {
    return this.http.get<CatalogoMenuItem[]>(`${prefixApi}${rEstadoCatalogos}`).toPromise();
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
        query: (pageConfig.query ? pageConfig.query : '%')
      }
    });
  }

  private getEntityByIdConfig(Id: any): HttpParams {
    return new HttpParams({ fromObject: { Id: Id.toString() } });
  }

  //#region Clientes

  /**
   * Regresa la coleccion de entidades Cliente y los datos de paginacion actuales.
   * @param pageConfig Configuracion de la paginacion
   */
  getClientes(pageConfig: IPageConfig, allUsers: boolean): Promise<ICatalogResponse> {
    return this.http.get<ICatalogResponse>(`${prefixApi}${rClientes}`, { params: this.getPageConfig(pageConfig).append('allUsers', String(allUsers)) }).toPromise();
  }

  getCliente(Id: number) {
    return this.http.get<ICliente>(`${prefixApi}${rClientes}`, { params: this.getEntityByIdConfig(Id) }).toPromise();
  }

  postCliente(cliente: ICliente): Observable<string> {
    return this.http.post<string>(`${prefixApi}${rClientes}`, cliente);
  }

  putCliente(cliente: ICliente): Observable<string> {
    return this.http.put<string>(`${prefixApi}${rClientes}`, cliente);
  }

  delCliente(Id: number): Observable<string> {
    return this.http.delete<string>(`${prefixApi}${rClientes}`, { params: this.getEntityByIdConfig(Id) });
  }

  //#endregion
}
