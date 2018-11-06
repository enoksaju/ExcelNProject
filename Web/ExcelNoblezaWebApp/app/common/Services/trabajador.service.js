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
var http_1 = require("@angular/http");
var platform_browser_1 = require("@angular/platform-browser");
require("rxjs/add/operator/map");
var DiasDescanso;
(function (DiasDescanso) {
    DiasDescanso[DiasDescanso["Lunes"] = 1] = "Lunes";
    DiasDescanso[DiasDescanso["Martes"] = 2] = "Martes";
    DiasDescanso[DiasDescanso["Miercoles"] = 3] = "Miercoles";
    DiasDescanso[DiasDescanso["Jueves"] = 4] = "Jueves";
    DiasDescanso[DiasDescanso["Viernes"] = 5] = "Viernes";
    DiasDescanso[DiasDescanso["Sabado"] = 6] = "Sabado";
    DiasDescanso[DiasDescanso["Domingo"] = 7] = "Domingo";
})(DiasDescanso = exports.DiasDescanso || (exports.DiasDescanso = {}));
var Turnos;
(function (Turnos) {
    Turnos[Turnos["Primero"] = 1] = "Primero";
    Turnos[Turnos["Segundo"] = 2] = "Segundo";
    Turnos[Turnos["Tercero"] = 3] = "Tercero";
    Turnos[Turnos["Mixto"] = 4] = "Mixto";
})(Turnos = exports.Turnos || (exports.Turnos = {}));
var Tipos;
(function (Tipos) {
    Tipos[Tipos["PorHoras"] = 1] = "PorHoras";
    Tipos[Tipos["UnDia"] = 2] = "UnDia";
    Tipos[Tipos["VariosDias"] = 3] = "VariosDias";
})(Tipos = exports.Tipos || (exports.Tipos = {}));
var CapturPermiso = /** @class */ (function () {
    function CapturPermiso(Clave, Email, Inicio, Fin, Tipo, Turno, MotivoPermiso, Comentario, DiaDescanso) {
        if (Comentario === void 0) { Comentario = ''; }
        if (DiaDescanso === void 0) { DiaDescanso = DiasDescanso.Domingo; }
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
    return CapturPermiso;
}());
exports.CapturPermiso = CapturPermiso;
var TrabajadorService = /** @class */ (function () {
    function TrabajadorService(http, _sanitizer) {
        this.http = http;
        this._sanitizer = _sanitizer;
        this.headers = new http_1.Headers({ 'Content-Type': 'application/json' });
    }
    TrabajadorService.prototype.handleError = function (error) {
        console.error('An error occurred', error);
        return Promise.reject(error.message || error);
    };
    TrabajadorService.prototype.search = function (clave) {
        return this.http.get("../../../../../../../../../api/trabajadores/search/?clave=" + clave)
            .map(function (response) { return response.json(); });
    };
    TrabajadorService.prototype.motivosPermiso = function (clave) {
        return this.http.get('../../../../../../../../../api/trabajadores/getMotivos/' + clave)
            .map(function (response) { return response.json(); });
    };
    TrabajadorService.prototype.SolicitarPermiso = function (datos) {
        return this.http.post('../../../../../../../../api/ApiPermisos/crear', JSON.stringify(datos), { headers: this.headers })
            .toPromise()
            .then(function (res) { return res.json(); })
            .catch(this.handleError);
    };
    TrabajadorService.prototype.DescargarPDF = function (Folio) {
        window.open('../../../../../../../../../../api/apiPermisos/getPermiso/' + Folio, '_blank', '');
    };
    TrabajadorService.prototype.GetPermisoPDFUrl = function (Folio) {
        var _this = this;
        return this.http.get('../../../../../../../../../../api/apiPermisos/getPermiso/' + Folio, { responseType: http_1.ResponseContentType.ArrayBuffer })
            .map(function (response) {
            return _this._sanitizer.bypassSecurityTrustResourceUrl(URL.createObjectURL(new Blob([response.arrayBuffer()], { type: 'application/pdf' })));
        });
    };
    TrabajadorService.prototype.GetReportPermisos = function (data) {
        return this.http.post('../../../../../../../../../../api/apiPermisos/getReportData', data.Data)
            .map(function (response) {
            return response.json();
        });
    };
    TrabajadorService = __decorate([
        core_1.Injectable(),
        __metadata("design:paramtypes", [http_1.Http, platform_browser_1.DomSanitizer])
    ], TrabajadorService);
    return TrabajadorService;
}());
exports.TrabajadorService = TrabajadorService;
var Estatus;
(function (Estatus) {
    Estatus[Estatus["Nuevo"] = 0] = "Nuevo";
    Estatus[Estatus["Cancelado"] = 1] = "Cancelado";
    Estatus[Estatus["Autorizado"] = 2] = "Autorizado";
    Estatus[Estatus["Denegado"] = 3] = "Denegado";
})(Estatus = exports.Estatus || (exports.Estatus = {}));
var DataReport = /** @class */ (function () {
    function DataReport() {
        this.changeValues = new core_1.EventEmitter();
    }
    Object.defineProperty(DataReport.prototype, "Fecha", {
        get: function () {
            return this._fecha;
        },
        set: function (Fecha) {
            this._fecha = Fecha;
            this.changeValues.emit(this);
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(DataReport.prototype, "Estatus", {
        get: function () {
            return this._estatus;
        },
        set: function (Estatus) {
            this._estatus = Estatus;
            this.changeValues.emit(this);
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(DataReport.prototype, "Data", {
        get: function () {
            return { Fecha: this._fecha, Estatus: this._estatus };
        },
        enumerable: true,
        configurable: true
    });
    __decorate([
        core_1.Output(),
        __metadata("design:type", core_1.EventEmitter)
    ], DataReport.prototype, "changeValues", void 0);
    return DataReport;
}());
exports.DataReport = DataReport;
var ResultReport = /** @class */ (function () {
    function ResultReport() {
    }
    return ResultReport;
}());
exports.ResultReport = ResultReport;
//# sourceMappingURL=trabajador.service.js.map