import { Component, OnInit, Input } from "@angular/core";
import { ObservableMedia } from "@angular/flex-layout";
import { Headers, Http, RequestOptions } from "@angular/http";
import { FormControl, Validators, FormGroup, AbstractControl, FormArray } from '@angular/forms';
import { TrabajadorService, Turnos, DiasDescanso, Tipos, CapturPermiso } from '../../../common/Services/trabajador.service';
import { DialogsService } from '../../../common/Services/dialog.service';
import { MatStepper } from '@angular/material'

import 'rxjs/add/observable/of';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/debounceTime';
import 'rxjs/add/operator/distinctUntilChanged';
import 'rxjs/add/operator/switchMap';

import { Observable } from 'rxjs/Observable';
import { Subject } from 'rxjs/Subject';

function HourMin(min: string = "", Turno: Turnos) {
  return (c: AbstractControl) => {
    let HOUR_REGEXP = /([01]?[0-9]|2[0-3]):[0-5][0-9]$/
    return HOUR_REGEXP.test(min) &&
      HOUR_REGEXP.test(c.value) &&
      String(c.value).toDate("hh:ii") >= min.toDate("hh:ii")
        .plusToDate("day", (Turno == Turnos.Tercero ? -1 : 0))
      ? null : {
        HourMin: true
      };
  }
}
function HourMax(max: string = "", Turno: Turnos) {
  return (c: AbstractControl) => {
    let HOUR_REGEXP = /([01]?[0-9]|2[0-3]):[0-5][0-9]$/
    return HOUR_REGEXP.test(max) &&
      HOUR_REGEXP.test(c.value) &&
      String(c.value).toDate("hh:ii") <= max.toDate("hh:ii")
        .plusToDate("day", (Turno == Turnos.Tercero ? 1 : 0))
      ? null : {
        HourMax: true
      };
  }
}
function minDate(min: string = "") {
  return (c: AbstractControl) => {
    let HOUR_REGEXP = /[0-9]{4}-(0[1-9]|1[0-2])-(0[1-9]|[1-2][0-9]|3[0-1])$/
    return HOUR_REGEXP.test(min) &&
      HOUR_REGEXP.test(c.value) &&
      String(c.value).toDate("yyyy-mm-dd") > min.toDate("yyyy-mm-dd")
      ? null : {
        minDate: true
      };
  }
}

@Component({
  selector: "solicitar-page",
  templateUrl: "./solicitar.component.html",
  styleUrls: ["./solicitar.component.css"],
  styles: []
})
export class SolicitarComponent implements OnInit {
  private searchTerms = new Subject<string>();
  private searchMotivos = new Subject<string>();

