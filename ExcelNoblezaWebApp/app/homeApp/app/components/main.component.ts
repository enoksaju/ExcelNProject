import { Component , OnInit} from '@angular/core';
import { Carousel , Slide} from '../../../common/components/carousel.component';
import { ObservableMedia } from '@angular/flex-layout';

@Component({
  selector: 'main-component',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent implements OnInit {
  private tab: number = 1;

  //The time to show the next photo
  private NextPhotoInterval: number = 5000;
  //Looping or not
  private noLoopSlides: boolean = false;
  //Photos
  private slides: Array<any> = [];
  
  constructor(public media: ObservableMedia) {
    this.addNewSlides();
  }
  ngOnInit(): void {

  }

  private addNewSlides() {
    this.slides.push(
      { image: '../../../../../../../Content/images/slide/gallery-01.jpg', text: 'Nuestro personal está en entrenamiento continuo' },
      { image: '../../../../../../../Content/images/slide/gallery-02.jpg', text: '' },
      { image: '../../../../../../../Content/images/slide/gallery-03.jpg', text: 'Tecnología y creatividad en empaques flexibles' },
      { image: '../../../../../../../Content/images/slide/gallery-04.jpg', text: 'Somos la industria trabajando en la imagen de sus productos' }
    )
  }

  private setTab(IndexTab: number): void {
    this.tab = IndexTab;
  }
}