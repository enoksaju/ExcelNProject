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
require("rxjs/add/operator/toPromise");
var AppItem = /** @class */ (function () {
    function AppItem(Label, Icon, Link, Color, Description, fa) {
        if (Color === void 0) { Color = null; }
        if (Description === void 0) { Description = null; }
        if (fa === void 0) { fa = false; }
        this.fail = false;
        this.Label = Label;
        this.Icon = Icon.toLowerCase();
        this.Color = Color;
        this.Link = Link;
    }
    return AppItem;
}());
exports.AppItem = AppItem;
var UserService = /** @class */ (function () {
    function UserService(http) {
        this.http = http;
        this.headers = new http_1.Headers({ 'Content-Type': 'application/json' });
    }
    UserService.prototype.isLoged = function () {
        return this.http.get("../../../../../../../../api/home/isloged")
            .toPromise().then(function (response) { return response.json(); })
            .catch(this.handleError);
    };
    ;
    UserService.prototype.isAdminNominas = function () {
        return this.http.get("../../../../../../../../api/apiPermisos/isAdmin")
            .toPromise().then(function (response) { return response.json(); })
            .catch(this.handleError);
    };
    UserService.prototype.GetMenu = function () {
        return this.http.get("../../../../../../../../api/home/getmenu")
            .toPromise()
            .then(function (r) { return r.json(); })
            .catch(this.handleError);
    };
    UserService.prototype.GetMenuPermisos = function () {
        return this.http.get('../../../../../../../../../../api/apiPermisos/getMenu')
            .toPromise()
            .then(function (r) { return r.json(); })
            .catch(this.handleError);
    };
    UserService.prototype.GetApps = function () {
        return this.http.get('../../../../../../../../api/home/getApps')
            .toPromise()
            .then(function (t) { return t.json(); })
            .catch(this.handleError);
    };
    UserService.prototype.handleError = function (error) {
        console.error('An error occurred', error);
        return Promise.reject(error.message || error);
    };
    UserService = __decorate([
        core_1.Injectable(),
        __metadata("design:paramtypes", [http_1.Http])
    ], UserService);
    return UserService;
}());
exports.UserService = UserService;
//# sourceMappingURL=user.service.js.map