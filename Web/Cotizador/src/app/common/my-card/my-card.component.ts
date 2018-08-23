import {
  Component,
  OnInit,
  Input,
  Output,
  EventEmitter,
  ViewChild,
  AfterViewInit,
  ChangeDetectorRef,
} from '@angular/core';

export enum ClassIcons {
  Mi,
  Fa,
}
export interface IMyCardIcon {
  iconName: string;
  iconType?: ClassIcons;
}

@Component({
  selector: 'my-card',
  templateUrl: './my-card.component.html',
  styleUrls: ['./my-card.component.scss'],
})
export class MyCardComponent implements OnInit, AfterViewInit {
  @Input()
  Titulo: string = 'Card';
  @Input()
  Descripcion: string = '';
  @Input()
  Icono: string;
  @Input()
  HasFontawesomeIcon: boolean = false;
  @Input()
  CardColor: string = 'primary';
  @Input()
  ShowAdd: boolean = false;
  @Input()
  addBtnClass: string = 'grey-200';
  @Output()
  ClickAdd: EventEmitter<any> = new EventEmitter();

  @ViewChild('myCardFooter')
  myCardFooter;

  showFooter: boolean = false;

  getColor() {
    return 'mat-card-theme mat-' + this.CardColor;
  }

  ngAfterViewInit() {
    this.showFooter =
      this.myCardFooter.nativeElement && this.myCardFooter.nativeElement.children.length > 0;
    this.cdRef.detectChanges();
  }

  clickAdd() {
    this.ClickAdd.emit();
  }

  constructor(private cdRef: ChangeDetectorRef) {}

  ngOnInit() {}
}
