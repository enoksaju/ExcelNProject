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
var __param = (this && this.__param) || function (paramIndex, decorator) {
    return function (target, key) { decorator(target, key, paramIndex); }
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var flex_layout_1 = require("@angular/flex-layout");
var http_1 = require("@angular/http");
var platform_browser_1 = require("@angular/platform-browser");
var forms_1 = require("@angular/forms");
var material_1 = require("@angular/material");
//Services
var ot_service_1 = require("../services/ot.service");
var SearchComponent = /** @class */ (function () {
    function SearchComponent(media, http, _sanitizer, otService, snackBar) {
        this.media = media;
        this.http = http;
        this._sanitizer = _sanitizer;
        this.otService = otService;
        this.snackBar = snackBar;
        this.OT = new forms_1.FormControl(localStorage.getItem("OT") ? localStorage.getItem("OT") : '', [forms_1.Validators.required]);
        this.getOTModel = new ot_service_1.GetOTModel();
        this.model = new ot_service_1.infoOT();
        this.Instrucciones = [];
        this.secondstate = false;
        this.isSearching = false;
    }
    SearchComponent.prototype.ngOnInit = function () { };
    SearchComponent.prototype.buscarOT = function (folio) {
        var _this = this;
        this.isSearching = true;
        this.getOTModel.OrderNumber = folio;
        this.otService.verOt(this.getOTModel).then(function (t) {
            _this.secondstate = true;
            _this.model = t;
            _this.Instrucciones = [];
            Object.keys(_this.model).forEach(function (k, i) {
                var t = new RegExp("^INST?([A-Z])*", "g"), pushInst = function (name, value) {
                    value.trim().length > 0 && _this.Instrucciones.push({
                        nombre: name.charAt(4).toUpperCase() + name.substring(5).toLowerCase(),
                        value: value
                    });
                };
                t.test(k) && pushInst(k, _this.model[k]);
            });
            _this.isSearching = false;
        }, function (r) {
            _this.snackBar.openFromComponent(ErrorSnackComponent, { duration: 5000, data: r });
            _this.isSearching = false;
        });
    };
    SearchComponent = __decorate([
        core_1.Component({
            templateUrl: './search.component.html',
            styles: ['.pad{padding:10px; margin:10px;}.marg-25{margin-right:25px!important}']
        }),
        __metadata("design:paramtypes", [flex_layout_1.ObservableMedia, http_1.Http, platform_browser_1.DomSanitizer, ot_service_1.OTService, material_1.MatSnackBar])
    ], SearchComponent);
    return SearchComponent;
}());
exports.SearchComponent = SearchComponent;
var ErrorSnackComponent = /** @class */ (function () {
    function ErrorSnackComponent(data) {
        this.data = data;
    }
    ErrorSnackComponent = __decorate([
        core_1.Component({
            selector: 'snakbar-error',
            template: "\n<section class=\"mat-typography\">\n  <mat-icon color=\"warn\">warning</mat-icon>\n  <span class=\"\">\n    {{data.Message}}\n  </span>\n</section>\n\n",
            styles: [""]
        }),
        __param(0, core_1.Inject(material_1.MAT_SNACK_BAR_DATA)),
        __metadata("design:paramtypes", [Object])
    ], ErrorSnackComponent);
    return ErrorSnackComponent;
}());
exports.ErrorSnackComponent = ErrorSnackComponent;
//# sourceMappingURL=search.component.js.map