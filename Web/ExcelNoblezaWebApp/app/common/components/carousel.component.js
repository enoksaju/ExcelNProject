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
var Direction;
(function (Direction) {
    Direction[Direction["UNKNOWN"] = 0] = "UNKNOWN";
    Direction[Direction["NEXT"] = 1] = "NEXT";
    Direction[Direction["PREV"] = 2] = "PREV";
})(Direction = exports.Direction || (exports.Direction = {}));
var Carousel = /** @class */ (function () {
    function Carousel() {
        this.slides = [];
        this.destroyed = false;
    }
    Object.defineProperty(Carousel.prototype, "interval", {
        get: function () {
            return this._interval;
        },
        set: function (value) {
            this._interval = value;
            this.restartTimer();
        },
        enumerable: true,
        configurable: true
    });
    Carousel.prototype.ngOnDestroy = function () {
        this.destroyed = true;
    };
    Carousel.prototype.select = function (nextSlide, direction) {
        if (direction === void 0) { direction = Direction.UNKNOWN; }
        var nextIndex = nextSlide.index;
        if (direction === Direction.UNKNOWN) {
            direction = nextIndex > this.getCurrentIndex() ? Direction.NEXT : Direction.PREV;
        }
        // Prevent this user-triggered transition from occurring if there is already one in progress
        if (nextSlide && nextSlide !== this.currentSlide) {
            this.goNext(nextSlide, direction);
        }
    };
    Carousel.prototype.goNext = function (slide, direction) {
        if (this.destroyed) {
            return;
        }
        slide.direction = direction;
        slide.active = true;
        if (this.currentSlide) {
            this.currentSlide.direction = direction;
            this.currentSlide.active = false;
        }
        this.currentSlide = slide;
        // every time you change slides, reset the timer
        this.restartTimer();
    };
    Carousel.prototype.getSlideByIndex = function (index) {
        var len = this.slides.length;
        for (var i = 0; i < len; ++i) {
            if (this.slides[i].index === index) {
                return this.slides[i];
            }
        }
    };
    Carousel.prototype.getCurrentIndex = function () {
        return !this.currentSlide ? 0 : this.currentSlide.index;
    };
    Carousel.prototype.next = function () {
        var newIndex = (this.getCurrentIndex() + 1) % this.slides.length;
        if (newIndex === 0 && this.noWrap) {
            this.pause();
            return;
        }
        return this.select(this.getSlideByIndex(newIndex), Direction.NEXT);
    };
    Carousel.prototype.prev = function () {
        var newIndex = this.getCurrentIndex() - 1 < 0 ? this.slides.length - 1 : this.getCurrentIndex() - 1;
        if (this.noWrap && newIndex === this.slides.length - 1) {
            this.pause();
            return;
        }
        return this.select(this.getSlideByIndex(newIndex), Direction.PREV);
    };
    Carousel.prototype.restartTimer = function () {
        var _this = this;
        this.resetTimer();
        var interval = +this.interval;
        if (!isNaN(interval) && interval > 0) {
            this.currentInterval = setInterval(function () {
                var nInterval = +_this.interval;
                if (_this.isPlaying && !isNaN(_this.interval) && nInterval > 0 && _this.slides.length) {
                    _this.next();
                }
                else {
                    _this.pause();
                }
            }, interval);
        }
    };
    Carousel.prototype.resetTimer = function () {
        if (this.currentInterval) {
            clearInterval(this.currentInterval);
            this.currentInterval = null;
        }
    };
    Carousel.prototype.play = function () {
        if (!this.isPlaying) {
            this.isPlaying = true;
            this.restartTimer();
        }
    };
    Carousel.prototype.pause = function () {
        if (!this.noPause) {
            this.isPlaying = false;
            this.resetTimer();
        }
    };
    Carousel.prototype.addSlide = function (slide) {
        slide.index = this.slides.length;
        this.slides.push(slide);
        if (this.slides.length === 1 || slide.active) {
            this.select(this.slides[this.slides.length - 1]);
            if (this.slides.length === 1) {
                this.play();
            }
        }
        else {
            slide.active = false;
        }
    };
    Carousel.prototype.removeSlide = function (slide) {
        this.slides.splice(slide.index, 1);
        if (this.slides.length === 0) {
            this.currentSlide = null;
            return;
        }
        for (var i = 0; i < this.slides.length; i++) {
            this.slides[i].index = i;
        }
    };
    __decorate([
        core_1.Input(),
        __metadata("design:type", Boolean)
    ], Carousel.prototype, "noWrap", void 0);
    __decorate([
        core_1.Input(),
        __metadata("design:type", Boolean)
    ], Carousel.prototype, "noPause", void 0);
    __decorate([
        core_1.Input(),
        __metadata("design:type", Boolean)
    ], Carousel.prototype, "noTransition", void 0);
    __decorate([
        core_1.Input(),
        __metadata("design:type", Number),
        __metadata("design:paramtypes", [Number])
    ], Carousel.prototype, "interval", null);
    Carousel = __decorate([
        core_1.Component({
            selector: 'carousel',
            templateUrl: './carousel.component.html',
            styleUrls: ['./carousel.component.css']
        })
    ], Carousel);
    return Carousel;
}());
exports.Carousel = Carousel;
var Slide = /** @class */ (function () {
    function Slide(carousel) {
        this.carousel = carousel;
        this.addClass = true;
    }
    Slide.prototype.ngOnInit = function () {
        this.carousel.addSlide(this);
    };
    Slide.prototype.ngOnDestroy = function () {
        this.carousel.removeSlide(this);
    };
    __decorate([
        core_1.Input(),
        __metadata("design:type", Number)
    ], Slide.prototype, "index", void 0);
    __decorate([
        core_1.Input(),
        __metadata("design:type", Number)
    ], Slide.prototype, "direction", void 0);
    __decorate([
        core_1.HostBinding('class.active'),
        core_1.Input(),
        __metadata("design:type", Boolean)
    ], Slide.prototype, "active", void 0);
    __decorate([
        core_1.HostBinding('class.item'),
        core_1.HostBinding('class.carousel-item'),
        __metadata("design:type", Boolean)
    ], Slide.prototype, "addClass", void 0);
    Slide = __decorate([
        core_1.Component({
            selector: 'slide',
            templateUrl: './carousel.slide.component.html'
        }),
        __metadata("design:paramtypes", [Carousel])
    ], Slide);
    return Slide;
}());
exports.Slide = Slide;
//# sourceMappingURL=carousel.component.js.map