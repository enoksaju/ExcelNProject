import { Component, OnInit, ChangeDetectionStrategy, Input, Inject, NgZone } from '@angular/core';
import { CdkDragDrop, moveItemInArray, transferArrayItem } from '@angular/cdk/drag-drop';
import { CalendarItem, PlaneacionProduccionService, statusProcesoProduccion } from '../../Services/planeacion-produccion.service';
import { isDate } from 'util';
import { MatBottomSheet, MatBottomSheetRef, MAT_BOTTOM_SHEET_DATA } from '@angular/material/bottom-sheet';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSelectionListChange } from '@angular/material/list';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-item-ot',
  templateUrl: './item-ot.component.html',
  styleUrls: ['./item-ot.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ItemOTComponent implements OnInit {

  @Input() Items: CalendarItem[];
  @Input() Dia: Date = null;
  @Input() unasigned: boolean = false;

  loading: boolean;
  filterText: string = "";
  constructor(private planeacionService: PlaneacionProduccionService, private bottomSheet: MatBottomSheet) { }

  ngOnInit(): void {
    this.filterText = "";
  }
  isDate(val: any) {
    return isDate(val);
  }

  get totalMetros(): number {
    if (!this.Items) return 0;
    const sum = this.Items.reduce((sum, curr) => sum + curr.Ml, 0);
    return sum;
  }


  private updatePrioridad(cont: CalendarItem[]) {
    for (let i = 0; i < cont.length; i++) {
      let entity = cont[i];
      entity.Prioridad = i;
      // this.planeacionService.UpdateCalendarItem(entity);
    }
    return this.planeacionService.UpdateArrayCalendarItems(cont);
  }

  drop(event: CdkDragDrop<CalendarItem[]>) {

    let itm = (event.item.data as CalendarItem);
    let prevCont = event.previousContainer.data;
    let cont = event.container.data;
    let prevIndex = event.previousIndex;
    let index = event.currentIndex;
    itm.FechaProgramada = !this.unasigned ? this.Dia as Date : null;
    itm.isLoading = true;
    if (event.previousContainer === event.container) {
      moveItemInArray(cont, prevIndex, index);
      this.updatePrioridad(cont)
        .finally(() => { itm.isLoading = false; });
    } else {
      //  verifico y gurado en la BD si un item cambia de contenedor o se asigna al programa

      transferArrayItem(prevCont, this.Items, prevIndex, index);
      this.planeacionService.UpdateCalendarItem(itm)
        .then(v => {
          if (!v) { transferArrayItem(cont, prevCont, index, prevIndex) }
          else {
            if (itm.FechaProgramada !== null) {
              this.updatePrioridad(cont);
            } else {
              cont.sort((a, b) => {
                if (a.OT < b.OT) return -1;
                else if (a.OT > b.OT) return 1;
                else return 0;
              })
            }
          }

        }).catch(e => {
          console.log(e)
        }).finally(() => {
          itm.isLoading = false;
        });

    }
  }
  itemClick(item: CalendarItem) {
    this.bottomSheet.open(OptionsSelectedItemOverviewSheet, { data: item });
  }
}

@Component({
  selector: 'OptionsSelectedItemOverviewSheet',
  templateUrl: './option-selected-item.component.html'
}) export class OptionsSelectedItemOverviewSheet {


  constructor(private _bottomSheetRef: MatBottomSheetRef<OptionsSelectedItemOverviewSheet>,
    @Inject(MAT_BOTTOM_SHEET_DATA) public data: CalendarItem,
    public dialog: MatDialog,
    private router: Router) { }

  showDetails() {
    this._bottomSheetRef.dismiss();
    const dialogRef = this.dialog.open(DialogDetailsCalendarItem, { data: this.data });
    dialogRef.afterClosed().subscribe(u => {
      console.log('dialog details was closed');
    })

  }

  showProgress() {
    this._bottomSheetRef.dismiss();
    this.router.navigate(['cal/progreso/', this.data.OT]);
  }
  showDocument() {
    this._bottomSheetRef.dismiss();

  }
}

@Component({
  templateUrl: './item-ot-details-template.html'
}) export class DialogDetailsCalendarItem {

  t: { key: string, value: number }[];

  constructor(public dialogRef: MatDialogRef<DialogDetailsCalendarItem>, @Inject(MAT_DIALOG_DATA) public data: CalendarItem
  ) {
    console.log(data);
    this.t = this.ToArray(statusProcesoProduccion);

  }

  ToArray(enumme): { key: string, value: number }[] {
    const StringIsNumber = value => isNaN(Number(value)) === false;
    return Object.keys(enumme)
      .filter(StringIsNumber)
      .map(key => {
        return { key: enumme[key], value: Number.parseInt(key) };
      });
  }

  hasFlag(en: any, flag: statusProcesoProduccion) {
    return (en & flag) == flag;
  }
  changeValue(event: MatSelectionListChange) {

    this.data.Estatus = event.source.selectedOptions.selected.reduce((sum, curr) => sum + curr.value, 0)
  }
}
