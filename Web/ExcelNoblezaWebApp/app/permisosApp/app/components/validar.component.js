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
var http_1 = require("@angular/http");
var collections_1 = require("@angular/cdk/collections");
var material_1 = require("@angular/material");
var Observable_1 = require("rxjs/Observable");
var dialog_service_1 = require("../../../common/Services/dialog.service");
var permisodetails_service_1 = require("../services/permisodetails.service");
require("rxjs/add/observable/merge");
require("rxjs/add/observable/of");
require("rxjs/add/operator/catch");
require("rxjs/add/operator/map");
require("rxjs/add/operator/startWith");
require("rxjs/add/operator/switchMap");
var ValidarComponent = /** @class */ (function () {
    function ValidarComponent(http, dialogService, permisoDetails) {
        this.http = http;
        this.dialogService = dialogService;
        this.permisoDetails = permisoDetails;
        this.displayedColumns = ['chk', 'details', 'ValidacionId', 'Folio', 'TrabajadorId', 'TipoString', 'MotivoPermisoId', 'Inicio'];
        this.Validacion = new ValidacionClass(this.http);
    }
    ;
    ValidarComponent.prototype.ngOnInit = function () {
        this.Database = new PermisosHttpDAO(this.http);
        this.dataSource = new PermisosDataSource(this.Database, this.paginator, this.sort, this.Validacion);
    };
    ;
    ValidarComponent.prototype.validar = function (tipo) {
        var _this = this;
        this.dialogService.confirm('Confirme', 'Realmente desea ' + tipo + ' los permisos seleccionados?', 'Si, ' + tipo)
            .subscribe(function (c) {
            c && _this.Validacion.Afectar(AfectarTipo[tipo], _this.foliosSeleccionados());
        });
    };
    ;
    ValidarComponent.prototype.foliosSeleccionados = function () {
        var t = this.table['_data'];
        var ret = [];
        t.filter(function (t) { return t.selected; }).forEach(function (v) {
            ret.push(v.Id);
        });
        return ret;
    };
    ValidarComponent.prototype.markAll = function (a) {
        var t = this.table['_data'];
        t.forEach(function (v) {
            v.selected = a.checked;
        });
        console.log(a.checked);
    };
    ValidarComponent.prototype.showDetails = function (p) {
        var _this = this;
        this.permisoDetails.showDetails(p)
            .subscribe(function (result) { return result.accion && _this.Validacion.Afectar(result.accion, result.items); });
    };
    __decorate([
        core_1.ViewChild(material_1.MatPaginator),
        __metadata("design:type", material_1.MatPaginator)
    ], ValidarComponent.prototype, "paginator", void 0);
    __decorate([
        core_1.ViewChild(material_1.MatSort),
        __metadata("design:type", material_1.MatSort)
    ], ValidarComponent.prototype, "sort", void 0);
    __decorate([
        core_1.ViewChild(material_1.MatTable),
        __metadata("design:type", material_1.MatTable)
    ], ValidarComponent.prototype, "table", void 0);
    ValidarComponent = __decorate([
        core_1.Component({
            selector: 'validar-page',
            templateUrl: './validar.component.html',
            styleUrls: ['./validar.component.css']
        }),
        __metadata("design:paramtypes", [http_1.Http, dialog_service_1.DialogsService, permisodetails_service_1.PermisoDetailsService])
    ], ValidarComponent);
    return ValidarComponent;
}());
exports.ValidarComponent = ValidarComponent;
var Validaciones;
(function (Validaciones) {
    Validaciones[Validaciones["Todos"] = 0] = "Todos";
    Validaciones[Validaciones["Correctos"] = 1] = "Correctos";
    Validaciones[Validaciones["FueraDeTiempo"] = 2] = "FueraDeTiempo";
    Validaciones[Validaciones["ParaFechaAnterior"] = 3] = "ParaFechaAnterior";
})(Validaciones || (Validaciones = {}));
var AfectarTipo;
(function (AfectarTipo) {
    AfectarTipo[AfectarTipo["Aprobar"] = 0] = "Aprobar";
    AfectarTipo[AfectarTipo["Denegar"] = 1] = "Denegar";
    AfectarTipo[AfectarTipo["Cancelar"] = 2] = "Cancelar";
})(AfectarTipo || (AfectarTipo = {}));
/**
 * @description PROVEE ACCIONES Y CONTROLES PARA LA VALIDACION DE LOS PERMISOS
 */
