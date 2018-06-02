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
var TIPOS;
(function (TIPOS) {
    TIPOS[TIPOS["PELICULA"] = 0] = "PELICULA";
    TIPOS[TIPOS["PELICULALAMINADA"] = 1] = "PELICULALAMINADA";
    TIPOS[TIPOS["PELICULATRILAMINADA"] = 2] = "PELICULATRILAMINADA";
    TIPOS[TIPOS["FLOWPACKLAMINADA"] = 3] = "FLOWPACKLAMINADA";
    TIPOS[TIPOS["FLOWPACKTRILAMINADA"] = 4] = "FLOWPACKTRILAMINADA";
    TIPOS[TIPOS["SELLOLATERALNOIMPRESA"] = 5] = "SELLOLATERALNOIMPRESA";
    TIPOS[TIPOS["SELLOLATERALIMPRESA"] = 6] = "SELLOLATERALIMPRESA";
    TIPOS[TIPOS["SELLOLATERALLAMINADANOIMPRESA"] = 7] = "SELLOLATERALLAMINADANOIMPRESA";
    TIPOS[TIPOS["SELLOLATERALLAMINADAIMPRESA"] = 8] = "SELLOLATERALLAMINADAIMPRESA";
    TIPOS[TIPOS["SELLOLATERALTRILAMINADA"] = 9] = "SELLOLATERALTRILAMINADA";
    TIPOS[TIPOS["OTRO"] = 10] = "OTRO";
    TIPOS[TIPOS["ETIQUETA"] = 11] = "ETIQUETA";
    TIPOS[TIPOS["PVC"] = 12] = "PVC";
    TIPOS[TIPOS["PROTOTIPOS"] = 13] = "PROTOTIPOS";
    TIPOS[TIPOS["PIEZAS"] = 14] = "PIEZAS";
    TIPOS[TIPOS["ETIQUETATIPOMANGA"] = 15] = "ETIQUETATIPOMANGA";
    TIPOS[TIPOS["BOLSATUBULAR"] = 16] = "BOLSATUBULAR";
})(TIPOS = exports.TIPOS || (exports.TIPOS = {}));
var TIPOSIMPRESION;
(function (TIPOSIMPRESION) {
    TIPOSIMPRESION[TIPOSIMPRESION["PIE"] = 1] = "PIE";
    TIPOSIMPRESION[TIPOSIMPRESION["CABEZA"] = 2] = "CABEZA";
    TIPOSIMPRESION[TIPOSIMPRESION["PORDENTRO"] = 3] = "PORDENTRO";
    TIPOSIMPRESION[TIPOSIMPRESION["PORFUERA"] = 4] = "PORFUERA";
    TIPOSIMPRESION[TIPOSIMPRESION["REPETICION"] = 5] = "REPETICION";
    TIPOSIMPRESION[TIPOSIMPRESION["PIEDEIMPRESI\u00D3N"] = 6] = "PIEDEIMPRESI\u00D3N";
})(TIPOSIMPRESION = exports.TIPOSIMPRESION || (exports.TIPOSIMPRESION = {}));
var Procesos;
(function (Procesos) {
    Procesos[Procesos["Corte"] = 0] = "Corte";
    Procesos[Procesos["Doblado"] = 1] = "Doblado";
    Procesos[Procesos["Embobinado"] = 2] = "Embobinado";
    Procesos[Procesos["Extrusion"] = 3] = "Extrusion";
    Procesos[Procesos["Impresion"] = 4] = "Impresion";
    Procesos[Procesos["Laminacion"] = 5] = "Laminacion";
    Procesos[Procesos["Mangas"] = 6] = "Mangas";
    Procesos[Procesos["Refinado"] = 7] = "Refinado";
    Procesos[Procesos["Sellado"] = 8] = "Sellado";
    Procesos[Procesos["Todas"] = 9] = "Todas";
})(Procesos = exports.Procesos || (exports.Procesos = {}));
var GetOTModel = /** @class */ (function () {
    function GetOTModel() {
        this.OrderNumber = '';
        this.Proceso = Procesos.Todas;
    }
    return GetOTModel;
}());
exports.GetOTModel = GetOTModel;
var infoOT = /** @class */ (function () {
    function infoOT() {
    }
    infoOT.prototype.OtImpresa = function () {
        return (this.ESIMPRESO == "True" ? true : false);
    };
    return infoOT;
}());
exports.infoOT = infoOT;
var OTService = /** @class */ (function () {
    function OTService(http, _sanitizer) {
        this.http = http;
        this._sanitizer = _sanitizer;
        this.headers = new http_1.Headers({ 'Content-Type': 'application/json' });
    }
    OTService.prototype.handleError = function (error) {
        return Promise.reject(JSON.parse(error._body) || error);
    };
    OTService.prototype.verOt = function (data) {
        return this.http.post('../../../../../../../../../../api/OrdenTrabajo/ver', data)
            .toPromise()
            .then(function (res) { return res.json(); })
            .catch(this.handleError);
    };
    OTService = __decorate([
        core_1.Injectable(),
        __metadata("design:paramtypes", [http_1.Http, platform_browser_1.DomSanitizer])
    ], OTService);
    return OTService;
}());
exports.OTService = OTService;
//# sourceMappingURL=ot.service.js.map