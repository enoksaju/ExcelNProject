import { Component, OnDestroy, Input, OnInit, HostBinding } from '@angular/core';
@Component({
  selector: 'card-container',
  templateUrl: './cardcontainer.component.html',
  styleUrls: ['./cardcontainer.component.css']
})
export class CardContentComponent {

  @Input() Titulo: string;
  @Input() Imagen: string;
}
