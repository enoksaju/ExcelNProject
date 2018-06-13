import { Injectable, Output, EventEmitter } from '@angular/core';
import { Headers, Http, ResponseContentType } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { DomSanitizer } from '@angular/platform-browser';
import { SafeResourceUrl } from "@angular/platform-browser";
import 'rxjs/add/operator/map';


export enum TIPOS {
  PELICULA,
  PELICULALAMINADA,
  PELICULATRILAMINADA,
  FLOWPACKLAMINADA,
  FLOWPACKTRILAMINADA,
  SELLOLATERALNOIMPRESA,
  SELLOLATERALIMPRESA,
  SELLOLATERALLAMINADANOIMPRESA,
  SELLOLATERALLAMINADAIMPRESA,
  SELLOLATERALTRILAMINADA,
  OTRO,
  ETIQUETA,
  PVC,
  PROTOTIPOS,
  PIEZAS,
  ETIQUETATIPOMANGA,
  BOLSATUBULAR
}

export enum TIPOSIMPRESION {
  PIE = 1,
  CABEZA,
  PORDENTRO,
  PORFUERA,
  REPETICION,
  PIEDEIMPRESIÓN,
}
export enum Procesos {
  Corte, Doblado, Embobinado, Extrusion, Impresion, Laminacion, Mangas, Refinado, Sellado, Todas
}

export class GetOTModel {
  OrderNumber: string = '';
  Proceso: Procesos = Procesos.Todas;
}

export class infoOT {
  //private _esimpreso: boolean;

  FECHARECIBIDO: Date;
  TIPO: TIPOS;
  OT: string;
  FECHAENTREGASOL: Date;
  CLIENTE: string;
  PRODUCTO: string;
  CANTIDAD: number;
  UNIDAD: string;
  ANCHO: number;
  ALTO: number;
  SOLAPA: number;
  FUELLELATERAL: number;
  FUELLEFONDO: number;
  COPETE: number;
  AREASELLOREV: number;
  AREASELLOFONDO: number;
  TIPOIMPRESION: number;
  TIPOTRABAJO: number;
  REPEJE: number;
  REPDES: number;
  MATBASE: string;
  MATBASECALIBRE: number;
  MATBASEKG: number;
  MATLAMINACION: string;
  MATLAMINACIONCALIBRE: number;
  MATLAMINACIONKG: number;
  MATTRILAMINACION: string;
  MATTRILAMINACIONCALIBRE: number;
  MATTRILAMINACIONKG: number;
  CLAVEINTELISIS: string;
  ORDENCOMPRA: string;
  CLAVEPRODUCTO: string;
  IMPRESORA: string;
  RODILLO: number;
  FIGURASALIDAFINAL: number;
  EMPATES: string;
  INSTCORTE: string;
  INSTDOBLADO: string;
  INSTEMBOBINADO: string;
  INSTEXTRUSION: string;
  INSTIMPRESION: string;
  INSTLAMINACION: string;
  INSTMANGAS: string;
  INSTREFINADO: string;
  INSTSELLADO: string;
  OBSERVACIONES: string;
  ENABLED: boolean;
  ESIMPRESO: string;
  KGXMILL: number;
  MATBASEAMU: number;
  EXTIPO: string;
  EXCOLOR: string;
  EXTRATADO: string;
  EXDINAS: string;
  EXDESLIZ: string;
  EXANTIESTATICA: string;
  MATLAMINACIONAMU: number;
  MATTRILAMINACIONAMU: number;
  EXKG: string;
  EXANCHO: string;
  TIPOINSTRING: string;
  ID: number
  OtImpresa(): boolean {
    return (this.ESIMPRESO == "True" ? true : false);
  }
}

@Injectable() export class OTService {
  private headers = new Headers({ 'Content-Type': 'application/json' });
  private handleError(error: any): Promise<any> {
    return Promise.reject(JSON.parse(error._body) || error);
  }
  constructor(private http: Http, private _sanitizer: DomSanitizer) { }

  verOt(data: GetOTModel): Promise<infoOT>{
    return this.http.post('../../../../../../../../../../api/OrdenTrabajo/ver', data)
      .toPromise()
      .then(res =>  res.json() as infoOT )
      .catch(this.handleError)
  }
}