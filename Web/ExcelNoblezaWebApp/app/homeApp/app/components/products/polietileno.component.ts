import { Component, OnInit } from '@angular/core';
import { NgxGalleryOptions, NgxGalleryImage, NgxGalleryAnimation, NgxGalleryImageSize } from 'ngx-gallery';


@Component({
  selector: "products-polietileno",
  templateUrl: './polietileno.component.html'
}) export class PolietilenoComponent implements OnInit {
  galleryOptions: NgxGalleryOptions[];
  galleryImages1: NgxGalleryImage[];

  ngOnInit(): void {
    this.galleryImages1 = this.getImages([
      'Content/images/products/termo-1.png'
    ]);
    this.galleryOptions = [{ "image": false, "thumbnailsRemainingCount": true, "thumbnailSize": NgxGalleryImageSize.Contain, "imageSwipe": true, "width": "100%", "height": "100px" }];
  }

  private getImages(img: string[]): NgxGalleryImage[] {
    let images = new Array<NgxGalleryImage>();
    img.forEach((v, i) => { images.push({ small: v, medium: v, big: v }); });
    return images;
  }
}
