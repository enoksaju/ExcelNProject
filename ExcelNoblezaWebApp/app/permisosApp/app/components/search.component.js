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
var trabajador_service_1 = require("../../../common/Services/trabajador.service");
var platform_browser_1 = require("@angular/platform-browser");
var forms_1 = require("@angular/forms");
var SearchComponent = /** @class */ (function () {
    function SearchComponent(media, http, trabajadorService, _sanitizer) {
        this.media = media;
        this.http = http;
        this.trabajadorService = trabajadorService;
        this._sanitizer = _sanitizer;
        this.Folio = new forms_1.FormControl(localStorage.getItem("Folio") ? localStorage.getItem("Folio") : '', [forms_1.Validators.required, forms_1.Validators.minLength(11), forms_1.Validators.maxLength(11)]);
        this.showPDF = false;
    }
    SearchComponent.prototype.ngOnInit = function () {
        if (!/Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent)) {
            this.buscarFolio(this.Folio.value);
        }
    };
    SearchComponent.prototype.buscarFolio = function (_folio) {
        var _this = this;
        localStorage.setItem("Folio", _folio);
        if (/Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent)) {
            this.trabajadorService.DescargarPDF(_folio);
        }
        else {
            this.trabajadorService.GetPermisoPDFUrl(_folio).subscribe(function (r) {
                _this.safeResourceUrl = r;
                _this.showPDF = true;
            });
        }
    };
    ;
    SearchComponent = __decorate([
        core_1.Component({
            selector: 'search-page',
            templateUrl: './search.component.html',
            styles: []
        }),
        __metadata("design:paramtypes", [flex_layout_1.ObservableMedia, http_1.Http, trabajador_service_1.TrabajadorService, platform_browser_1.DomSanitizer])
    ], SearchComponent);
    return SearchComponent;
}());
exports.SearchComponent = SearchComponent;
//# sourceMappingURL=search.component.js.map