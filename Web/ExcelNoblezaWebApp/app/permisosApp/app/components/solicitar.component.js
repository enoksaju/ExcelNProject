"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var flex_layout_1 = require("@angular/flex-layout");
var http_1 = require("@angular/http");
var forms_1 = require("@angular/forms");
var trabajador_service_1 = require("../../../common/Services/trabajador.service");
var dialog_service_1 = require("../../../common/Services/dialog.service");
require("rxjs/add/observable/of");
require("rxjs/add/operator/catch");
require("rxjs/add/operator/debounceTime");
require("rxjs/add/operator/distinctUntilChanged");
require("rxjs/add/operator/switchMap");
var Observable_1 = require("rxjs/Observable");
var Subject_1 = require("rxjs/Subject");
function HourMin(min, Turno) {
    if (min === void 0) { min = ""; }
    return function (c) {
        var HOUR_REGEXP = /([01]?[0-9]|2[0-3]):[0-5][0-9]$/;
        return HOUR_REGEXP.test(min) &&
            HOUR_REGEXP.test(c.value) &&
            String(c.value).toDate("hh:ii") >= min.toDate("hh:ii")
                .plusToDate("day", (Turno == trabajador_service_1.Turnos.Tercero ? -1 : 0))
            ? null : {
            HourMin: true
        };
    };
}
function HourMax(max, Turno) {
    if (max === void 0) { max = ""; }
    return function (c) {
        var HOUR_REGEXP = /([01]?[0-9]|2[0-3]):[0-5][0-9]$/;
        return HOUR_REGEXP.test(max) &&
            HOUR_REGEXP.test(c.value) &&
            String(c.value).toDate("hh:ii") <= max.toDate("hh:ii")
                .plusToDate("day", (Turno == trabajador_service_1.Turnos.Tercero ? 1 : 0))
            ? null : {
            HourMax: true
        };
    };
}
function minDate(min) {
    if (min === void 0) { min = ""; }
    return function (c) {
        var HOUR_REGEXP = /[0-9]{4}-(0[1-9]|1[0-2])-(0[1-9]|[1-2][0-9]|3[0-1])$/;
        return HOUR_REGEXP.test(min) &&
            HOUR_REGEXP.test(c.value) &&
            String(c.value).toDate("yyyy-mm-dd") > min.toDate("yyyy-mm-dd")
            ? null : {
            minDate: true
        };
    };
}
var SolicitarComponent = /** @class */ (function () {
    /**
     * Construyo el componente
     * @param media
     * @param http
     * @param trabajadorService
     */
    function SolicitarComponent(media, http, trabajadorService, dialogService) {
        var _this = this;
        this.media = media;
        this.http = http;
        this.trabajadorService = trabajadorService;
        this.dialogService = dialogService;
        this.searchTerms = new Subject_1.Subject();
        this.searchMotivos = new Subject_1.Subject();
        this.diasDescanso = [];
        this.turnos = [];
        this.tipos = [];
        this.motivos = [];
        this.loadingTrabajador = false;
        this.getPermiso = false;
        //
        this.minIniHour = "06:00";
        this.minFinHour = "06:00";
        this.maxHour = "14:00";
        this.minDate = this.getShortFechaString();
        this.valTurno = trabajador_service_1.Turnos.Primero;
        // Genero el Formulario y el array con Grupos
        this.array = new forms_1.FormArray([
            new forms_1.FormGroup({
                Clave: new forms_1.FormControl(null, [forms_1.Validators.required]),
                Email: new forms_1.FormControl(null, [forms_1.Validators.required, forms_1.Validators.email]),
                Linea: new forms_1.FormControl(null),
                Nombre: new forms_1.FormControl(null)
            }),
            new forms_1.FormGroup({
                Turno: new forms_1.FormControl(1, [forms_1.Validators.required]),
                Tipo: new forms_1.FormControl(1, [forms_1.Validators.required]),
                Inicio: new forms_1.FormControl(this.getShortFechaString(), [forms_1.Validators.required]),
                HoraIni: new forms_1.FormControl("06:00", [
                    forms_1.Validators.required,
                    function (control) { return HourMin(_this.minIniHour, _this.valTurno)(control); },
                    function (control) { return HourMax(_this.maxHour, _this.valTurno)(control); }
                ]),
                Fin: new forms_1.FormControl(this.getShortFechaString(), [
                    forms_1.Validators.required,
                    function (control) { return minDate(_this.minDate)(control); }
                ]),
                HoraFin: new forms_1.FormControl("14:00", [
                    forms_1.Validators.required,
                    function (control) { return HourMin(_this.minFinHour, _this.valTurno)(control); },
                    function (control) { return HourMax(_this.maxHour, _this.valTurno)(control); }
                ]),
            }),
            new forms_1.FormGroup({
                DiaDescanso: new forms_1.FormControl(7, [forms_1.Validators.required]),
                Motivo: new forms_1.FormControl(null, [forms_1.Validators.required]),
                Comentarios: new forms_1.FormControl(null, [forms_1.Validators.maxLength(250)])
            })
        ]);
        this.tryForm = new forms_1.FormGroup({
            array: this.array
        });
        var t = trabajador_service_1.Turnos;
        var d = trabajador_service_1.DiasDescanso;
        var tip = trabajador_service_1.Tipos;
        //this.keys = this.getEnumValues(t);
        this.diasDescanso = this.getEnumValues(d);
        this.turnos = this.getEnumValues(t);
        this.tipos = this.getEnumValues(tip);
    }
    //
    SolicitarComponent.prototype.getShortFechaString = function () {
        var d = new Date();
        var ret = d.getFullYear() + "-" + ((d.getMonth() + 1) < 10 ? '0' : '') + (d.getMonth() + 1) + '-' + (d.getDate() < 10 ? '0' : '') + d.getDate();
        return ret;
    };
    SolicitarComponent.prototype.getHoraString = function (value) {
        return value.toDate("hh:ii")
            .toLocaleTimeString('ex-MX', {
            hour: 'numeric',
            minute: 'numeric',
            hour12: true
        });
    };
    /**
     * Funcion que se desencadena al presionar una tecla en el campo clave del formulario
     */
    SolicitarComponent.prototype.claveChange = function (value) {
        var _this = this;
        this.loadingTrabajador = true;
        this.array.get('2.Motivo').reset(null);
        this.array.get('2.Motivo').updateValueAndValidity();
        this.searchTerms.next(value);
        this.searchMotivos.next(value);
        this.motivos$.subscribe(function (e) {
            _this.motivos = e;
        });
        this.trabajador$.subscribe(function (e) {
            _this.array.get('0.Email').setValue(e.Email);
            _this.array.get('0.Linea').setValue(e.NombreLinea);
            _this.array.get('0.Nombre').setValue(e.Nombre ? e.Nombre + " " + e.ApellidoPaterno + " " + e.ApellidoMaterno : '');
            _this.loadingTrabajador = false;
        });
    };
    SolicitarComponent.prototype.changeTurno = function (e) {
        this.valTurno = e.value;
        switch (e.value) {
            case trabajador_service_1.Turnos.Primero:
                this.maxHour = "14:00";
                this.minIniHour = "06:00";
                this.array.get([1]).get('HoraIni').setValue("06:00");
                this.array.get([1]).get('HoraFin').setValue("14:00");
                //frm.controls.HoraIni.setValue("06:00");
                //frm.controls.HoraFin.setValue("14:00");
                break;
            case trabajador_service_1.Turnos.Segundo:
                this.maxHour = "21:30";
                this.minIniHour = "14:00";
                this.array.get([1]).get('HoraIni').setValue("14:00");
                this.array.get([1]).get('HoraFin').setValue("21:30");
                //frm.controls.HoraIni.setValue("14:00");
                //frm.controls.HoraFin.setValue("21:30");
                break;
            case trabajador_service_1.Turnos.Tercero:
                this.maxHour = "06:00";
                this.minIniHour = "21:30";
                this.array.get([1]).get('HoraIni').setValue("21:30");
                this.array.get([1]).get('HoraFin').setValue("06:00");
                //frm.controls.HoraIni.setValue("21:30");
                //frm.controls.HoraFin.setValue("06:00");
                break;
            case trabajador_service_1.Turnos.Mixto:
                this.maxHour = "17:30";
                this.minIniHour = "9:00";
                this.array.get([1]).get('HoraIni').setValue("09:00");
                this.array.get([1]).get('HoraFin').setValue("17:30");
                //frm.controls.HoraIni.setValue("09:00");
                //frm.controls.HoraFin.setValue("17:30");
                break;
        }
    };
    SolicitarComponent.prototype.changeTipo = function (e) {
        var ctrls = this.array.get([1]);
        switch (e.value) {
            case trabajador_service_1.Tipos.PorHoras:
                ctrls.get('HoraIni').enable();
                ctrls.get('HoraFin').enable();
                ctrls.get('Fin').disable();
                break;
            case trabajador_service_1.Tipos.UnDia:
                ctrls.get('HoraIni').disable();
                ctrls.get('HoraFin').disable();
                ctrls.get('Fin').disable();
                break;
            case trabajador_service_1.Tipos.VariosDias:
                ctrls.get('HoraIni').disable();
                ctrls.get('HoraFin').disable();
                ctrls.get('Fin').enable();
                break;
        }
    };
    SolicitarComponent.prototype.changeHourIni = function (value) {
        this.minFinHour = value;
        this.array.get([1]).get('HoraFin').updateValueAndValidity();
    };
    SolicitarComponent.prototype.setMinDate = function (value) {
        this.minDate = value;
        this.array.get([1]).get('Fin').updateValueAndValidity();
    };
    /**
     * Funcion que envia el formulario al servidor
     * @param frm
     */
    SolicitarComponent.prototype.onSubmit = function (frm, stepper, frm_) {
        var _this = this;
        this.tryForm.updateValueAndValidity();
        if (frm.valid) {
            this.dialogService.confirm("Confirme", "Desea solicitar el permiso?", "Si, Solicitar").subscribe(function (t) {
                if (t) {
                    _this.getPermiso = true;
                    _this.trabajadorService.SolicitarPermiso(new trabajador_service_1.CapturPermiso(_this.array.get('0.Clave').value, _this.array.get('0.Email').value, (_this.array.get('1.Inicio').value + ' ' + _this.array.get('1.HoraIni').value).toDate("yyyy-mm-dd hh:ii"), (_this.array.get('1.Fin').value + ' ' + _this.array.get('1.HoraFin').value).toDate("yyyy-mm-dd hh:ii"), _this.array.get('1.Tipo').value, _this.array.get('1.Turno').value, _this.array.get('2.Motivo').value, _this.array.get('2.Comentarios').value, _this.array.get('2.DiaDescanso').value)).then(function (c) {
                        console.log(c);
                        _this.dialogService
                            .confirm("Confirme", "El folio del permiso solicitado es " + c + ".\nDesea Descargar el permiso para su Impresión?", "Si, Descargar")
                            .subscribe(function (o) {
                            if (o) {
                                _this.trabajadorService.DescargarPDF(c);
                            }
                            ;
                            _this.resetForm(stepper);
                        });
                    }, function (e) { return console.log(e); });
                }
            });
        }
        else {
        }
    };
    SolicitarComponent.prototype.resetForm = function (stepper) {
        var _this = this;
        this.getPermiso = false;
        this.array.get('1.HoraIni').enable();
        this.array.get('1.HoraFin').enable();
        this.array.get('1.Fin').disable();
        stepper._steps.forEach(function (v, i) {
            switch (i) {
                case 0:
                    v.stepControl.reset();
                    v.select();
                    break;
                case 1:
                    v.stepControl.reset({
                        Turno: 1,
                        Tipo: 1,
                        Inicio: _this.getShortFechaString(),
                        Fin: _this.getShortFechaString(),
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
        });
    };
    /**
     * Inicio el Componente
     */
    SolicitarComponent.prototype.ngOnInit = function () {
        var _this = this;
        // Crear El vinculo del Observable para la busqueda del trabajador
        this.trabajador$ = this.searchTerms
            .debounceTime(500)
            .distinctUntilChanged()
            .switchMap(function (term) { return term ? _this.trabajadorService.search(term) : Observable_1.Observable.of({}); })
            .catch(function (error) { return Observable_1.Observable.of({}); });
        this.motivos$ = this.searchMotivos
            .debounceTime(500)
            .distinctUntilChanged()
            .switchMap(function (t) { return t ? _this.trabajadorService.motivosPermiso(t) : Observable_1.Observable.of([]); })
            .catch(function (e) {
            return Observable_1.Observable.of([]);
        });
        this.array.get([1]).get('Fin').disable();
    };
    SolicitarComponent.prototype.getEnumValues = function (_enum) {
        //return Object.keys(_enum).filter(k => !isNaN(Number(k)));
        var r = [];
        var obj = Object.keys(_enum);
        var values = obj.filter(function (u) { return isNaN(Number(u)); });
        obj.filter(function (u) { return !isNaN(Number(u)); })
            .forEach(function (v, i) {
            r.push({ value: Number(v), label: values[i] });
        });
        return r;
    };
    SolicitarComponent = __decorate([
        core_1.Component({
            selector: "solicitar-page",
            templateUrl: "./solicitar.component.html",
            styleUrls: ["./solicitar.component.css"],
            styles: []
        }),
        __metadata("design:paramtypes", [flex_layout_1.ObservableMedia, http_1.Http, trabajador_service_1.TrabajadorService, dialog_service_1.DialogsService])
    ], SolicitarComponent);
    return SolicitarComponent;
}());
exports.SolicitarComponent = SolicitarComponent;
//# sourceMappingURL=solicitar.component.js.map