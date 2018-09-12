import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material';
import { IConfigTintaMaquina } from '../../../catalogos.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { trigger, transition, useAnimation } from '@angular/animations';
import { shake } from 'ng-animate';

@Component({
  selector: 'cat-add-config-tinta',
  template: `
  <form fxFlex="100%" (ngSubmit)="onSubmit()" [formGroup]="form"  style="position:relative;" fxLayout="column">
    <h2 mat-dialog-title>Agregar Configuración de Tintas</h2>

    <mat-divider class="dialog-divider"></mat-divider>

    <!-- Dialog Content -->
    <div  mat-dialog-content class="mat-typography" fxLayout="column">

      <mat-form-field appearance="standard" [@shake]="shake[0]" (@shake.done)="reset(0)" fxFlex="100%">
        <mat-label>Cantidad</mat-label>
        <input matInput type="number" step="1" formControlName="Cantidad">
        <mat-hint>Define la cantidad de tintas para la configuración.</mat-hint>
      </mat-form-field>

      <mat-form-field appearance="standard" [@shake]="shake[1]" (@shake.done)="reset(1)" fxFlex="100%">
        <mat-label>Minimo de Metros Lineales</mat-label>
        <input matInput type="number" formControlName="MinimoMetros">
        <mat-hint>Define la cantidad minima de metros lineales.</mat-hint>
      </mat-form-field>

    </div>

    <mat-divider class="dialog-divider"></mat-divider>

    <!-- Dialog actions -->
    <div mat-dialog-actions fxLayout="row" fxFlex="80px" fxLayoutAlign="center center">
      <button  mat-raised-button color="primary">Agregar Configuración</button>
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
export class AddConfigTintaComponent implements OnInit {
  CantidadCForm: FormControl = new FormControl('', [
    Validators.required,
    Validators.min(1),
    Validators.max(12),
  ]);

  MinimoMetrosCForm: FormControl = new FormControl('', [Validators.required, Validators.min(1)]);

  form: FormGroup = new FormGroup({
    Cantidad: this.CantidadCForm,
    MinimoMetros: this.MinimoMetrosCForm,
  });

  shake: string[] = ['', ''];

  constructor(private dialogRef: MatDialogRef<AddConfigTintaComponent, IConfigTintaMaquina>) {}

  ngOnInit() {}

  onSubmit() {
    if (this.form.valid) {
      this.dialogRef.close(this.form.value);
    } else {
      this.shake[0] = this.CantidadCForm.valid ? '' : 'error';
      this.shake[1] = this.MinimoMetrosCForm.valid ? '' : 'error';
    }
  }

  reset(idx: number) {
    this.shake[idx] = '';
  }
}
