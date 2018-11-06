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
var Usuario_service_1 = require("../services/Usuario.service");
var forms_1 = require("@angular/forms");
var dialog_service_1 = require("../../../common/Services/dialog.service");
var router_1 = require("@angular/router");
var AddUserComponent = /** @class */ (function () {
    function AddUserComponent(usuasioService, dlg, router) {
        this.usuasioService = usuasioService;
        this.dlg = dlg;
        this.router = router;
        this.errors = [];
        this.Form = new forms_1.FormGroup({
            UserName: new forms_1.FormControl(null, [forms_1.Validators.required]),
            Email: new forms_1.FormControl(null, [forms_1.Validators.required, forms_1.Validators.email]),
            Nombre: new forms_1.FormControl(null, [forms_1.Validators.required]),
            ApellidoPaterno: new forms_1.FormControl(null, [forms_1.Validators.required]),
            ApellidoMaterno: new forms_1.FormControl(null, [forms_1.Validators.required]),
            Password: new forms_1.FormControl(null, [forms_1.Validators.required]),
            ConfirmPassword: new forms_1.FormControl(null, [forms_1.Validators.required])
        });
    }
    AddUserComponent.prototype.ngOnInit = function () {
        this.user = new Usuario_service_1.UsuarioCreateModel();
    };
    AddUserComponent.prototype.onSubmit = function () {
        var _this = this;
        this.Form.valid && this.usuasioService.AddUser(Usuario_service_1.UsuarioCreateModel.fromForm(this.Form))
            .then(function (t) {
            _this.dlg.snackSuccess(t, 1000).subscribe(function () { _this.router.navigateByUrl('/users/index'); });
        }, function (e) {
            _this.errors = [];
            var res = JSON.parse(e);
            res.ModelState && (function () {
                for (var v in res.ModelState) {
                    res.ModelState[v].forEach(function (v) { return _this.errors.push(v); });
                }
            })();
        });
        this.Form.invalid && this.dlg.snackError('Datos Incorrectos') && console.log('Formulario Invalido');
    };
    AddUserComponent = __decorate([
        core_1.Component({
            selector: "add-user-page",
            templateUrl: './adduser.component.html'
        }),
        __metadata("design:paramtypes", [Usuario_service_1.UsuariosService, dialog_service_1.DialogsService, router_1.Router])
    ], AddUserComponent);
    return AddUserComponent;
}());
exports.AddUserComponent = AddUserComponent;
//# sourceMappingURL=adduser.component.js.map