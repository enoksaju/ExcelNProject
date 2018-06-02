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
var forms_1 = require("@angular/forms");
var material_1 = require("@angular/material");
var AppComponent = /** @class */ (function () {
    function AppComponent(media, http, snackBar) {
        this.media = media;
        this.http = http;
        this.snackBar = snackBar;
        this.hide = true;
        this.NombreField = new forms_1.FormControl('', [forms_1.Validators.required]);
        this.PassField = new forms_1.FormControl('', [forms_1.Validators.required]);
        var msg = document.getElementById("messageModel");
        msg.value && this.snackBar.openFromComponent(errorSnackComponent, { duration: 10000 });
    }
    AppComponent.prototype.ngOnInit = function () {
        var tok = document.getElementsByName("__RequestVerificationToken")[0];
        this.rvt = tok.value;
        this.urlAction = document.location.href;
    };
    AppComponent.prototype.onSubmit = function (f) {
        var frm = document.getElementById('frmLogin');
        frm.submit();
    };
    AppComponent = __decorate([
        core_1.Component({
            selector: 'my-app',
            templateUrl: './app.component.html',
            styles: ["\n.full-with{\n    width:100%;\n}\n.logo{\n    width:80%;\n    max-width: 400px;\n}\n"]
        }),
        __metadata("design:paramtypes", [flex_layout_1.ObservableMedia, http_1.Http, material_1.MatSnackBar])
    ], AppComponent);
    return AppComponent;
}());
exports.AppComponent = AppComponent;
var errorSnackComponent = /** @class */ (function () {
    function errorSnackComponent() {
    }
    errorSnackComponent = __decorate([
        core_1.Component({
            selector: "error-snack",
            template: '<mat-icon style="color: orange">warning</mat-icon> <span class="error mat-typography">   Error al iniciar sesión</span>',
            styles: ['.error { color:red}']
        })
    ], errorSnackComponent);
    return errorSnackComponent;
}());
exports.errorSnackComponent = errorSnackComponent;
//# sourceMappingURL=app.component.js.map