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
var common_1 = require("@angular/common");
var material_1 = require("@angular/material");
var material_2 = require("@angular/material");
var flex_layout_1 = require("@angular/flex-layout");
var DialogsService = /** @class */ (function () {
    function DialogsService(dialog, snackBar) {
        this.dialog = dialog;
        this.snackBar = snackBar;
    }
    DialogsService.prototype.confirm = function (title, message, confirmText, cancelText) {
        if (confirmText === void 0) { confirmText = "Si"; }
        if (cancelText === void 0) { cancelText = "No"; }
        var dialogRef;
        dialogRef = this.dialog.open(ConfirmDialogComponent);
        dialogRef.componentInstance.title = title;
        dialogRef.componentInstance.message = message;
        dialogRef.componentInstance.confirmText = confirmText;
        dialogRef.componentInstance.cancelText = cancelText;
        return dialogRef.afterClosed();
    };
    DialogsService.prototype.snackError = function (Message, duration) {
        if (duration === void 0) { duration = 5000; }
        return this.snackBar.openFromComponent(ErrorSnackComponent, { duration: duration, data: Message }).afterDismissed();
    };
    DialogsService.prototype.snackSuccess = function (Message, duration) {
        if (duration === void 0) { duration = 5000; }
        return this.snackBar.openFromComponent(SuccessSnackComponent, { duration: duration, data: Message }).afterDismissed();
    };
    DialogsService = __decorate([
        core_1.Injectable(),
        __metadata("design:paramtypes", [material_1.MatDialog, material_1.MatSnackBar])
    ], DialogsService);
    return DialogsService;
}());
exports.DialogsService = DialogsService;
var ConfirmDialogComponent = /** @class */ (function () {
    function ConfirmDialogComponent(dialogRef, media) {
        this.dialogRef = dialogRef;
        this.media = media;
    }
    ConfirmDialogComponent = __decorate([
        core_1.Component({
            selector: 'app-confirm-dialog',
            templateUrl: "./confirmDialog.component.html"
        }),
        __metadata("design:paramtypes", [material_1.MatDialogRef, flex_layout_1.ObservableMedia])
    ], ConfirmDialogComponent);
    return ConfirmDialogComponent;
}());
exports.ConfirmDialogComponent = ConfirmDialogComponent;
var SuccessSnackComponent = /** @class */ (function () {
    function SuccessSnackComponent(data) {
        this.data = data;
    }
    SuccessSnackComponent = __decorate([
        core_1.Component({
            selector: 'snakbar-error',
            template: "<section class=\"snack mat-typography\"><mat-icon class=\"snack-icon\" style=\"color: green;\">check_circle</mat-icon><div class=\"snack-content\"><span class=\"snack-text\">{{data}}</span></div></section>",
            styles: [""]
        }),
        __param(0, core_1.Inject(material_1.MAT_SNACK_BAR_DATA)),
        __metadata("design:paramtypes", [String])
    ], SuccessSnackComponent);
    return SuccessSnackComponent;
}());
exports.SuccessSnackComponent = SuccessSnackComponent;
var ErrorSnackComponent = /** @class */ (function () {
    function ErrorSnackComponent(data) {
        this.data = data;
    }
    ErrorSnackComponent = __decorate([
        core_1.Component({
            selector: 'snakbar-error',
            template: "<section class=\"snack mat-typography\"><mat-icon class=\"snack-icon\" style=\"color: red;\">warning</mat-icon><div class=\"snack-content\"><span class=\"snack-text\">{{data}}</span></div></section>",
            styles: [""]
        }),
        __param(0, core_1.Inject(material_1.MAT_SNACK_BAR_DATA)),
        __metadata("design:paramtypes", [String])
    ], ErrorSnackComponent);
    return ErrorSnackComponent;
}());
exports.ErrorSnackComponent = ErrorSnackComponent;
var DialogsModule = /** @class */ (function () {
    function DialogsModule() {
    }
    DialogsModule = __decorate([
        core_1.NgModule({
            imports: [
                common_1.CommonModule,
                material_2.MatDialogModule,
                material_2.MatButtonModule,
                material_2.MatIconModule,
                material_2.MatCardModule,
                flex_layout_1.FlexLayoutModule
            ],
            declarations: [ConfirmDialogComponent, ErrorSnackComponent, SuccessSnackComponent],
            exports: [ConfirmDialogComponent, ErrorSnackComponent, SuccessSnackComponent],
            entryComponents: [ConfirmDialogComponent, ErrorSnackComponent, SuccessSnackComponent],
            providers: [DialogsService]
        })
    ], DialogsModule);
    return DialogsModule;
}());
exports.DialogsModule = DialogsModule;
//# sourceMappingURL=dialog.service.js.map