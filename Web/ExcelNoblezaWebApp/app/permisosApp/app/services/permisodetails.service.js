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
var common_1 = require("@angular/common");
var material_1 = require("@angular/material");
var flex_layout_1 = require("@angular/flex-layout");
var dialog_service_1 = require("../../../common/Services/dialog.service");
var PermisoDetailsService = /** @class */ (function () {
    function PermisoDetailsService(dialog) {
        this.dialog = dialog;
    }
    PermisoDetailsService.prototype.showDetails = function (permiso) {
        var dialogRef;
        dialogRef = this.dialog.open(PemisosDetailsComponent, { panelClass: 'dialog-notpadding' });
        dialogRef.componentInstance.permiso = permiso;
        return dialogRef.afterClosed();
    };
    PermisoDetailsService = __decorate([
        core_1.Injectable(),
        __metadata("design:paramtypes", [material_1.MatDialog])
    ], PermisoDetailsService);
    return PermisoDetailsService;
}());
exports.PermisoDetailsService = PermisoDetailsService;
var PemisosDetailsComponent = /** @class */ (function () {
    function PemisosDetailsComponent(dgRef, media, dialogsService) {
        this.dgRef = dgRef;
        this.media = media;
        this.dialogsService = dialogsService;
    }
    PemisosDetailsComponent.prototype.close = function (t) {
        var _this = this;
        this.dialogsService.confirm('Confirme', 'Realmente desea ' + t + ' esté permiso?', 'Si, ' + t)
            .subscribe(function (y) {
            return y && _this.dgRef.close({ accion: t, items: [_this.permiso.Id] });
        });
    };
    PemisosDetailsComponent = __decorate([
        core_1.Component({
            selector: 'permiso-details-dialog',
            templateUrl: "./permisoDetails.component.html",
            styles: ["\nmat-form-field{\n  width:100%;\n}\n"]
        }),
        __metadata("design:paramtypes", [material_1.MatDialogRef, flex_layout_1.ObservableMedia, dialog_service_1.DialogsService])
    ], PemisosDetailsComponent);
    return PemisosDetailsComponent;
}());
exports.PemisosDetailsComponent = PemisosDetailsComponent;
var PermisoDetailsModule = /** @class */ (function () {
    function PermisoDetailsModule() {
    }
    PermisoDetailsModule = __decorate([
        core_1.NgModule({
            imports: [
                common_1.CommonModule,
                flex_layout_1.FlexLayoutModule,
                material_1.MatToolbarModule,
                material_1.MatCardModule,
                material_1.MatButtonModule,
                material_1.MatIconModule,
                material_1.MatInputModule
            ],
            declarations: [PemisosDetailsComponent],
            exports: [PemisosDetailsComponent],
            entryComponents: [PemisosDetailsComponent],
            providers: [PermisoDetailsService]
        })
    ], PermisoDetailsModule);
    return PermisoDetailsModule;
}());
exports.PermisoDetailsModule = PermisoDetailsModule;
//# sourceMappingURL=permisodetails.service.js.map