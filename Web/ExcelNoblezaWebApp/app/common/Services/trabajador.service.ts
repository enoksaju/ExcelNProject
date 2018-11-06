import { Injectable, Output, EventEmitter } from '@angular/core';
import { Headers, Http, ResponseContentType } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { DomSanitizer } from '@angular/platform-browser';
import { SafeResourceUrl } from "@angular/platform-browser";
import 'rxjs/add/operator/map';

export enum DiasDescanso {
  Lunes = 1, Martes, Miercoles, Jueves, Viernes, Sabado, Domingo
}
export enum Turnos {
  Primero = 1, Segundo, Tercero, Mixto
}
export enum Tipos {
  PorHoras = 1, UnDia, VariosDias
}

export class CapturPermiso {
  Clave: string;
  Inicio: Date;
  Fin: Date;
  Tipo: Tipos;
  Turno: Turnos;
  MotivoPermiso: number;
  Comentarios: string;
  DiaDescanso: DiasDescanso;
  Email: string;
  constructor(
    Clave: string,
    Email: string,
    Inicio: Date,
    Fin: Date,
    Tipo: Tipos,
    Turno: Turnos,
    MotivoPermiso: number,
    Comentario: string = '',
    DiaDescanso: DiasDescanso = DiasDescanso.Domingo) {
    this.Clave = Clave;
    this.Email = Email;
    this.Inicio = Inicio;
    this.Fin = Fin;
    this.Tipo = Tipo;
    this.Turno = Turno;
    this.MotivoPermiso = MotivoPermiso;
    this.Comentarios = Comentario;
    this.DiaDescanso = DiaDescanso;
  }
}


@Injectable() export class TrabajadorService {
  private headers = new Headers({ 'Content-Type': 'application/json' });

  private handleError(error: any): Promise<any> {
    console.error('An error occurred', error);
    return Promise.reject(error.message || error);
  }

  constructor(private http: Http, private _sanitizer: DomSanitizer) { }

  search(clave: string): Observable<any> {
    return this.http.get(`../../../../../../../../../api/trabajadores/search/?clave=${clave}`)
      .map(response => response.json() as any)
  }

  motivosPermiso(clave: string): Observable<any> {
    return this.http.get('../../../../../../../../../api/trabajadores/getMotivos/' + clave)
      .map(response => response.json() as any)
  }

  SolicitarPermiso(datos: CapturPermiso): Promise<any> {
    return this.http.post('../../../../../../../../api/ApiPermisos/crear', JSON.stringify(datos), { headers: this.headers })
      .toPromise()
      .then(res => res.json() as any)
      .catch(this.handleError)
  }

  DescargarPDF(Folio: string): void {
    window.open('../../../../../../../../../../api/apiPermisos/getPermiso/' + Folio, '_blank', '')
  }

  GetPermisoPDFUrl(Folio: string): Observable<SafeResourceUrl> {

    return this.http.get('../../../../../../../../../../api/apiPermisos/getPermiso/' + Folio, { responseType: ResponseContentType.ArrayBuffer })
      .map(response => {
        return this._sanitizer.bypassSecurityTrustResourceUrl(URL.createObjectURL(new Blob([response.arrayBuffer()], { type: 'application/pdf' })));
      });
  }

  GetReportPermisos(data: DataReport): Observable<ResultReport[]> {
    return this.http.post('../../../../../../../../../../api/apiPermisos/getReportData', data.Data)
      .map(response => {
        return response.json() as ResultReport[]
      }

      )
  }

}
export enum Estatus {
  Nuevo,
  Cancelado,
  Autorizado,
  Denegado
}

export class DataReport {
  private _fecha: Date;
  private _estatus: Estatus;
  @Output() changeValues: EventEmitter<any> = new EventEmitter();

  set Fecha(Fecha: Date) {
    this._fecha = Fecha
    this.changeValues.emit(this)
  }
  get Fecha(): Date {
    return this._fecha;
  }

  set Estatus(Estatus: Estatus) {
    this._estatus = Estatus;
    this.changeValues.emit(this)
  }
  get Estatus(): Estatus {
    return this._estatus;
  }

  get Data(): any {
    return { Fecha: this._fecha, Estatus: this._estatus }
  }
}
export class ResultReport {
  public Clave: string;
  public Folio: string;
  public Dia1: string;
  public Dia2: string;
  public Dia3: string;
  public Dia4: string;
  public Dia5: string;
  public Dia6: string;
  public Dia7: string;
  public Dia8: string;
  public Dia9: string;
  public Dia10: string;
  public Concepto: string;
  public Estatus: string;
  public ValidadoPor: string;
  public Comentarios: string;
}