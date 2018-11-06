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
var forms_1 = require("@angular/forms");
var platform_browser_1 = require("@angular/platform-browser");
var http_1 = require("@angular/http");
var router_1 = require("@angular/router");
var routes_1 = require("./routes");
// Material Secction
var MyMaterialModule_module_1 = require("./MyMaterialModule.module");
var ngx_gallery_1 = require("ngx-gallery");
var material_1 = require("@angular/material");
// AppSection
var app_component_1 = require("./components/app.component");
var main_component_1 = require("./components/main.component");
var aplicaciones_component_1 = require("./components/aplicaciones.component");
var contacto_component_1 = require("./components/contacto.component");
var products_1 = require("./components/products/products");
//Common Components
var menuitem_component_1 = require("../../common/components/menuitem.component");
var carousel_component_1 = require("../../common/components/carousel.component");
var cardcontainer_component_1 = require("../../common/components/cardcontainer.component");
//Servicios
var user_service_1 = require("../../common/Services/user.service");
var AppModule = /** @class */ (function () {
    function AppModule(matIconRegister) {
        this.matIconRegister = matIconRegister;
        this.matIconRegister.registerFontClassAlias("fontawesome", "fa");
    }
    AppModule = __decorate([
        core_1.NgModule({
            imports: [
                platform_browser_1.BrowserModule,
                http_1.HttpModule,
                MyMaterialModule_module_1.MaterialModule,
                router_1.RouterModule.forRoot(routes_1.routes, { useHash: true, preloadingStrategy: router_1.PreloadAllModules }),
                forms_1.FormsModule,
                forms_1.ReactiveFormsModule,
                ngx_gallery_1.NgxGalleryModule
            ],
            declarations: [
                app_component_1.AppComponent,
                main_component_1.MainComponent,
                aplicaciones_component_1.AplicacionesComponent,
                menuitem_component_1.MenuItemsComponent,
                carousel_component_1.Carousel, carousel_component_1.Slide,
                cardcontainer_component_1.CardContentComponent,
                products_1.ProductsComponent,
                products_1.PeliculasComponent,
                products_1.BolsasComponent,
                products_1.PolietilenoComponent,
                products_1.EtiquetasComponent,
                products_1.InnovacionesComponent,
                contacto_component_1.ContactoComponent
            ],
            providers: [
                material_1.MatIconRegistry,
                user_service_1.UserService
            ],
            bootstrap: [
                app_component_1.AppComponent
            ]
        }),
        __metadata("design:paramtypes", [material_1.MatIconRegistry])
    ], AppModule);
    return AppModule;
}());
exports.AppModule = AppModule;
//# sourceMappingURL=app.module.js.map