import {
  Component,
  OnInit,
  Input,
  Output,
  EventEmitter,
  ViewChild,
  AfterViewInit,
  ChangeDetectorRef,
  Renderer2,
  ElementRef
} from '@angular/core';
import { ObservableMedia } from '@angular/flex-layout';
import { MatBottomSheet } from '@angular/material';
import {
  BottomActionsMyCardComponent,
  MyBottomSheetButton
} from './bottom-actions-my-card.component';

export enum ClassIcons {
  Mi,
  Fa
}
export interface IMyCardIcon {
  iconName: string;
  iconType?: ClassIcons;
}

@Component({
  selector: 'my-card',
  templateUrl: './my-card.component.html',
  styleUrls: ['./my-card.component.scss']
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
  ColorClass: string = null;
  @Input()
  ShowAdd: boolean = false;
  @Input()
  ShowPrint: boolean = false;
  @Input()
  ShowMore: boolean = false;
  @Input()
  ExtraButtons: MyBottomSheetButton[];
  @Input()
  addBtnClass: string = 'grey-200';
  @Output()
  ClickAdd: EventEmitter<any> = new EventEmitter();
  @Output()
  ClickAction: EventEmitter<any> = new EventEmitter();

  @ViewChild('myCardFooter')
  myCardFooter;

  showFooter: boolean = false;

  getColor() {
    if (this.ColorClass) {
      return this.ColorClass;
    } else {
      return 'bg-' + this.CardColor;
    }
  }

  ngAfterViewInit() {
    this.showFooter =
      this.myCardFooter.nativeElement &&
      this.myCardFooter.nativeElement.children.length > 0;
    this.cdRef.detectChanges();
  }

  clickAdd() {
    this.ClickAdd.emit();
  }

  Print() {
    const doc = window.open();
    const logo = document.getElementsByClassName('logo');
    doc.window.document.write(`
    <html>
      <head>
      ${document.head.innerHTML}
      <head>
      <body class="lt mat-typography">
        ${this.elRef.nativeElement.innerHTML}
      </body>
      <footer>
          ${logo[0].outerHTML}
      </footer>
    </html>
    `);
    for (const itm of Array.from(
      doc.window.document.getElementsByClassName('autoOverflow')
    )) {
      this.render.removeClass(itm, 'autoOverflow');
    }

    setTimeout(() => {
      doc.window.print();
      doc.window.close();
    }, 100);
  }

  openBottomSheet() {
    this.bottomShet
      .open(BottomActionsMyCardComponent, {
        data: {
          hasAddButton: this.ShowAdd,
          hasPrintButton: this.ShowPrint,
          extraButtons: this.ExtraButtons
        }
      })
      .afterDismissed()
      .toPromise()
      .then(res => {
        switch (res) {
          case 'add':
            this.clickAdd();
            break;
          case 'print':
            this.Print();
            break;
          default:
            this.ClickAction.emit(res);
            break;
        }
      });
  }

  constructor(
    private cdRef: ChangeDetectorRef,
    private media: ObservableMedia,
    private bottomShet: MatBottomSheet,
    private render: Renderer2,
    private elRef: ElementRef
  ) {
    window.onbeforeprint = e => {};
  }

  ngOnInit() {}
}
