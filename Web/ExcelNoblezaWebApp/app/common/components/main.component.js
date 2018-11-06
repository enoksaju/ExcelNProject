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
var user_service_1 = require("../Services/user.service");
var MainComponent = /** @class */ (function () {
    function MainComponent(media, userService) {
        this.media = media;
        this.userService = userService;
        this.Menus = null;
    }
    MainComponent.prototype.LogClick = function () {
        if (this.isloged) {
            var frm = document.getElementById('logoutForm');
            frm.submit();
        }
        else {
            this.loginPath && window.location.replace(this.loginPath);
        }
    };
    ;
    MainComponent.prototype.withPaths = function () {
        var t = this.loginPath || this.logoffPath ? true : false;
        return t;
    };
    MainComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.userService.isLoged().then(function (r) { return _this.isloged = r; });
    };
    __decorate([
        core_1.Input(),
        __metadata("design:type", String)
    ], MainComponent.prototype, "loginPath", void 0);
    __decorate([
        core_1.Input(),
        __metadata("design:type", String)
    ], MainComponent.prototype, "logoffPath", void 0);
    __decorate([
        core_1.Input(),
        __metadata("design:type", Array)
    ], MainComponent.prototype, "Menus", void 0);
    __decorate([
        core_1.Input(),
        __metadata("design:type", String)
    ], MainComponent.prototype, "Token", void 0);
    __decorate([
        core_1.Input(),
        __metadata("design:type", String)
    ], MainComponent.prototype, "ImageUrl", void 0);
    __decorate([
        core_1.Input(),
        __metadata("design:type", Boolean)
    ], MainComponent.prototype, "Card", void 0);
    MainComponent = __decorate([
        core_1.Component({
            selector: 'main-app',
            templateUrl: './main.component.html',
            styles: ["\n.sideNavApp{width:250px;} \n.toolbar-app{position:fixed;top:0px;left:0px;right:0px;z-index:15;}\n.snav-content{padding:10px!important; }\n.snav-container{margin-top:64px; width:100%;min-height: Calc(100vh - 65px)}\na.active {color: #039be5;background-color:rgba(0,0,0,0.3)}"]
        }),
        __metadata("design:paramtypes", [flex_layout_1.ObservableMedia,
            user_service_1.UserService])
    ], MainComponent);
    return MainComponent;
}());
exports.MainComponent = MainComponent;
//# sourceMappingURL=main.component.js.map