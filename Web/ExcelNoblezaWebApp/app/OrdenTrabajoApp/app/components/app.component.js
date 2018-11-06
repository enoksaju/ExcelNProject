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
var router_1 = require("@angular/router");
var flex_layout_1 = require("@angular/flex-layout");
var http_1 = require("@angular/http");
var main_1 = require("../../../common/components/main");
var user_service_1 = require("../../../common/Services/user.service");
var AppComponent = /** @class */ (function () {
    function AppComponent(media, http, Router, userService) {
        this.media = media;
        this.http = http;
        this.Router = Router;
        this.userService = userService;
        this.items = [
            new main_1.Item("Inicio", "Pagina de Inicio", "home", '/index'),
            new main_1.Item("Buscar", "Obtener una Orden de Trabajo", "search", '/search'),
            new main_1.Item("Progreso", "Ver progreso de la Orden de Trabajo", "timeline", '/progress')
        ];
        this.Menu = new main_1.Menu(this.items, "Principal");
        this.Menus = [this.Menu];
    }
    AppComponent.prototype.ngOnInit = function () {
        this.rvt = document.getElementsByName("__RequestVerificationToken")[0].value;
    };
    AppComponent = __decorate([
        core_1.Component({
            selector: 'my-app',
            templateUrl: './app.component.html'
        }),
        __metadata("design:paramtypes", [flex_layout_1.ObservableMedia, http_1.Http, router_1.Router, user_service_1.UserService])
    ], AppComponent);
    return AppComponent;
}());
exports.AppComponent = AppComponent;
//# sourceMappingURL=app.component.js.map