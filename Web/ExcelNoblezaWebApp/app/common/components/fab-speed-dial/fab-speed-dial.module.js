"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var common_1 = require("@angular/common");
var material_1 = require("@angular/material");
var fab_speed_dial_1 = require("./fab-speed-dial");
var MatFabActionModule = /** @class */ (function () {
    function MatFabActionModule() {
    }
    MatFabActionModule = __decorate([
        core_1.NgModule({
            imports: [
                common_1.CommonModule,
                material_1.MatButtonModule
            ],
            declarations: [
                fab_speed_dial_1.SmdFabSpeedDialActions, fab_speed_dial_1.SmdFabSpeedDialComponent, fab_speed_dial_1.SmdFabSpeedDialTrigger
            ],
            exports: [
                fab_speed_dial_1.SmdFabSpeedDialActions, fab_speed_dial_1.SmdFabSpeedDialComponent, fab_speed_dial_1.SmdFabSpeedDialTrigger
            ],
            entryComponents: [
                fab_speed_dial_1.SmdFabSpeedDialActions, fab_speed_dial_1.SmdFabSpeedDialComponent, fab_speed_dial_1.SmdFabSpeedDialTrigger
            ]
        })
    ], MatFabActionModule);
    return MatFabActionModule;
}());
exports.MatFabActionModule = MatFabActionModule;
//# sourceMappingURL=fab-speed-dial.module.js.map