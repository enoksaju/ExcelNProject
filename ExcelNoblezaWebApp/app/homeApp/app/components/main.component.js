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
var MainComponent = /** @class */ (function () {
    function MainComponent(media) {
        this.media = media;
        this.tab = 1;
        //The time to show the next photo
        this.NextPhotoInterval = 5000;
        //Looping or not
        this.noLoopSlides = false;
        //Photos
        this.slides = [];
        this.addNewSlides();
    }
    MainComponent.prototype.ngOnInit = function () {
    };
    MainComponent.prototype.addNewSlides = function () {
        this.slides.push({ image: '../../../../../../../Content/images/slide/gallery-01.jpg', text: 'Nuestro personal está en entrenamiento continuo' }, { image: '../../../../../../../Content/images/slide/gallery-02.jpg', text: '' }, { image: '../../../../../../../Content/images/slide/gallery-03.jpg', text: 'Tecnología y creatividad en empaques flexibles' }, { image: '../../../../../../../Content/images/slide/gallery-04.jpg', text: 'Somos la industria trabajando en la imagen de sus productos' });
    };
    MainComponent.prototype.setTab = function (IndexTab) {
        this.tab = IndexTab;
    };
    MainComponent = __decorate([
        core_1.Component({
            selector: 'main-component',
            templateUrl: './main.component.html',
            styleUrls: ['./main.component.css']
        }),
        __metadata("design:paramtypes", [flex_layout_1.ObservableMedia])
    ], MainComponent);
    return MainComponent;
}());
exports.MainComponent = MainComponent;
//# sourceMappingURL=main.component.js.map