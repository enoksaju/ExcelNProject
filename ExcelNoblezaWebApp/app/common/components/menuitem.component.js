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
var Menu = /** @class */ (function () {
    function Menu(Items, NombreGrupo, Icon) {
        if (NombreGrupo === void 0) { NombreGrupo = null; }
        if (Icon === void 0) { Icon = null; }
        this.Icon = Icon;
        this.Items = Items;
        this.NombreGrupo = NombreGrupo;
    }
    return Menu;
}());
exports.Menu = Menu;
var SubMenu = /** @class */ (function () {
    function SubMenu(items) {
        this.Items = items;
    }
    return SubMenu;
}());
exports.SubMenu = SubMenu;
var Item = /** @class */ (function () {
    /**
    * /@example
    new Item("SubMenu", "Prueba de submenu", "face", null,
        new SubMenu(
          [
            new Item("About", "Acerca de esta pagina", "help", "/about")
          ]
        )
      )
    */
    function Item(label, description, icon, routerLink, submenu) {
        if (routerLink === void 0) { routerLink = null; }
        if (submenu === void 0) { submenu = null; }
        this.Label = label;
        this.Description = description;
        this.Icon = icon ? icon.toLowerCase() : null;
        this.routerLink = routerLink;
        this.SubMenu = submenu;
    }
    return Item;
}());
exports.Item = Item;
var MenuItemsComponent = /** @class */ (function () {
    function MenuItemsComponent() {
    }
    MenuItemsComponent.prototype.Open = function () {
        console.info("Click");
    };
    MenuItemsComponent.prototype.print = function (f) {
        console.log(f);
    };
    MenuItemsComponent.prototype.ngOnInit = function () {
    };
    __decorate([
        core_1.Input(),
        __metadata("design:type", Menu)
    ], MenuItemsComponent.prototype, "Menu", void 0);
    __decorate([
        core_1.Input(),
        __metadata("design:type", String)
    ], MenuItemsComponent.prototype, "ActiveClass", void 0);
    MenuItemsComponent = __decorate([
        core_1.Component({
            selector: 'menu-item',
            templateUrl: './menuitem.component.html',
            styles: ["\n.content {\n    display: flex;\n    flex-direction: row;\n    align-items: center;\n    box-sizing: border-box;\n    padding: 0;\n    position: relative;\n    width:100%;\n}\n.icon {\n    width: 24px;\n    height: 24px;\n    font-size: 24px;\n    box-sizing: content-box;\n    border-radius: 50%;\n    padding: 4px;\n}\n.text {\n    display: flex;\n    flex-direction: column;\n    width: 100%;\n    box-sizing: border-box;\n    overflow: hidden;\n    padding: 0 16px!important;\n    margin: 0;\n}\n.line{\n    white-space: nowrap;\n    overflow: hidden;\n    text-overflow: ellipsis;\n    display: block;\n    box-sizing: border-box;\n    margin: 0;\n    padding: 0;\n}\n.head{\n   font-weight:bold!important;\n   font-size:20px!important;\n}\n.tx{\n    font-weight:300!important;\n    font-size:15px!important;\n    font-family: Roboto, \"Helvetica Neue\", sans-serif!important;\n}\n.full-with{\n    width:100%;\n}\n.lg-icon{\n    font-size:35px!important;\n    width:35px!important;\n    height:35px!important;\n}\n"]
        }),
        __metadata("design:paramtypes", [])
    ], MenuItemsComponent);
    return MenuItemsComponent;
}());
exports.MenuItemsComponent = MenuItemsComponent;
//# sourceMappingURL=menuitem.component.js.map