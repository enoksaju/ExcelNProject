import { Component, OnInit } from '@angular/core'
import { NgxGalleryOptions, NgxGalleryImage, NgxGalleryAnimation, NgxGalleryImageSize } from 'ngx-gallery';
import { Observable } from 'rxjs/Rx';


@Component({
  selector: 'products-peliculas',
  templateUrl: './peliculas.component.html'
}) export class PeliculasComponent implements OnInit {
  galleryOptions: NgxGalleryOptions[];
  galleryImages: NgxGalleryImage[];

  ngOnInit(): void {
    this.galleryImages = this.getImages([
      'Content/images/products/peliculas-1.jpg',
      'Content/images/products/peliculas-2.jpg',
      'Content/images/products/peliculas-3.jpg'
    ]);
    this.galleryOptions = [{ "image": false, "thumbnailsRemainingCount": true, "thumbnailSize": NgxGalleryImageSize.Contain, "imageSwipe": true, "width": "100%", "height": "100px" }];
  }

  private getImages(img: string[]): NgxGalleryImage[] {
    let images = new Array<NgxGalleryImage>();
    img.forEach((v, i) => { images.push({ small: v, medium: v, big: v }); });
    return images;
  }

}