  trabajador$: Observable<any>;
  motivos$: Observable<any[]>;
  diasDescanso: any[] = [];
  turnos: any[] = [];
  tipos: any[] = [];
  motivos: any[] = [];
  loadingTrabajador: boolean = false;
  getPermiso: boolean = false;
  //
  minIniHour: string = "06:00";
  minFinHour: string = "06:00";
  maxHour: string = "14:00";
  minDate: string = this.getShortFechaString();
  valTurno: Turnos = Turnos.Primero;
  //
  getShortFechaString(): string {
    var d = new Date();
    var ret = d.getFullYear() + "-" + ((d.getMonth() + 1) < 10 ? '0' : '') + (d.getMonth() + 1) + '-' + (d.getDate() < 10 ? '0' : '') + d.getDate();
    return ret;
  }
  getHoraString(value: string): string {
    return value.toDate("hh:ii")
      .toLocaleTimeString('ex-MX', {
        hour: 'numeric',
        minute: 'numeric',
        hour12: true
      });
  }
  // Genero el Formulario y el array con Grupos
  array = new FormArray([
    new FormGroup({ // Grupo Trabajador
      Clave: new FormControl(null, [Validators.required]),
      Email: new FormControl(null, [Validators.required, Validators.email]),
      Linea: new FormControl(null),
      Nombre: new FormControl(null)
    }),
    new FormGroup({ //Grupo Tiempo
      Turno: new FormControl(1, [Validators.required]),
      Tipo: new FormControl(1, [Validators.required]),
      Inicio: new FormControl(this.getShortFechaString(), [Validators.required]),
      HoraIni: new FormControl("06:00", [
        Validators.required,
        (control: AbstractControl) => HourMin(this.minIniHour, this.valTurno)(control),
        (control: AbstractControl) => HourMax(this.maxHour, this.valTurno)(control)
      ]),
      Fin: new FormControl(this.getShortFechaString(), [
        Validators.required,
        (control: AbstractControl) => minDate(this.minDate)(control)
      ]),
      HoraFin: new FormControl("14:00", [
        Validators.required,
        (control: AbstractControl) => HourMin(this.minFinHour, this.valTurno)(control),
        (control: AbstractControl) => HourMax(this.maxHour, this.valTurno)(control)
      ]),
    }),
    new FormGroup({ // Grupo Motivo y Comentarios
      DiaDescanso: new FormControl(7, [Validators.required]),
      Motivo: new FormControl(null, [Validators.required]),
      Comentarios: new FormControl(null, [Validators.maxLength(250)])
    })
  ]);
  tryForm = new FormGroup({
    array: this.array
  });
  /**
   * Funcion que se desencadena al presionar una tecla en el campo clave del formulario
   */
  claveChange(value: any): void {
    this.loadingTrabajador = true;

    this.array.get('2.Motivo').reset(null);
    this.array.get('2.Motivo').updateValueAndValidity();

    this.searchTerms.next(value);
    this.searchMotivos.next(value);

    this.motivos$.subscribe(e => {
      this.motivos = e;
    })

    this.trabajador$.subscribe(e => {
      this.array.get('0.Email').setValue(e.Email);
      this.array.get('0.Linea').setValue(e.NombreLinea);
      this.array.get('0.Nombre').setValue(e.Nombre ? e.Nombre + " " + e.ApellidoPaterno + " " + e.ApellidoMaterno : '');
      this.loadingTrabajador = false;
    });
  }
  changeTurno(e: any): void {
    this.valTurno = e.value;
    switch (e.value) {
      case Turnos.Primero:
        this.maxHour = "14:00";
        this.minIniHour = "06:00";
        this.array.get([1]).get('HoraIni').setValue("06:00");
        this.array.get([1]).get('HoraFin').setValue("14:00");
        //frm.controls.HoraIni.setValue("06:00");
        //frm.controls.HoraFin.setValue("14:00");
        break;
      case Turnos.Segundo:
        this.maxHour = "21:30";
        this.minIniHour = "14:00";
        this.array.get([1]).get('HoraIni').setValue("14:00");
        this.array.get([1]).get('HoraFin').setValue("21:30");
        //frm.controls.HoraIni.setValue("14:00");
        //frm.controls.HoraFin.setValue("21:30");
        break;
      case Turnos.Tercero:
        this.maxHour = "06:00";
        this.minIniHour = "21:30";
        this.array.get([1]).get('HoraIni').setValue("21:30");
        this.array.get([1]).get('HoraFin').setValue("06:00");
        //frm.controls.HoraIni.setValue("21:30");
        //frm.controls.HoraFin.setValue("06:00");
        break;
      case Turnos.Mixto:
        this.maxHour = "17:30";
        this.minIniHour = "9:00";
        this.array.get([1]).get('HoraIni').setValue("09:00");
        this.array.get([1]).get('HoraFin').setValue("17:30");
        //frm.controls.HoraIni.setValue("09:00");
        //frm.controls.HoraFin.setValue("17:30");
        break;
    }
  }
  changeTipo(e: any): void {
    var ctrls = this.array.get([1]);
    switch (e.value) {
      case Tipos.PorHoras:
        ctrls.get('HoraIni').enable();
        ctrls.get('HoraFin').enable();
        ctrls.get('Fin').disable();
        break;
      case Tipos.UnDia:
        ctrls.get('HoraIni').disable();
        ctrls.get('HoraFin').disable();
        ctrls.get('Fin').disable();
        break;
      case Tipos.VariosDias:
        ctrls.get('HoraIni').disable();
        ctrls.get('HoraFin').disable();
        ctrls.get('Fin').enable();
        break;
    }
  }
  changeHourIni(value: string): void {
    this.minFinHour = value;
    this.array.get([1]).get('HoraFin').updateValueAndValidity();
  }
  setMinDate(value: string): void {
    this.minDate = value;
    this.array.get([1]).get('Fin').updateValueAndValidity();
  }
  /**
   * Funcion que envia el formulario al servidor
   * @param frm
   */
  onSubmit(frm: FormGroup, stepper: MatStepper, frm_: HTMLFormElement): void {
    this.tryForm.updateValueAndValidity();
    if (frm.valid) {

      this.dialogService.confirm("Confirme", "Desea solicitar el permiso?", "Si, Solicitar").subscribe(t => {
        if (t) {
          this.getPermiso = true;
          this.trabajadorService.SolicitarPermiso(new CapturPermiso(
            this.array.get('0.Clave').value,
            this.array.get('0.Email').value,
            (this.array.get('1.Inicio').value + ' ' + this.array.get('1.HoraIni').value).toDate("yyyy-mm-dd hh:ii"),
            (this.array.get('1.Fin').value + ' ' + this.array.get('1.HoraFin').value).toDate("yyyy-mm-dd hh:ii"),
            this.array.get('1.Tipo').value,
            this.array.get('1.Turno').value,
            this.array.get('2.Motivo').value,
            this.array.get('2.Comentarios').value,
            this.array.get('2.DiaDescanso').value
          )).then(c => {
            console.log(c);
            this.dialogService
              .confirm("Confirme", "El folio del permiso solicitado es " + c + ".\nDesea Descargar el permiso para su Impresión?", "Si, Descargar")
              .subscribe(o => {
                if (o) {
                  this.trabajadorService.DescargarPDF(c)
                };
                this.resetForm(stepper);
              })  
          }, e=> console.log(e));
        }
      })

    } else {

    }
  }

