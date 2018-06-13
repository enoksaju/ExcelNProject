import { Injectable, Component, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Observable } from 'rxjs/Observable';
import { MatDialogRef, MatDialog, MatToolbarModule, MatCardModule, MatButtonModule, MatIconModule, MatInputModule } from '@angular/material';
import { FlexLayoutModule, ObservableMedia } from "@angular/flex-layout";
import { DialogsService } from '../../../common/Services/dialog.service';


@Injectable()
export class PermisoDetailsService {

  constructor(private dialog: MatDialog) { }

  public showDetails(permiso: any): Observable<any> {

    let dialogRef: MatDialogRef<PemisosDetailsComponent>;

    dialogRef = this.dialog.open(PemisosDetailsComponent, { panelClass: 'dialog-notpadding' });
    dialogRef.componentInstance.permiso = permiso;
    return dialogRef.afterClosed();

  }
}

@Component({
  selector: 'permiso-details-dialog',
  templateUrl: "./permisoDetails.component.html",
  styles: [`
mat-form-field{
  width:100%;
}
`]
})
export class PemisosDetailsComponent {
  permiso: any;
  constructor(public dgRef: MatDialogRef<PemisosDetailsComponent>, public media: ObservableMedia, public dialogsService: DialogsService) { }

  close(t: string) {
    this.dialogsService.confirm('Confirme', 'Realmente desea ' + t + ' esté permiso?', 'Si, ' + t)
      .subscribe(y =>
        y && this.dgRef.close({ accion: t, items: [this.permiso.Id] })
      );
  }
}

@NgModule({
  imports: [
    CommonModule,
    FlexLayoutModule,
    MatToolbarModule,
    MatCardModule,
    MatButtonModule,
    MatIconModule,
    MatInputModule
  ],
  declarations: [PemisosDetailsComponent],
  exports: [PemisosDetailsComponent],
  entryComponents: [PemisosDetailsComponent],
  providers: [PermisoDetailsService]
})
export class PermisoDetailsModule { }