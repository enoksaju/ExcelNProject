import { Injectable, Component, NgModule, Inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Observable } from 'rxjs/Observable';
import { MatDialogRef, MatDialog, MAT_SNACK_BAR_DATA, MatSnackBar } from '@angular/material';
import { MatButtonModule, MatDialogModule, MatIconModule, MatCardModule } from '@angular/material';
import { FlexLayoutModule, ObservableMedia } from "@angular/flex-layout";

@Injectable()
export class DialogsService {

  constructor(private dialog: MatDialog, private snackBar: MatSnackBar) { }

  public confirm(title: string, message: string, confirmText:string = "Si", cancelText:string="No"): Observable<boolean> {

    let dialogRef: MatDialogRef<ConfirmDialogComponent>;

    dialogRef = this.dialog.open(ConfirmDialogComponent);
    dialogRef.componentInstance.title = title;
    dialogRef.componentInstance.message = message;
    dialogRef.componentInstance.confirmText = confirmText;
    dialogRef.componentInstance.cancelText = cancelText;

    return dialogRef.afterClosed();
  }

  public snackError(Message: string, duration: number = 5000): Observable<void> {
    return this.snackBar.openFromComponent(ErrorSnackComponent, { duration: duration, data: Message }).afterDismissed()
  }

  public snackSuccess(Message: string, duration: number = 5000): Observable<void> {
   return this.snackBar.openFromComponent(SuccessSnackComponent, { duration: duration, data: Message }).afterDismissed()
  }
}

@Component({
  selector: 'app-confirm-dialog',
  templateUrl:"./confirmDialog.component.html"
})
export class ConfirmDialogComponent {
  public title: string;
  public message: string;
  public confirmText: string;
  public cancelText: string;

  constructor(public dialogRef: MatDialogRef<ConfirmDialogComponent>, public media: ObservableMedia) {

  }
}

@Component({
  selector: 'snakbar-error',
  template: `<section class="snack mat-typography"><mat-icon class="snack-icon" style="color: green;">check_circle</mat-icon><div class="snack-content"><span class="snack-text">{{data}}</span></div></section>`,
  styles: [``]
}) export class SuccessSnackComponent {
  constructor( @Inject(MAT_SNACK_BAR_DATA) public data: string) { }
}

@Component({
  selector: 'snakbar-error',
  template: `<section class="snack mat-typography"><mat-icon class="snack-icon" style="color: red;">warning</mat-icon><div class="snack-content"><span class="snack-text">{{data}}</span></div></section>`,
  styles: [``]
}) export class ErrorSnackComponent {
  constructor( @Inject(MAT_SNACK_BAR_DATA) public data: string) { }
}

@NgModule({
  imports: [
    CommonModule,
    MatDialogModule,
    MatButtonModule,
    MatIconModule,
    MatCardModule,
    FlexLayoutModule
  ],
  declarations: [ConfirmDialogComponent, ErrorSnackComponent, SuccessSnackComponent],
  exports: [ConfirmDialogComponent, ErrorSnackComponent, SuccessSnackComponent],
  entryComponents: [ConfirmDialogComponent, ErrorSnackComponent, SuccessSnackComponent],
  providers: [DialogsService]
})
export class DialogsModule { }