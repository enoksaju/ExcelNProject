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
var PolietilenoComponent = /** @class */ (function () {
    function PolietilenoComponent() {
    }
    PolietilenoComponent.prototype.ngOnInit = function () {
        this.galleryImages1 = this.getImages([
            'Content/images/products/termo-1.png'
        ]);
        this.galleryOptions = [{ "image": false, "thumbnailsRemainingCount": true, "thumbnailSize": ngx_gallery_1.NgxGalleryImageSize.Contain, "imageSwipe": true, "width": "100%", "height": "100px" }];
    };
    PolietilenoComponent.prototype.getImages = function (img) {
        var images = new Array();
        img.forEach(function (v, i) { images.push({ small: v, medium: v, big: v }); });
        return images;
    };
    PolietilenoComponent = __decorate([
        core_1.Component({
            selector: "products-polietileno",
            templateUrl: './polietileno.component.html'
        })
    ], PolietilenoComponent);
    return PolietilenoComponent;
}());
exports.PolietilenoComponent = PolietilenoComponent;
//# sourceMappingURL=polietileno.component.js.map