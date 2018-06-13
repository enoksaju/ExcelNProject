"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var ngx_gallery_1 = require("ngx-gallery");
var BolsasComponent = /** @class */ (function () {
    function BolsasComponent() {
    }
    BolsasComponent.prototype.ngOnInit = function () {
        this.galleryImages1 = this.getImages([
            'Content/images/products/bolsas-1.jpg',
            'Content/images/products/bolsas-2.jpg',
            'Content/images/products/bolsas-3.jpg',
            'Content/images/products/bolsas-4.jpg'
        ]);
        this.galleryImages2 = this.getImages([
            'Content/images/products/bolsas-5.png'
        ]);
        this.galleryImages3 = this.getImages([
            'Content/images/products/bolsas-6.png',
            'Content/images/products/bolsas-7.png',
            'Content/images/products/bolsas-8.png'
        ]);
        this.galleryImages4 = this.getImages([
            'Content/images/products/bolsas-9.png',
            'Content/images/products/bolsas-10.png',
            'Content/images/products/bolsas-11.png'
        ]);
        this.galleryImages5 = this.getImages([
            'Content/images/products/bolsas-12.jpg',
            'Content/images/products/bolsas-13.jpg',
            'Content/images/products/bolsas-14.png'
        ]);
        this.galleryOptions = [{ "image": false, "thumbnailsRemainingCount": true, "thumbnailSize": ngx_gallery_1.NgxGalleryImageSize.Contain, "imageSwipe": true, "width": "100%", "height": "100px" }];
    };
    ;
    BolsasComponent.prototype.getImages = function (img) {
        var images = new Array();
        img.forEach(function (v, i) { images.push({ small: v, medium: v, big: v }); });
        return images;
    };
    BolsasComponent = __decorate([
        core_1.Component({
            selector: "products-bolsas",
            templateUrl: './bolsas.component.html'
        })
    ], BolsasComponent);
    return BolsasComponent;
}());
exports.BolsasComponent = BolsasComponent;
;
//# sourceMappingURL=bolsas.component.js.map