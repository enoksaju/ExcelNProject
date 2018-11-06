import { Component, OnInit } from '@angular/core'
import { NgxGalleryOptions, NgxGalleryImage, NgxGalleryAnimation, NgxGalleryImageSize } from 'ngx-gallery';

@Component({
  selector: 'products-innovaciones',
  templateUrl: './innovaciones.component.html'
}) export class InnovacionesComponent implements OnInit {
  galleryOptions: NgxGalleryOptions[];
  galleryImages1: NgxGalleryImage[];
  galleryImages2: NgxGalleryImage[];

  ngOnInit(): void {
    this.galleryImages1 = this.getImages([
      'Content/images/products/inno-1.jpg',
      'Content/images/products/inno-2.jpg',
      'Content/images/products/inno-3.jpg'
    ]);

    this.galleryImages2 = this.getImages([
      'Content/images/products/inno-4.jpg'
    ]);

    this.galleryOptions = [{ "image": false, "thumbnailsRemainingCount": true, "thumbnailSize": NgxGalleryImageSize.Contain, "imageSwipe": true, "width": "100%", "height": "100px" }];
  }

  private getImages(img: string[]): NgxGalleryImage[] {
    let images = new Array<NgxGalleryImage>();
    img.forEach((v, i) => { images.push({ small: v, medium: v, big: v }); });
    return images;
  }

}