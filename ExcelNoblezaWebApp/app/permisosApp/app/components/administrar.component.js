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
var router_1 = require("@angular/router");
var user_service_1 = require("../../../common/Services/user.service");
var AdministrarComponent = /** @class */ (function () {
    function AdministrarComponent(router, userService) {
        this.router = router;
        this.userService = userService;
    }
    ;
    AdministrarComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.userService.isAdminNominas().then(function (y) { return !y && _this.router.navigate(["/index"]); }).catch(function () { return _this.router.navigate(["/index"]); });
    };
    ;
    AdministrarComponent = __decorate([
        core_1.Component({
            selector: 'administrar-page',
            template: '<router-outlet></router-outlet>',
            styles: []
        }),
        __metadata("design:paramtypes", [router_1.Router, user_service_1.UserService])
    ], AdministrarComponent);
    return AdministrarComponent;
}());
exports.AdministrarComponent = AdministrarComponent;
//# sourceMappingURL=administrar.component.js.map