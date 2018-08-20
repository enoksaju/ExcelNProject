import { Component, OnInit, Input } from '@angular/core';
import { FormControl, FormGroup, Validators, ValidatorFn } from '../../../../node_modules/@angular/forms';
@Component({
  selector: 'wrap-inputs',
  template: `
  <div fxLayout="row wrap" [formGroup]="fGroup" fxLayoutAlign="space-between start"  fxFlexFill fxLayoutGap="5px">
      <ng-container *ngFor="let ctl of controls" [ngSwitch]="ctl.type">
        <mat-form-field fxFlex="{{(ctl.flex ? ctl.flex : '100%')}}" fxFlex.gt-sm="{{(ctl.smflex ? ctl.smflex : '48%')}}" *ngSwitchCase="'select'">
          <mat-select formControlName="{{ctl.name}}" placeholder="{{ctl.text}}">
            <mat-option *ngFor="let item of ctl.selectOptions" [value]="item.value">
              {{item.display}}
            </mat-option>
          </mat-select>
        </mat-form-field>

        <mat-form-field fxFlex="{{(ctl.flex ? ctl.flex : '100%')}}" fxFlex.gt-sm="{{(ctl.smflex ? ctl.smflex : '48%')}}" *ngSwitchDefault>
          <input  [type]="ctl.type ? ctl.type : 'textbox'" matInput formControlName="{{ctl.name}}" placeholder="{{ctl.text}}"  >
          <mat-error *ngIf="fGroup.controls[ctl.name].invalid">
          {{getErrorMessage(ctl.name, ctl.text)}}
          </mat-error>
        </mat-form-field>
      </ng-container>
  </div>
  `,
  styles: []
})

export class WrapInputsComponent implements OnInit {
  @Input() controls: Array<IInputConfig>;
  @Input() fGroup: FormGroup;

  getErrorMessage(controlName: string, text: string) {
    const ctl = this.fGroup.controls[controlName];
    if (ctl.hasError('required')) {
      return `El campo "${text}" es requerido`;
    } else if (ctl.hasError('email')) {
      return 'El formato de Email no es valido';
    } else if (ctl.hasError('min')) {
      return 'El valor minimo es ' + ctl.getError('min').min;
    } else if (ctl.hasError('max')) {
      return 'El valor minimo es ' + ctl.getError('max').max;
    } else if (ctl.hasError('minlength')) {
      return 'El largo minimo es de ' + ctl.getError('minlength').requiredLength;
    } else if (ctl.hasError('maxlength')) {
      return 'El maximo es de ' + ctl.getError('maxlength').requiredLength;
    } else if (ctl.hasError('pattern')) {
      return `Valor invalido para ${text} `;
    }
  }

  constructor() {
  }

  ngOnInit() {
  }
}

export interface IInputConfig {
  name: string;
  text: string;
  flex?: string;
  smflex?: string;
  type?: string;
  selectOptions?: Array<ISelectOptions>;
}
export interface ISelectOptions {
  display: string;
  value: any;
}


