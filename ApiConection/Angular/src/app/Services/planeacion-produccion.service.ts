import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, of, Observable } from 'rxjs';
import * as moment from 'moment';
import { map, flatMap, catchError } from 'rxjs/operators';


export enum statusProcesoProduccion {
  PorProgramar = 1 << 0,
  Programada = 1 << 1,
  Reprogramada = 1 << 2,
  EnProceso = 1 << 3,
  Concluida = 1 << 4,
  Activa = 1 << 5
}

export interface CalendarItem {
  Proceso: number;
  Estatus: statusProcesoProduccion;
  Activa: boolean;
  Prioridad: number | null;
  NombreProceso: string;
  OT: string;
  Cliente: string;
  Producto: string;
  FechaEntrega: Date;
  FechaProgramada: Date | null;
  MaquinaId: number;
  Maquina: string;
  Ml: number;

  isLoading: boolean | null;
}

export interface SemanaData {
  data: CalendarItem[];
  DiaInicial?: Date;
  DiaFinal?: Date;
}

export interface OrderData {
  OT: string,
  Cliente: string,
  Producto: string,
  TipoProducto: string,
  ClaveIntelisis: string,
  OrdenCompra: string,
  FechaEntregaSol: Date,
  FechaRecibido: Date,
  FechaCaptura: Date,
  ML: number,
  Cantidad: number,
  Unidad: string,
  KGXMILL: number,
  Procesos: OrderDataProgress[]
}
export interface OrderDataProgress {
  PesoNeto: number,
  Conteo: number,
  Bobinas: number,
  Banderas: number,
  maximoBanderasBobina: number,
  BobinasArrugas: number,
  NombreProceso: string,
  UltimaCaptura: string,
  Maquinas: string
}

@Injectable({
  providedIn: 'root'
})
export class PlaneacionProduccionService {
  private unasignedItems: BehaviorSubject<CalendarItem[]>;
  private semanaItems: BehaviorSubject<SemanaData>;
  private detailsOT: BehaviorSubject<OrderData>;

  constructor(private httpClient: HttpClient) {
    this.unasignedItems = new BehaviorSubject<CalendarItem[]>([]);
    this.semanaItems = new BehaviorSubject<SemanaData>({ data: [] });
    this.detailsOT = new BehaviorSubject<OrderData>(null);
    this.MaquinaId = 5;
  }

  MaquinaId: number;

  get UnasignedItems() {
    return this.unasignedItems.asObservable();
  }
  get PlanItems() {
    return this.semanaItems.asObservable();
  }
  get DetailsOT() {
    return this.detailsOT.asObservable();
  }

  public refreshUnasigned(proceso: number) {

    this.httpClient.get<CalendarItem[]>('api/unasignedPlaneacion', { params: { 'Proceso': proceso.toString() } })
      .toPromise()
      .then(dt => {
        console.log('resolve unasigned...')
        this.unasignedItems.next(dt);
      }).catch(err => console.log(err)).finally(() => console.log('finally unasigned...'))

  }

  public refreshPlanSemanal(anio: number, semana: number) {

    this.httpClient.get<SemanaData>('api/planeacionSemana',
      {
        params: { 'anio': anio.toString(), 'semana': semana.toString(), 'maquinaId': this.MaquinaId.toString() }
      })
      .toPromise()
      .then(dt => {
        console.log('resolve plan semanal...')
        this.semanaItems.next(dt);
      }).catch(err => console.log(err)).finally(() => console.log('finally plan semanal...'))

  }

  public initCalendarioSemana(proceso: number, anio: number, semana: number) {
    this.httpClient.get('api/initialSemana', {
      params: {
        'anio': anio.toString(),
        'semana': semana.toString(),
        'maquinaId': this.MaquinaId.toString(),
        'Proceso': proceso.toString()
      }
    }).toPromise()
      .then((dt: any) => {
        this.semanaItems.next(dt.semana);
        this.unasignedItems.next(dt.unasigned);
      })
  }

  UpdateCalendarItem(item: CalendarItem) {

    if (item.FechaProgramada == null) {
      item.Estatus &= ~statusProcesoProduccion.Programada;
      item.MaquinaId = null;
    } else {
      item.Estatus |= statusProcesoProduccion.Programada;
      item.MaquinaId = this.MaquinaId;
    }

    return this.httpClient.post('api/updateCalendarItem', item)
      .pipe(
        map(o => {
          return true;
        }),
        catchError(e => {
          return of(false);
        })
      ).toPromise()
  }

  UpdateArrayCalendarItems(items: CalendarItem[]) {
    let notUpdate: boolean = false;

    items.forEach(item => {
      if (item.FechaProgramada !== null) {
        item.Estatus |= statusProcesoProduccion.Programada;
        item.MaquinaId = this.MaquinaId;
      } else {
        notUpdate = true;
      }
    });

    if (!notUpdate) {
      return this.httpClient.post('api/updatePrioridadCalendarItem', items)
        .pipe(
          map(o => {
            return true;
          }),
          catchError(e => {
            return of(false);
          })
        ).toPromise()
    } else {
      return of(true).toPromise()
    }

  }

  CleanDataOrder() {
    this.detailsOT.next(null);
  }
  UpdateDataOrder(ot: string) {
    return this.httpClient.get<OrderData>('api/progresoOT', { params: { OT: ot } })
      .toPromise()
      .then(dt => {

        this.detailsOT.next(dt);
      })
      .catch(err => console.log(err))
      .finally()
  }

  public addDayToDate(date: Date, daysToAdd: number) {
    return moment(date).add(daysToAdd, 'day').toDate();  // new Date(date.setDate(date.getDate() + daysToAdd));
  }

}
