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
var menuitem_component_1 = require("../../../common/components/menuitem.component");
var user_service_1 = require("../../../common/Services/user.service");
var AppComponent = /** @class */ (function () {
    function AppComponent(media, http, userService) {
        this.media = media;
        this.http = http;
        this.userService = userService;
        this.isloged = false;
        this.loginPath = '/Account/Login';
        this.logoffPath = "javascript:document.getElementById('logoutForm').submit()";
        this.Items = [
            new menuitem_component_1.Item("Inicio", "Pagina de Inicio", "home", "/main"),
            new menuitem_component_1.Item("Productos", "Nuestros Productos", "work", null, new menuitem_component_1.SubMenu([
                new menuitem_component_1.Item("Peliculas", "Peliculas Impresas y Laminadas", null, "/productos/peliculas"),
                new menuitem_component_1.Item("Bolsas y Pouches", "Bolsas y Pouches", null, "/productos/bolsas"),
                new menuitem_component_1.Item("Polietileno", "Polietileno Termoencogible", null, "/productos/polietileno"),
                new menuitem_component_1.Item("Etiquetas", "Etiquetas", null, "/productos/etiquetas"),
                new menuitem_component_1.Item("Innovaciones", "Innovaciones", null, "/productos/innovaciones")
            ])),
            new menuitem_component_1.Item("Contacto", "Comunicate con nosotros", "phone", "/contacto"),
        ];
        this.Menu = new menuitem_component_1.Menu(this.Items);
    }
    /**
     * /@description: Retorna el valor de RequestVerificationToken
     */
    AppComponent.prototype.token = function () {
        var tok = document.getElementsByName("__RequestVerificationToken")[0];
        return tok.value;
    };
    /**
     * /@description: Accion que se realiza al presionar el boton de inicio o cierre de sesi�n.
     */
    AppComponent.prototype.LogClick = function () {
        if (this.isloged) {
            var frm = document.getElementById('logoutForm');
            frm.submit();
        }
        else {
            window.location.replace('/Account/Login');
        }
    };
    ;
    AppComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.userService.isLoged().then(function (r) { return _this.isloged = r; });
        this.userService.GetMenu().then(function (r) {
            r.forEach(function (v, i) {
                _this.Menu.Items.push(v);
            });
        });
    };
    AppComponent = __decorate([
        core_1.Component({
            selector: 'my-app',
            templateUrl: './app.component.html',
            styleUrls: ['./app.component.css']
        }),
        __metadata("design:paramtypes", [flex_layout_1.ObservableMedia,
            http_1.Http,
            user_service_1.UserService])
    ], AppComponent);
    return AppComponent;
}());
exports.AppComponent = AppComponent;
//# sourceMappingURL=app.component.js.map