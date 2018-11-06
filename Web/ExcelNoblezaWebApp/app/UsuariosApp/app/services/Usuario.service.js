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
var UsuarioServiceClass = /** @class */ (function () {
    function UsuarioServiceClass() {
        this.eRefresh = new core_1.EventEmitter();
    }
    UsuarioServiceClass.prototype.Refresh = function () {
        this.eRefresh.emit(null);
    };
    __decorate([
        core_1.Output(),
        __metadata("design:type", core_1.EventEmitter)
    ], UsuarioServiceClass.prototype, "eRefresh", void 0);
    return UsuarioServiceClass;
}());
exports.UsuarioServiceClass = UsuarioServiceClass;
var AccionesRoles;
(function (AccionesRoles) {
    AccionesRoles[AccionesRoles["Agregar"] = 1] = "Agregar";
    AccionesRoles[AccionesRoles["Eliminar"] = 2] = "Eliminar";
})(AccionesRoles = exports.AccionesRoles || (exports.AccionesRoles = {}));
var roleAction = /** @class */ (function () {
    function roleAction() {
    }
    roleAction.defaultValue = function (id) {
        var r = new roleAction;
        r.Action = AccionesRoles.Agregar;
        r.Role = '';
        r.UserId = id;
        return r;
    };
    return roleAction;
}());
exports.roleAction = roleAction;
var UsuarioReturnModel = /** @class */ (function () {
    function UsuarioReturnModel() {
    }
    UsuarioReturnModel.fromData = function (UserName, UserId, Email, FullName, Roles) {
        var ret = new UsuarioReturnModel();
        ret.UserName = UserName;
        ret.UserId = UserId;
        ret.Email = Email;
        ret.FullName = FullName;
        ret.Roles = Roles;
        return ret;
    };
    ;
    return UsuarioReturnModel;
}());
exports.UsuarioReturnModel = UsuarioReturnModel;
var UsuarioCreateModel = /** @class */ (function () {
    function UsuarioCreateModel() {
    }
    UsuarioCreateModel.fromForm = function (form) {
        var ret = new UsuarioCreateModel();
        ret.UserName = form.value.UserName || null;
        ret.Email = form.value.Email || null;
        ret.Nombre = form.value.Nombre || null;
        ret.ApellidoPaterno = form.value.ApellidoPaterno || null;
        ret.ApellidoMaterno = form.value.ApellidoMaterno || null;
        ret.Password = form.value.Password || null;
        ret.ConfirmPassword = form.value.ConfirmPassword || null;
        return ret;
    };
    return UsuarioCreateModel;
}());
exports.UsuarioCreateModel = UsuarioCreateModel;
var UsuariosService = /** @class */ (function () {
    function UsuariosService(http) {
        this.http = http;
        this.headers = new http_1.Headers({ 'Content-Type': 'application/json' });
    }
    UsuariosService.prototype.handleError = function (error) {
        return Promise.reject(error._body || error);
    };
    UsuariosService.prototype.getTrabajadores = function (usuarioService) {
        return this.http.get('../../../../../../../../../api/Usuarios/getAll')
            .map(function (response) { return response.json(); });
    };
    UsuariosService.prototype.updateRoles = function (data) {
        return this.http.post('../../../../../../../../../api/Usuarios/roles', data, { headers: this.headers })
            .toPromise()
            .then(function (res) { return res.json(); })
            .catch(this.handleError);
    };
    UsuariosService.prototype.DeleteUser = function (id) {
        return this.http.delete('../../../../../../../../../api/Account/user?Id=' + id)
            .toPromise().then(function (res) { return res.json(); })
            .catch(this.handleError);
    };
    UsuariosService.prototype.AddUser = function (data) {
        return this.http.post('../../../../../../../../../api/Account/user', data, { headers: this.headers })
            .toPromise().then(function (res) { return res.json(); })
            .catch(this.handleError);
    };
    UsuariosService = __decorate([
        core_1.Injectable(),
        __metadata("design:paramtypes", [http_1.Http])
    ], UsuariosService);
    return UsuariosService;
}());
exports.UsuariosService = UsuariosService;
//# sourceMappingURL=Usuario.service.js.map