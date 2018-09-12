import { Component, OnInit, HostBinding } from '@angular/core';
import { MatDialogRef } from '@angular/material';
import { IRodillo } from '../../../catalogos.service';
import { FormControl, Validators, FormGroup } from '@angular/forms';
import { shake } from 'ng-animate';
import { trigger, transition, useAnimation } from '@angular/animations';

@Component({
  selector: 'cat-add-rodillo',
  template: `
  <form fxFlex="100%" (ngSubmit)="onSubmit()" [formGroup]="form"  style="position:relative;" fxLayout="column">
    <h2 mat-dialog-title>Agregar Rodillo</h2>

    <mat-divider class="dialog-divider"></mat-divider>

    <!-- Dialog Content -->
    <div  mat-dialog-content class="mat-typography" fxLayout="column">

      <mat-form-field appearance="standard" [@shake]="shake[0]" (@shake.done)="reset(0)" fxFlex="100%">
        <mat-label>Cantidad</mat-label>
        <input matInput type="number" step="1" formControlName="Cantidad">
        <mat-hint>Define la cantidad de rodillos en existencia</mat-hint>
      </mat-form-field>

      <mat-form-field appearance="standard" [@shake]="shake[1]" (@shake.done)="reset(1)" fxFlex="100%">
        <mat-label>Medida</mat-label>
        <input matInput type="number" formControlName="Medida">
        <mat-hint>Define la medida de la circunferencia de los rodillos</mat-hint>
      </mat-form-field>

    </div>

    <mat-divider class="dialog-divider"></mat-divider>

    <!-- Dialog actions -->
    <div mat-dialog-actions fxLayout="row" fxFlex="80px" fxLayoutAlign="center center">
      <button  mat-raised-button color="primary">Agregar Rodillo</button>
    </div>

    <!-- CloseButton -->
    <button class="closeButton" type="button" [mat-dialog-close]="null" tabIndex="3" color="warn" mat-icon-button>
      <mat-icon>close</mat-icon>
    </button>
  </form>
  `,
  styles: [],
  animations: [trigger('shake', [transition('* => error', useAnimation(shake))])],
})
export class AddRodilloComponent implements OnInit {
  CantidadCForm: FormControl = new FormControl('', [
    Validators.required,
    Validators.min(0),
    Validators.max(100),
  ]);
  MedidaCForm: FormControl = new FormControl('', [Validators.required, Validators.min(0)]);
  form: FormGroup = new FormGroup({
    Cantidad: this.CantidadCForm,
    Medida: this.MedidaCForm,
  });

  shake: string[] = ['', ''];

  constructor(private dialogRef: MatDialogRef<AddRodilloComponent, IRodillo>) {}

  ngOnInit() {}

  onSubmit() {
    if (this.form.valid) {
      this.dialogRef.close(this.form.value);
    } else {
      this.shake[0] = this.CantidadCForm.valid ? '' : 'error';
      this.shake[1] = this.MedidaCForm.valid ? '' : 'error';
    }
  }

  reset(idx: number) {
    this.shake[idx] = '';
  }
}
