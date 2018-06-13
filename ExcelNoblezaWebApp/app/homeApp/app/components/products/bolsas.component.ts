import { Component, OnInit } from '@angular/core'
import { NgxGalleryOptions, NgxGalleryImage, NgxGalleryAnimation, NgxGalleryImageSize } from 'ngx-gallery';

@Component({
  selector: "products-bolsas",
  templateUrl: './bolsas.component.html'
}) export class BolsasComponent implements OnInit {
  galleryOptions: NgxGalleryOptions[];
  galleryImages1: NgxGalleryImage[];
  galleryImages2: NgxGalleryImage[];
  galleryImages3: NgxGalleryImage[];
  galleryImages4: NgxGalleryImage[];
  galleryImages5: NgxGalleryImage[];

  ngOnInit(): void {

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
    this.galleryOptions = [{ "image": false, "thumbnailsRemainingCount": true, "thumbnailSize": NgxGalleryImageSize.Contain, "imageSwipe": true, "width": "100%", "height": "100px" }];
  };

  private getImages(img: string[]): NgxGalleryImage[] {
    let images = new Array<NgxGalleryImage>();
    img.forEach((v, i) => { images.push({ small: v, medium: v, big: v }); });
    return images;
  }
};