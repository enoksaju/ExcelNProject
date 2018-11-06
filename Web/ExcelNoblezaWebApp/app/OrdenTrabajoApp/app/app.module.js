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
var platform_browser_1 = require("@angular/platform-browser");
var http_1 = require("@angular/http");
var router_1 = require("@angular/router");
var forms_1 = require("@angular/forms");
var routes_1 = require("./routes");
var index_1 = require("../../common/date-value-accessor/index");
// Material Secction
var MyMaterialModule_module_1 = require("../../homeApp/app/MyMaterialModule.module");
var main_1 = require("../../common/components/main");
var material_1 = require("@angular/material");
var index_2 = require("../../common/components/fab-speed-dial/index");
// AppSection
var app_1 = require("./components/app");
//Servicios
var user_service_1 = require("../../common/Services/user.service");
var trabajador_service_1 = require("../../common/Services/trabajador.service");
var dialog_service_1 = require("../../common/Services/dialog.service");
var converter_service_1 = require("../../common/Services/converter.service");
var ot_service_1 = require("./services/ot.service");
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
                index_1.DateValueAccessorModule,
                dialog_service_1.DialogsModule
            ],
            declarations: [
                app_1.AppComponent, app_1.IndexComponent, app_1.SearchComponent, app_1.ProgressComponent, app_1.ErrorSnackComponent,
                main_1.MainComponent,
                main_1.MenuItemsComponent,
                index_2.SmdFabSpeedDialActions, index_2.SmdFabSpeedDialComponent, index_2.SmdFabSpeedDialTrigger
            ],
            providers: [
                material_1.MatIconRegistry,
                user_service_1.UserService,
                converter_service_1.ConverterService,
                trabajador_service_1.TrabajadorService,
                ot_service_1.OTService,
                { provide: material_1.MAT_DATE_LOCALE, useValue: 'es-MX' }
            ],
            bootstrap: [
                app_1.AppComponent
            ],
            entryComponents: [app_1.ErrorSnackComponent]
        }),
        __metadata("design:paramtypes", [material_1.MatIconRegistry])
    ], AppModule);
    return AppModule;
}());
exports.AppModule = AppModule;
//# sourceMappingURL=app.module.js.map