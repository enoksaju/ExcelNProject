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
var material_1 = require("@angular/material");
var Z_INDEX_ITEM = 23;
var SmdFabSpeedDialTrigger = /** @class */ (function () {
    function SmdFabSpeedDialTrigger(_parent) {
        this._parent = _parent;
        /**
         * Whether this trigger should spin (360dg) while opening the speed dial
         */
        this.spin = false;
    }
    SmdFabSpeedDialTrigger.prototype._onClick = function (event) {
        if (!this._parent.fixed) {
            this._parent.toggle();
            event.stopPropagation();
        }
    };
    __decorate([
        core_1.HostBinding('class.smd-spin'),
        core_1.Input(),
        __metadata("design:type", Boolean)
    ], SmdFabSpeedDialTrigger.prototype, "spin", void 0);
    __decorate([
        core_1.HostListener('click', ['$event']),
        __metadata("design:type", Function),
        __metadata("design:paramtypes", [Object]),
        __metadata("design:returntype", void 0)
    ], SmdFabSpeedDialTrigger.prototype, "_onClick", null);
    SmdFabSpeedDialTrigger = __decorate([
        core_1.Component({
            selector: 'smd-fab-trigger',
            template: "\n        <ng-content select=\"[md-fab], [mat-fab]\"></ng-content>\n    "
        }),
        __param(0, core_1.Inject(core_1.forwardRef(function () { return SmdFabSpeedDialComponent; }))),
        __metadata("design:paramtypes", [SmdFabSpeedDialComponent])
    ], SmdFabSpeedDialTrigger);
    return SmdFabSpeedDialTrigger;
}());
exports.SmdFabSpeedDialTrigger = SmdFabSpeedDialTrigger;
var SmdFabSpeedDialActions = /** @class */ (function () {
    function SmdFabSpeedDialActions(_parent, renderer) {
        this._parent = _parent;
        this.renderer = renderer;
    }
    SmdFabSpeedDialActions.prototype.ngAfterContentInit = function () {
        var _this = this;
        this._buttons.changes.subscribe(function () {
            _this.initButtonStates();
            _this._parent.setActionsVisibility();
        });
        this.initButtonStates();
    };
    SmdFabSpeedDialActions.prototype.initButtonStates = function () {
        var _this = this;
        this._buttons.toArray().forEach(function (button, i) {
            _this.renderer.setElementClass(button._getHostElement(), 'smd-fab-action-item', true);
            _this.changeElementStyle(button._getHostElement(), 'z-index', '' + (Z_INDEX_ITEM - i));
        });
    };
    SmdFabSpeedDialActions.prototype.show = function () {
        var _this = this;
        if (this._buttons) {
            this._buttons.toArray().forEach(function (button, i) {
                var transitionDelay = 0;
                var transform;
                if (_this._parent.animationMode == 'scale') {
                    // Incremental transition delay of 65ms for each action button
                    transitionDelay = 3 + (65 * i);
                    transform = 'scale(1)';
                }
                else {
                    transform = _this.getTranslateFunction('0');
                }
                _this.changeElementStyle(button._getHostElement(), 'transition-delay', transitionDelay + 'ms');
                _this.changeElementStyle(button._getHostElement(), 'opacity', '1');
                _this.changeElementStyle(button._getHostElement(), 'transform', transform);
            });
        }
    };
    SmdFabSpeedDialActions.prototype.hide = function () {
        var _this = this;
        if (this._buttons) {
            this._buttons.toArray().forEach(function (button, i) {
                var opacity = '1';
                var transitionDelay = 0;
                var transform;
                if (_this._parent.animationMode == 'scale') {
                    transitionDelay = 3 - (65 * i);
                    transform = 'scale(0)';
                    opacity = '0';
                }
                else {
                    transform = _this.getTranslateFunction((55 * (i + 1) - (i * 5)) + 'px');
                }
                _this.changeElementStyle(button._getHostElement(), 'transition-delay', transitionDelay + 'ms');
                _this.changeElementStyle(button._getHostElement(), 'opacity', opacity);
                _this.changeElementStyle(button._getHostElement(), 'transform', transform);
            });
        }
    };
    SmdFabSpeedDialActions.prototype.getTranslateFunction = function (value) {
        var dir = this._parent.direction;
        var translateFn = (dir == 'up' || dir == 'down') ? 'translateY' : 'translateX';
        var sign = (dir == 'down' || dir == 'right') ? '-' : '';
        return translateFn + '(' + sign + value + ')';
    };
    SmdFabSpeedDialActions.prototype.changeElementStyle = function (elem, style, value) {
        // FIXME - Find a way to create a "wrapper" around the action button(s) provided by the user, so we don't change it's style tag
        this.renderer.setElementStyle(elem, style, value);
    };
    __decorate([
        core_1.ContentChildren(material_1.MatButton),
        __metadata("design:type", core_1.QueryList)
    ], SmdFabSpeedDialActions.prototype, "_buttons", void 0);
    SmdFabSpeedDialActions = __decorate([
        core_1.Component({
            selector: 'smd-fab-actions',
            template: "\n        <ng-content select=\"[md-mini-fab], [mat-mini-fab]\"></ng-content>\n    "
        }),
        __param(0, core_1.Inject(core_1.forwardRef(function () { return SmdFabSpeedDialComponent; }))),
        __metadata("design:paramtypes", [SmdFabSpeedDialComponent, core_1.Renderer])
    ], SmdFabSpeedDialActions);
    return SmdFabSpeedDialActions;
}());
exports.SmdFabSpeedDialActions = SmdFabSpeedDialActions;
var SmdFabSpeedDialComponent = /** @class */ (function () {
    function SmdFabSpeedDialComponent(elementRef, renderer) {
        this.elementRef = elementRef;
        this.renderer = renderer;
        this.isInitialized = false;
        this._direction = 'up';
        this._open = false;
        this._animationMode = 'fling';
        /**
         * Whether this speed dial is fixed on screen (user cannot change it by clicking)
         */
        this.fixed = false;
        this.openChange = new core_1.EventEmitter();
    }
    Object.defineProperty(SmdFabSpeedDialComponent.prototype, "open", {
        /**
         * Whether this speed dial is opened
         */
        get: function () {
            return this._open;
        },
        set: function (open) {
            var previousOpen = this._open;
            this._open = open;
            if (previousOpen != this._open) {
                this.openChange.emit(this._open);
                if (this.isInitialized) {
                    this.setActionsVisibility();
                }
            }
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(SmdFabSpeedDialComponent.prototype, "direction", {
        /**
         * The direction of the speed dial. Can be 'up', 'down', 'left' or 'right'
         */
        get: function () {
            return this._direction;
        },
        set: function (direction) {
            var previousDir = this._direction;
            this._direction = direction;
            if (previousDir != this.direction) {
                this._setElementClass(previousDir, false);
                this._setElementClass(this.direction, true);
                if (this.isInitialized) {
                    this.setActionsVisibility();
                }
            }
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(SmdFabSpeedDialComponent.prototype, "animationMode", {
        /**
         * The animation mode to open the speed dial. Can be 'fling' or 'scale'
         */
        get: function () {
            return this._animationMode;
        },
        set: function (animationMode) {
            var _this = this;
            var previousAnimationMode = this._animationMode;
            this._animationMode = animationMode;
            if (previousAnimationMode != this._animationMode) {
                this._setElementClass(previousAnimationMode, false);
                this._setElementClass(this.animationMode, true);
                if (this.isInitialized) {
                    // To start another detect lifecycle and force the "close" on the action buttons
                    Promise.resolve(null).then(function () { return _this.open = false; });
                }
            }
        },
        enumerable: true,
        configurable: true
    });
    SmdFabSpeedDialComponent.prototype.ngAfterContentInit = function () {
        this.isInitialized = true;
        this.setActionsVisibility();
        this._setElementClass(this.direction, true);
        this._setElementClass(this.animationMode, true);
    };
    /**
     * Toggle the open state of this speed dial
     */
    SmdFabSpeedDialComponent.prototype.toggle = function () {
        this.open = !this.open;
    };
    SmdFabSpeedDialComponent.prototype._onClick = function () {
        if (!this.fixed && this.open) {
            this.open = false;
        }
    };
    SmdFabSpeedDialComponent.prototype.setActionsVisibility = function () {
        if (this.open) {
            this._childActions.show();
        }
        else {
            this._childActions.hide();
        }
    };
    SmdFabSpeedDialComponent.prototype._setElementClass = function (elemClass, isAdd) {
        this.renderer.setElementClass(this.elementRef.nativeElement, "smd-" + elemClass, isAdd);
    };
    __decorate([
        core_1.Input(),
        __metadata("design:type", Boolean)
    ], SmdFabSpeedDialComponent.prototype, "fixed", void 0);
    __decorate([
        core_1.HostBinding('class.smd-opened'),
        core_1.Input(),
        __metadata("design:type", Object),
        __metadata("design:paramtypes", [Boolean])
    ], SmdFabSpeedDialComponent.prototype, "open", null);
    __decorate([
        core_1.Input(),
        __metadata("design:type", Object),
        __metadata("design:paramtypes", [String])
    ], SmdFabSpeedDialComponent.prototype, "direction", null);
    __decorate([
        core_1.Input(),
        __metadata("design:type", Object),
        __metadata("design:paramtypes", [String])
    ], SmdFabSpeedDialComponent.prototype, "animationMode", null);
    __decorate([
        core_1.Output(),
        __metadata("design:type", core_1.EventEmitter)
    ], SmdFabSpeedDialComponent.prototype, "openChange", void 0);
    __decorate([
        core_1.ContentChild(SmdFabSpeedDialActions),
        __metadata("design:type", SmdFabSpeedDialActions)
    ], SmdFabSpeedDialComponent.prototype, "_childActions", void 0);
    __decorate([
        core_1.HostListener('click'),
        __metadata("design:type", Function),
        __metadata("design:paramtypes", []),
        __metadata("design:returntype", void 0)
    ], SmdFabSpeedDialComponent.prototype, "_onClick", null);
    SmdFabSpeedDialComponent = __decorate([
        core_1.Component({
            selector: 'smd-fab-speed-dial',
            template: "\n        <div class=\"smd-fab-speed-dial-container\">\n            <ng-content select=\"smd-fab-trigger\"></ng-content>\n            <ng-content select=\"smd-fab-actions\"></ng-content>\n        </div>\n    ",
            styles: ["\nsmd-fab-speed-dial {\n  display: inline-block;\n}\nsmd-fab-speed-dial.smd-opened .smd-fab-speed-dial-container smd-fab-trigger.smd-spin {\n  -webkit-transform: rotate(360deg);\n  transform: rotate(360deg);\n}\nsmd-fab-speed-dial .smd-fab-speed-dial-container {\n  position: relative;\n  display: -webkit-box;\n  display: -webkit-flex;\n  display: flex;\n  -webkit-box-align: center;\n  -webkit-align-items: center;\n  align-items: center;\n  z-index: 20;\n}\nsmd-fab-speed-dial .smd-fab-speed-dial-container smd-fab-trigger {\n  pointer-events: auto;\n  z-index: 24;\n}\nsmd-fab-speed-dial .smd-fab-speed-dial-container smd-fab-trigger.smd-spin {\n  -webkit-transition: all 0.6s cubic-bezier(0.4, 0, 0.2, 1);\n  transition: all 0.6s cubic-bezier(0.4, 0, 0.2, 1);\n}\nsmd-fab-speed-dial .smd-fab-speed-dial-container smd-fab-actions {\n  display: -webkit-box;\n  display: -webkit-flex;\n  display: flex;\n  height: auto;\n}\nsmd-fab-speed-dial.smd-fling .smd-fab-speed-dial-container smd-fab-actions .smd-fab-action-item {\n  display: block;\n  opacity: 1;\n  -webkit-transition: all 0.3s cubic-bezier(0.55, 0, 0.55, 0.2);\n  transition: all 0.3s cubic-bezier(0.55, 0, 0.55, 0.2);\n}\nsmd-fab-speed-dial.smd-scale .smd-fab-speed-dial-container smd-fab-actions .smd-fab-action-item {\n  -webkit-transform: scale(0);\n  transform: scale(0);\n  -webkit-transition: all 0.3s cubic-bezier(0.55, 0, 0.55, 0.2);\n  transition: all 0.3s cubic-bezier(0.55, 0, 0.55, 0.2);\n  -webkit-transition-duration: 0.14286s;\n  transition-duration: 0.14286s;\n}\nsmd-fab-speed-dial.smd-down .smd-fab-speed-dial-container {\n  -webkit-box-orient: vertical;\n  -webkit-box-direction: normal;\n  -webkit-flex-direction: column;\n  flex-direction: column;\n}\nsmd-fab-speed-dial.smd-down .smd-fab-speed-dial-container smd-fab-trigger {\n  -webkit-box-ordinal-group: 2;\n  -webkit-order: 1;\n  order: 1;\n}\nsmd-fab-speed-dial.smd-down .smd-fab-speed-dial-container smd-fab-actions {\n  -webkit-box-orient: vertical;\n  -webkit-box-direction: normal;\n  -webkit-flex-direction: column;\n  flex-direction: column;\n  -webkit-box-ordinal-group: 3;\n  -webkit-order: 2;\n  order: 2;\n}\nsmd-fab-speed-dial.smd-down .smd-fab-speed-dial-container smd-fab-actions .smd-fab-action-item {\n  margin-top: 10px;\n}\nsmd-fab-speed-dial.smd-up .smd-fab-speed-dial-container {\n  -webkit-box-orient: vertical;\n  -webkit-box-direction: normal;\n  -webkit-flex-direction: column;\n  flex-direction: column;\n}\nsmd-fab-speed-dial.smd-up .smd-fab-speed-dial-container smd-fab-trigger {\n  -webkit-box-ordinal-group: 3;\n  -webkit-order: 2;\n  order: 2;\n}\nsmd-fab-speed-dial.smd-up .smd-fab-speed-dial-container smd-fab-actions {\n  -webkit-box-orient: vertical;\n  -webkit-box-direction: reverse;\n  -webkit-flex-direction: column-reverse;\n  flex-direction: column-reverse;\n  -webkit-box-ordinal-group: 2;\n  -webkit-order: 1;\n  order: 1;\n}\nsmd-fab-speed-dial.smd-up .smd-fab-speed-dial-container smd-fab-actions .smd-fab-action-item {\n  margin-bottom: 10px;\n}\nsmd-fab-speed-dial.smd-left .smd-fab-speed-dial-container {\n  -webkit-box-orient: horizontal;\n  -webkit-box-direction: normal;\n  -webkit-flex-direction: row;\n  flex-direction: row;\n}\nsmd-fab-speed-dial.smd-left .smd-fab-speed-dial-container smd-fab-trigger {\n  -webkit-box-ordinal-group: 3;\n  -webkit-order: 2;\n  order: 2;\n}\nsmd-fab-speed-dial.smd-left .smd-fab-speed-dial-container smd-fab-actions {\n  -webkit-box-orient: horizontal;\n  -webkit-box-direction: normal;\n  -webkit-flex-direction: row-reverse;\n  flex-direction: row-reverse;\n  -webkit-box-ordinal-group: 2;\n  -webkit-order: 1;\n  order: 1;\n}\nsmd-fab-speed-dial.smd-left .smd-fab-speed-dial-container smd-fab-actions .smd-fab-action-item {\n  margin-right: 10px;\n}\nsmd-fab-speed-dial.smd-right .smd-fab-speed-dial-container {\n  -webkit-box-orient: horizontal;\n  -webkit-box-direction: normal;\n  -webkit-flex-direction: row;\n  flex-direction: row;\n}\nsmd-fab-speed-dial.smd-right .smd-fab-speed-dial-container smd-fab-trigger {\n  -webkit-box-ordinal-group: 2;\n  -webkit-order: 1;\n  order: 1;\n}\nsmd-fab-speed-dial.smd-right .smd-fab-speed-dial-container smd-fab-actions {\n  -webkit-box-orient: horizontal;\n  -webkit-box-direction: normal;\n  -webkit-flex-direction: row;\n  flex-direction: row;\n  -webkit-box-ordinal-group: 3;\n  -webkit-order: 2;\n  order: 2;\n}\nsmd-fab-speed-dial.smd-right .smd-fab-speed-dial-container smd-fab-actions .smd-fab-action-item {\n  margin-left: 10px;\n}\n"],
            encapsulation: core_1.ViewEncapsulation.None
        }),
        __metadata("design:paramtypes", [core_1.ElementRef, core_1.Renderer])
    ], SmdFabSpeedDialComponent);
    return SmdFabSpeedDialComponent;
}());
exports.SmdFabSpeedDialComponent = SmdFabSpeedDialComponent;
//# sourceMappingURL=fab-speed-dial.js.map