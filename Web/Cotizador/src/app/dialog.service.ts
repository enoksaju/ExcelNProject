import { Injectable } from '@angular/core';
import { MatDialog } from '../../node_modules/@angular/material';
import { DialogComponent, DialogButtonsFlags, DialogIcons, DialogResults } from './dialog.component';

@Injectable({
  providedIn: 'root'
})
export class DialogService {

  constructor(private dialog: MatDialog) { }
    /**
   * Controlador de los dialogos.
   * @param Title Titulo del dialogo
   * @param Message Mensaje que se mostrara en el dialogo
   * @param options buttons: Botones del cuadro de dialogo, Icon: Icono que se mostrara
   */
  showDialog(
    Title: string,
    Message: string,
    options?: { buttons?: DialogButtonsFlags, Icon?: DialogIcons }): Promise<DialogResults> {

    const defaults_ = {
      buttons: DialogButtonsFlags.Ok,
      Icon: DialogIcons.Info,
      affterClose: result => console.log(result)
    };
    const options_ = Object.assign(defaults_, options );
    const dialogRef = this.dialog.open(DialogComponent, {
      disableClose: true,
      data: {
        Message: Message,
        Title: Title,
        buttons: options_.buttons,
        Icon: options_.Icon
      }
    });

    return new Promise<DialogResults>((resolve, rejected) => {
      dialogRef.afterClosed().subscribe((res: DialogResults) => resolve(res));
    });

  }
}
