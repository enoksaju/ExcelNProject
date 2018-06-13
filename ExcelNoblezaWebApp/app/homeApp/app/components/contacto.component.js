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
var flex_layout_1 = require("@angular/flex-layout");
var material_1 = require("@angular/material");
var ContactoComponent = /** @class */ (function () {
    function ContactoComponent(media, snackBar) {
        this.media = media;
        this.snackBar = snackBar;
        this.contactForm = new forms_1.FormGroup({
            name: new forms_1.FormControl('', [forms_1.Validators.required]),
            email: new forms_1.FormControl('', [forms_1.Validators.email, forms_1.Validators.required]),
            phone: new forms_1.FormControl(),
            title: new forms_1.FormControl(),
            message: new forms_1.FormControl('', [forms_1.Validators.required, forms_1.Validators.minLength(50), forms_1.Validators.maxLength(300)])
        });
    }
    ContactoComponent.prototype.ngOnInit = function () {
    };
    ContactoComponent.prototype.onSubmit = function (f) {
        console.log(f);
        this.snackBar.open("Se envio la informacion correctamente. Gracias por Contactarnos.");
    };
    ContactoComponent = __decorate([
        core_1.Component({
            selector: 'home-contact',
            templateUrl: './contacto.component.html',
            styleUrls: ['./contacto.component.css']
        }),
        __metadata("design:paramtypes", [flex_layout_1.ObservableMedia, material_1.MatSnackBar])
    ], ContactoComponent);
    return ContactoComponent;
}());
exports.ContactoComponent = ContactoComponent;
//# sourceMappingURL=contacto.component.js.map