  private resetForm(stepper: MatStepper): void {
    this.getPermiso = false;
    this.array.get('1.HoraIni').enable();
    this.array.get('1.HoraFin').enable();
    this.array.get('1.Fin').disable();
    stepper._steps.forEach((v, i) => {
      switch (i) {
        case 0:
          v.stepControl.reset();
          v.select();
          break;
        case 1:
          v.stepControl.reset({
            Turno: 1,
            Tipo: 1,
            Inicio: this.getShortFechaString(),
            Fin: this.getShortFechaString(),
            HoraIni: "06:00",
            HoraFin: "14:00"
          });
          break;
        case 2:
          v.stepControl.reset({
            DiaDescanso: 7,
            Motivo: null,
            Comentarios: null
          });
          break;
      }
    })
  }
  /**
   * Construyo el componente
   * @param media
   * @param http
   * @param trabajadorService
   */
  constructor(public media: ObservableMedia, private http: Http, private trabajadorService: TrabajadorService, private dialogService: DialogsService) {
    var t = Turnos;
    var d = DiasDescanso;
    var tip = Tipos;
    //this.keys = this.getEnumValues(t);
    this.diasDescanso = this.getEnumValues(d);
    this.turnos = this.getEnumValues(t);
    this.tipos = this.getEnumValues(tip);
  }

  /**
   * Inicio el Componente
   */
  ngOnInit(): void {

    // Crear El vinculo del Observable para la busqueda del trabajador
    this.trabajador$ = this.searchTerms
      .debounceTime(500)
      .distinctUntilChanged()
      .switchMap(term => term ? this.trabajadorService.search(term) : Observable.of<any>({}))
      .catch(error => { return Observable.of<any>({}); });

    this.motivos$ = this.searchMotivos
      .debounceTime(500)
      .distinctUntilChanged()
      .switchMap(t => t ? this.trabajadorService.motivosPermiso(t) : Observable.of<any>([]))
      .catch(e => {
        return Observable.of<any>([]);
      });

    this.array.get([1]).get('Fin').disable();
  }
  private getEnumValues(_enum: any): any[] {
    //return Object.keys(_enum).filter(k => !isNaN(Number(k)));
    var r: any[] = [];
    var obj = Object.keys(_enum);
    var values = obj.filter(u => isNaN(Number(u)));
    obj.filter(u => !isNaN(Number(u)))
      .forEach((v, i) => {
        r.push({ value: Number(v), label: values[i] });
      });
    return r;
  }
}


