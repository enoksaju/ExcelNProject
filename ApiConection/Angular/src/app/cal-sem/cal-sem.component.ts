import { Component, OnInit, ViewEncapsulation, OnDestroy } from '@angular/core';
import { CdkDragDrop, moveItemInArray, transferArrayItem } from '@angular/cdk/drag-drop';
import { PlaneacionProduccionService, CalendarItem } from '../Services/planeacion-produccion.service';
import { Subscription } from 'rxjs';
import { DialogsService } from '../Services/Dialog/dialogs.service';
import { DialogButtonsFlags, DialogIcons } from '../Services/Dialog/dialog.component';

@Component({
  selector: 'app-cal-sem',
  templateUrl: './cal-sem.component.html',
  styleUrls: ['./cal-sem.component.scss'],
  host: { '[class.hostColumn]': 'true' }
})
export class CalSemComponent implements OnInit, OnDestroy {

  subUnasignedItems: Subscription;
  subSemanaData: Subscription;
  UnasignedItems: CalendarItem[];
  Dia1: CalendarItem[];
  Dia2: CalendarItem[];
  Dia3: CalendarItem[];
  Dia4: CalendarItem[];
  Dia5: CalendarItem[];
  Dia6: CalendarItem[];
  Dia7: CalendarItem[];
  semanaItems: CalendarItem[];
  DiaInicial: Date;

  constructor(private planeacionService: PlaneacionProduccionService, private dialogsService: DialogsService) {

    this.subUnasignedItems = planeacionService.UnasignedItems.subscribe(u => {
      this.UnasignedItems = u.sort((a, b) => {
        if (a.FechaEntrega < b.FechaEntrega) return -1;
        else if (a.FechaEntrega > b.FechaEntrega) return 1;
        else return 0;
      });
    });

    this.subSemanaData = planeacionService.PlanItems.subscribe(u => {
      this.DiaInicial = u.DiaInicial;
      this.semanaItems = u.data;
      this.Dia1 = u.data.filter(itm => new Date(itm.FechaProgramada) >= planeacionService.addDayToDate(new Date(u.DiaInicial), 0)
        && new Date(itm.FechaProgramada) < planeacionService.addDayToDate(new Date(u.DiaInicial), 1)).sort(i => i.Prioridad);

      this.Dia2 = u.data.filter(itm => new Date(itm.FechaProgramada) >= planeacionService.addDayToDate(new Date(u.DiaInicial), 1)
        && new Date(itm.FechaProgramada) < planeacionService.addDayToDate(new Date(u.DiaInicial), 2)).sort(i => i.Prioridad);

      this.Dia3 = u.data.filter(itm => new Date(itm.FechaProgramada) >= planeacionService.addDayToDate(new Date(u.DiaInicial), 2)
        && new Date(itm.FechaProgramada) < planeacionService.addDayToDate(new Date(u.DiaInicial), 3)).sort(i => i.Prioridad);

      this.Dia4 = u.data.filter(itm => new Date(itm.FechaProgramada) >= planeacionService.addDayToDate(new Date(u.DiaInicial), 3)
        && new Date(itm.FechaProgramada) < planeacionService.addDayToDate(new Date(u.DiaInicial), 4)).sort(i => i.Prioridad);

      this.Dia5 = u.data.filter(itm => new Date(itm.FechaProgramada) >= planeacionService.addDayToDate(new Date(u.DiaInicial), 4)
        && new Date(itm.FechaProgramada) < planeacionService.addDayToDate(new Date(u.DiaInicial), 5)).sort(i => i.Prioridad);

      this.Dia6 = u.data.filter(itm => new Date(itm.FechaProgramada) >= planeacionService.addDayToDate(new Date(u.DiaInicial), 5)
        && new Date(itm.FechaProgramada) < planeacionService.addDayToDate(new Date(u.DiaInicial), 6)).sort(i => i.Prioridad);

      this.Dia7 = u.data.filter(itm => new Date(itm.FechaProgramada) >= planeacionService.addDayToDate(new Date(u.DiaInicial), 6)
        && new Date(itm.FechaProgramada) < planeacionService.addDayToDate(new Date(u.DiaInicial), 7)).sort(i => i.Prioridad);
    })
  }

  ngOnInit(): void {

    // this.planeacionService.refreshUnasigned(1);
    // this.planeacionService.refreshPlanSemanal(2020, 17);
    this.planeacionService.initCalendarioSemana(1, 2020, 17)


  }

  ngOnDestroy(): void {
    this.subUnasignedItems.unsubscribe();
    this.subSemanaData.unsubscribe();
  }

  getLabelDay(day: number): Date {
    return this.planeacionService.addDayToDate(this.DiaInicial, day)
  }

  async refresh() {
    //this.planeacionService.refreshPlanSemanal(2020, 18);
    var y = await this.dialogsService.showDialog(
      'Prueba',
      'Mensaje de prueba',
      { buttons: DialogButtonsFlags.Yes | DialogButtonsFlags.No, Icon: DialogIcons.Success, hasCloseButton: true });

  }

}
