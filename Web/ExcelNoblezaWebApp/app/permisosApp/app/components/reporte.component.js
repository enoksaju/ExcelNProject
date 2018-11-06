"use strict";
var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
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
var router_1 = require("@angular/router");
var trabajador_service_1 = require("../../../common/Services/trabajador.service");
var collections_1 = require("@angular/cdk/collections");
var Observable_1 = require("rxjs/Observable");
var material_1 = require("@angular/material");
var converter_service_1 = require("../../../common/Services/converter.service");
var ReporteComponent = /** @class */ (function () {
    function ReporteComponent(Router, trabajadorService, converterService) {
        this.Router = Router;
        this.trabajadorService = trabajadorService;
        this.converterService = converterService;
        this.displayedColumns = ['Clave', 'Folio', 'Dia1', 'Dia2', 'Dia3', 'Dia4', 'Dia5', 'Dia6', 'Dia7', 'Dia8', 'Dia9', 'Dia10', 'Concepto', 'Estatus', 'Validado', 'Comentarios'];
    }
    ;
    ReporteComponent.prototype.ngOnInit = function () {
        this.dataReport = new trabajador_service_1.DataReport();
        this.dataReport.Fecha = this.ultimoMartes();
        this.DateSearch = this.getShortFechaString(this.dataReport.Fecha);
        this.dataReport.Estatus = trabajador_service_1.Estatus.Nuevo;
        this.dataSource = new ReporteDataSource(this.trabajadorService, this.sort, this.dataReport);
    };
    ;
    ReporteComponent.prototype.setDataReportFecha = function (searchFecha) {
        this.dataReport.Fecha = (searchFecha + " 00:00:00").toDate("yyyy-mm-dd hh-ii-ss");
    };
    ReporteComponent.prototype.getDateforDay = function (days) {
        var d = this.dataReport.Fecha.plusToDate("day", days), ret = [];
        ret.push((d.getDate() < 10 ? '0' : '') + d.getDate());
        ret.push(d.getMonthName()); //((d.getMonth() + 1) < 10 ? '0' : '') + (d.getMonth() + 1)) 
        ret.push(d.getFullYear().toString());
        return ret;
    };
    ReporteComponent.prototype.downloadExcel = function (table) {
        var t = this.converterService.toXls(document.getElementsByClassName(table)[0], "Prueba"), dwn = document.createElement("a"), dt = this.dataReport.Fecha;
        dwn.href = t;
        dwn.setAttribute('download', "Reporte Permisos " + dt.getDay() + " " + dt.getMonthName() + " " + dt.getFullYear() + ".xls");
        dwn.click();
    };
    ;
    ReporteComponent.prototype.getShortFechaString = function (date) {
        var d = date;
        var ret = d.getFullYear() + "-" + ((d.getMonth() + 1) < 10 ? '0' : '') + (d.getMonth() + 1) + '-' + (d.getDate() < 10 ? '0' : '') + d.getDate();
        return ret;
    };
    ReporteComponent.prototype.ultimoMartes = function () {
        var now = new Date();
        var day = now.getDay();
        var t = function (o) {
            switch (o) {
                case 0:
                    return 5;
                case 1:
                    return 6;
                case 2:
                    return 7;
                default:
                    return day - 3;
            }
        };
        return new Date(new Date().setDate(now.getDate() - t(day)));
    };
    __decorate([
        core_1.ViewChild(material_1.MatSort),
        __metadata("design:type", material_1.MatSort)
    ], ReporteComponent.prototype, "sort", void 0);
    __decorate([
        core_1.ViewChild(material_1.MatTable),
        __metadata("design:type", material_1.MatTable)
    ], ReporteComponent.prototype, "table", void 0);
    ReporteComponent = __decorate([
        core_1.Component({
            selector: 'reporte-page',
            templateUrl: './reporte.component.html',
            styleUrls: ['./reporte.component.css']
        }),
        __metadata("design:paramtypes", [router_1.Router, trabajador_service_1.TrabajadorService, converter_service_1.ConverterService])
    ], ReporteComponent);
    return ReporteComponent;
}());
exports.ReporteComponent = ReporteComponent;
var ReporteDataSource = /** @class */ (function (_super) {
    __extends(ReporteDataSource, _super);
    function ReporteDataSource(trabajadorService, sort, dataReport) {
        var _this = _super.call(this) || this;
        _this.trabajadorService = trabajadorService;
        _this.sort = sort;
        _this.dataReport = dataReport;
        _this.resultLength = 0;
        _this.isLoadingResults = false;
        _this.isRateLimitReached = false;
        return _this;
    }
    ReporteDataSource.prototype.connect = function () {
        var _this = this;
        var displayDataChanges = [
            this.sort.sortChange,
            this.dataReport.changeValues
        ];
        return Observable_1.Observable.merge.apply(Observable_1.Observable, displayDataChanges).startWith(null)
            .switchMap(function () {
            _this.isLoadingResults = true;
            return _this.trabajadorService.GetReportPermisos(_this.dataReport);
        })
            .map(function (data) {
            _this.isLoadingResults = false;
            _this.isRateLimitReached = false;
            _this.resultLength = data.length;
            return data; /// Resultados
        })
            .catch(function (e) {
            console.error(e);
            _this.isLoadingResults = false;
            _this.isRateLimitReached = true;
            return Observable_1.Observable.of([]);
        });
        // return null;
    };
    ;
    ReporteDataSource.prototype.disconnect = function () { };
    ;
    return ReporteDataSource;
}(collections_1.DataSource));
//# sourceMappingURL=reporte.component.js.map