var ValidacionClass = /** @class */ (function () {
    function ValidacionClass(http) {
        this.http = http;
        this.validacionChange = new core_1.EventEmitter();
        this.changeValues = new core_1.EventEmitter();
        this._validacion = Validaciones.Todos;
        var v = Validaciones;
        this.validaciones = this.getEnumValues(v);
    }
    Object.defineProperty(ValidacionClass.prototype, "validacion", {
        get: function () {
            return this._validacion;
        },
        set: function (validacion) {
            this._validacion = validacion;
            this.validacionChange.emit(validacion);
        },
        enumerable: true,
        configurable: true
    });
    ValidacionClass.prototype.Afectar = function (Tipo, Items) {
        var _this = this;
        return this.http.post('../../../../../../../../../../api/apiPermisos/afectar', { accion: Tipo, folios: Items })
            .toPromise()
            .then(function (response) {
            _this.changeValues.emit(null);
            return true;
        })
            .catch(function (e) { return Promise.reject(e.message || e); });
    };
    ValidacionClass.prototype.getEnumValues = function (_enum) {
        var r = [];
        var obj = Object.keys(_enum);
        var values = obj.filter(function (u) { return isNaN(Number(u)); });
        obj.filter(function (u) { return !isNaN(Number(u)); })
            .forEach(function (v, i) {
            r.push({ value: Number(v), label: values[i].replace(/([A-Z])/g, ' $1').trim() });
        });
        return r;
    };
    __decorate([
        core_1.Output(),
        __metadata("design:type", core_1.EventEmitter)
    ], ValidacionClass.prototype, "validacionChange", void 0);
    __decorate([
        core_1.Output(),
        __metadata("design:type", core_1.EventEmitter)
    ], ValidacionClass.prototype, "changeValues", void 0);
    return ValidacionClass;
}());
/**
 * @description CONEXION A LA BASE DE DATOS
 */
var PermisosHttpDAO = /** @class */ (function () {
    function PermisosHttpDAO(http) {
        this.http = http;
    }
    PermisosHttpDAO.prototype.getReportPermisos = function (page, pageSize, order, sort, validacion) {
        var href = '../../../../../../../../../../api/apiPermisos/getPermisos/';
        var requestUrl = href + "/" + (page + 1) + "/" + pageSize + "/" + sort + "/" + order + "/" + validacion;
        return this.http.get(requestUrl).map(function (r) { return r.json(); });
    };
    return PermisosHttpDAO;
}());
/**
 * @description DATA SOURCE QUE DEVUELVE LOS PERMISOS A LA TABLA
 */
var PermisosDataSource = /** @class */ (function (_super) {
    __extends(PermisosDataSource, _super);
    function PermisosDataSource(permisosHttpDAO, paginator, sort, validacion) {
        var _this = _super.call(this) || this;
        _this.permisosHttpDAO = permisosHttpDAO;
        _this.paginator = paginator;
        _this.sort = sort;
        _this.validacion = validacion;
        _this.resultLength = 0;
        _this.isLoadingResults = false;
        _this.isRateLimitReached = false;
        return _this;
    }
    PermisosDataSource.prototype.connect = function () {
        var _this = this;
        var displayDataChanges = [
            this.sort.sortChange,
            this.paginator.page,
            this.validacion.validacionChange,
            this.validacion.changeValues
        ];
        this.sort.sortChange.subscribe(function () { return _this.paginator.pageIndex = 0; });
        return Observable_1.Observable.merge.apply(Observable_1.Observable, displayDataChanges).startWith(null)
            .switchMap(function () {
            _this.isLoadingResults = true;
            return _this.permisosHttpDAO.getReportPermisos(_this.paginator.pageIndex, _this.paginator.pageSize, _this.sort.direction, _this.sort.active, _this.validacion.validacion // Filtro de Validaciones 
            );
        })
            .map(function (data) {
            _this.isLoadingResults = false;
            _this.isRateLimitReached = false;
            _this.resultLength = data.TotalLength; /// Largo de los resultados...
            return data.Items; /// Resultados
        })
            .catch(function (e) {
            console.log('Catch');
            console.log(e);
            _this.isLoadingResults = false;
            _this.isRateLimitReached = true;
            return Observable_1.Observable.of([]);
        });
    };
    PermisosDataSource.prototype.disconnect = function () { };
    return PermisosDataSource;
}(collections_1.DataSource));
//# sourceMappingURL=validar.component.js.map