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
var __param = (this && this.__param) || function (paramIndex, decorator) {
    return function (target, key) { decorator(target, key, paramIndex); }
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var router_1 = require("@angular/router");
var collections_1 = require("@angular/cdk/collections");
var material_1 = require("@angular/material");
var Usuario_service_1 = require("../services/Usuario.service");
var Observable_1 = require("rxjs/Observable");
var dialog_service_1 = require("../../../common/Services/dialog.service");
var IndexComponent = /** @class */ (function () {
    function IndexComponent(usuariosService, router, dialog, dlg) {
        this.usuariosService = usuariosService;
        this.router = router;
        this.dialog = dialog;
        this.dlg = dlg;
        this.displayedColumns = ['Buttons', 'Usuario', 'Nombre', 'Email', 'Roles'];
    }
    IndexComponent.prototype.ngOnInit = function () {
        this.usuarioServiceClass = new Usuario_service_1.UsuarioServiceClass();
        this.dataSource = new UsuarioDataSource(this.usuariosService, this.sort, this.usuarioServiceClass);
    };
    IndexComponent.prototype.canDelete = function (row) {
        return row.Roles.indexOf('Develop') === -1 && row.Roles.indexOf('Admin') === -1;
    };
    IndexComponent.prototype.EditRole = function (row) {
        var _this = this;
        var action = Usuario_service_1.roleAction.defaultValue(row.UserId), dialogRef = this.dialog.open(RoleUpdateDialog, {
            width: '250px',
            data: action
        });
        dialogRef.afterClosed().subscribe(function (result) {
            result && result.Role.trim() != "Admin" && _this.usuariosService.updateRoles(result)
                .then(function (r) {
                _this.dlg.snackSuccess(r);
                _this.usuarioServiceClass.Refresh();
            }, function (e) {
                _this.dlg.snackError(JSON.parse(e).Message || JSON.parse(e));
            });
        });
    };
    IndexComponent.prototype.deleteUser = function (row) {
        var _this = this;
        this.dlg.confirm("Confirme", "Realmente desea borrar al usuario " + row.FullName, "Si,  Borrar", "No, Cancelar").subscribe(function (response) {
            if (response) {
                _this.usuariosService.DeleteUser(row.UserId).then(function (t) {
                    _this.usuarioServiceClass.Refresh();
                    console.log(t);
                });
            }
        }, function () { });
    };
    IndexComponent.prototype.Back = function () {
        window.location.href = '/';
    };
    IndexComponent.prototype.AddUser = function () {
    };
    __decorate([
        core_1.ViewChild(material_1.MatTable),
        __metadata("design:type", material_1.MatTable)
    ], IndexComponent.prototype, "table", void 0);
    __decorate([
        core_1.ViewChild(material_1.MatSort),
        __metadata("design:type", material_1.MatSort)
    ], IndexComponent.prototype, "sort", void 0);
    IndexComponent = __decorate([
        core_1.Component({
            selector: 'index-page',
            templateUrl: './index.component.html',
            styles: [".example-table { overflow: auto; min-height: 300px;}.mat-row, .mat-header-row {min-width: 800px;}.example-loading-shade {position: absolute; top: 0; left: 0; bottom: 0px; right: 0; background: rgba(0, 0, 0, 0.15); z-index: 1; display: flex; align-items: center; justify-content: center;}.example-rate-limit-reached { color: #980000; max-width: 360px; text-align: center;}"]
        }),
        __metadata("design:paramtypes", [Usuario_service_1.UsuariosService, router_1.Router, material_1.MatDialog, dialog_service_1.DialogsService])
    ], IndexComponent);
    return IndexComponent;
}());
exports.IndexComponent = IndexComponent;
;
var UsuarioDataSource = /** @class */ (function (_super) {
    __extends(UsuarioDataSource, _super);
    function UsuarioDataSource(usuarioService, sort, usuarioServiceClass) {
        var _this = _super.call(this) || this;
        _this.usuarioService = usuarioService;
        _this.sort = sort;
        _this.usuarioServiceClass = usuarioServiceClass;
        _this.resultLength = 0;
        _this.isLoadingResults = false;
        _this.isRateLimitReached = false;
        return _this;
    }
    UsuarioDataSource.prototype.connect = function () {
        var _this = this;
        var displayDataChanges = [
            this.sort.sortChange,
            this.usuarioServiceClass.eRefresh
        ];
        return Observable_1.Observable.merge.apply(Observable_1.Observable, displayDataChanges).startWith(null)
            .switchMap(function () {
            _this.isLoadingResults = true;
            return _this.usuarioService.getTrabajadores(_this.usuarioServiceClass);
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
    UsuarioDataSource.prototype.disconnect = function () { };
    ;
    return UsuarioDataSource;
}(collections_1.DataSource));
var RoleUpdateDialog = /** @class */ (function () {
    function RoleUpdateDialog(dialogRef, data) {
        this.dialogRef = dialogRef;
        this.data = data;
        this.acciones = [];
    }
    RoleUpdateDialog.prototype.onNoClick = function () {
        this.dialogRef.close();
    };
    RoleUpdateDialog.prototype.ngOnInit = function () {
        var d = Usuario_service_1.AccionesRoles;
        this.acciones = Auxiliares.getEnumValues(d);
    };
    RoleUpdateDialog = __decorate([
        core_1.Component({
            selector: 'role-update-dialog',
            template: "\n<h1 mat-dialog-title>Editar Roles</h1>\n<div mat-dialog-content>\n        <div>\n          <mat-form-field fxFlex=\"100\">\n            <input matInput placeholder=\"Rol\" tabindex=\"3\" [(ngModel)]=\"data.Role\" />\n          </mat-form-field>\n        </div>\n        <div>\n          <mat-form-field fxFlex=\"100\">\n            <mat-select placeholder=\"Accion\" tabindex=\"4\" [(ngModel)]=\"data.Action\" >\n              <mat-option *ngFor=\"let key of acciones\" [value]=\"key.value\">{{key.label}}</mat-option>\n            </mat-select>\n          </mat-form-field>\n        </div>\n</div>\n<div mat-dialog-actions>\n  <button mat-button [mat-dialog-close]=\"data\" tabindex=\"2\">Continuar</button>\n  <button mat-button (click)=\"onNoClick()\" tabindex=\"-1\">Cancelar</button>\n</div>\n",
        }),
        __param(1, core_1.Inject(material_1.MAT_DIALOG_DATA)),
        __metadata("design:paramtypes", [material_1.MatDialogRef, Usuario_service_1.roleAction])
    ], RoleUpdateDialog);
    return RoleUpdateDialog;
}());
exports.RoleUpdateDialog = RoleUpdateDialog;
var AddUsuarioModel = /** @class */ (function () {
    function AddUsuarioModel() {
    }
    return AddUsuarioModel;
}());
var Auxiliares = /** @class */ (function () {
    function Auxiliares() {
    }
    Auxiliares.getEnumValues = function (_enum) {
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
    return Auxiliares;
}());
//# sourceMappingURL=index.component.js.map