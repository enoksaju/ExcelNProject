import { Component, OnInit } from '@angular/core'
import { NgxGalleryOptions, NgxGalleryImage, NgxGalleryAnimation, NgxGalleryImageSize } from 'ngx-gallery';

@Component({
  selector: "products-etiquetas",
  templateUrl: './etiquetas.component.html'
}) export class EtiquetasComponent implements OnInit {
  galleryOptions: NgxGalleryOptions[];
  galleryImages1: NgxGalleryImage[];
  galleryImages2: NgxGalleryImage[];
  galleryImages3: NgxGalleryImage[];

  ngOnInit(): void {

    this.galleryImages1 = this.getImages([
      'Content/images/products/etiquetas-1.png',
      'Content/images/products/etiquetas-2.png',
      'Content/images/products/etiquetas-3.png'
    ]);
    this.galleryImages2 = this.getImages([
      'Content/images/products/etiquetas-4.png',
      'Content/images/products/etiquetas-5.png',
      'Content/images/products/etiquetas-6.png'
    ]);
    this.galleryImages3 = this.getImages([
      'Content/images/products/etiquetas-7.png',
      'Content/images/products/etiquetas-8.png',
    ]);
    this.galleryOptions = [{ "image": false, "thumbnailsRemainingCount": true, "thumbnailSize": NgxGalleryImageSize.Contain, "imageSwipe": true, "width": "100%", "height": "100px" }];
  };

  private getImages(img: string[]): NgxGalleryImage[] {
    let images = new Array<NgxGalleryImage>();
    img.forEach((v, i) => { images.push({ small: v, medium: v, big: v }); });
    return images;
  }
};