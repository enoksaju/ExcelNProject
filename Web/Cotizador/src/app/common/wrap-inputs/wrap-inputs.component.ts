import {
  Component,
  OnInit,
  Input,
  ViewChildren,
  QueryList,
  AfterViewInit,
  ContentChildren,
  AfterContentInit,
} from '@angular/core';
import {
  FormControl,
  FormGroup,
  Validators,
  ValidatorFn,
  FormGroupDirective,
} from '../../../../node_modules/@angular/forms';
import { ObservableMedia } from '@angular/flex-layout';
import { DeviceDetectorService } from 'ngx-device-detector';
@Component({
  selector: 'wrap-inputs',
  template: `
  <div fxLayout="row wrap" class="end-wrap-5" #wrapInput [formGroup]="fGroup" fxLayoutAlign="space-between start"  fxFlexFill fxLayoutGap="5px">

      <ng-container *ngFor="let ctl of controls" [ngSwitch]="ctl.type">

        <!-- INPUT AS SELECT -->
        <mat-form-field appearance="standard" fxFlex="{{(ctl.flex ? ctl.flex : '100%')}}" fxFlex.gt-sm="{{(ctl.smflex ? ctl.smflex : '48%')}}" *ngSwitchCase="'select'">
          <mat-label>{{ctl.text ? ctl.text : ctl.name}}</mat-label>
          <mat-select [name]="ctl.name" formControlName="{{ctl.name}}">
            <mat-option *ngFor="let item of ctl.selectOptions" [value]="item.value">
              {{item.display}}
            </mat-option>
          </mat-select>
        </mat-form-field>

        <!-- INPUT AS DATEPICKER -->

        <mat-form-field appearance="standard" class="datepicker"   fxFlex="{{(ctl.flex ? ctl.flex : '100%')}}" fxFlex.gt-sm="{{(ctl.smflex ? ctl.smflex : '48%')}}" *ngSwitchCase="'date'" >
          <mat-label>{{ctl.text ? ctl.text : ctl.name}}</mat-label>
          <input [name]="ctl.name" [autocomplete]="ctl.autocomplete" formControlName="{{ctl.name}}" readonly="readonly" matInput
                [min]="ctl.min" [max]="ctl.max" [matDatepicker]="picker">
          <mat-datepicker-toggle matSuffix [for]="picker"></mat-datepicker-toggle>
          <mat-datepicker [touchUi]="deviceService.isMobile()" #picker></mat-datepicker>
          <mat-hint align="end">Seleccione aquí la fecha ^</mat-hint>
          <mat-error *ngIf="fGroup.controls[ctl.name].invalid">
            {{getErrorMessage(ctl.name, ctl.text)}}
          </mat-error>
        </mat-form-field>

        <!-- INPUT AS CURRENCY -->
        <mat-form-field appearance="standard" fxFlex="{{(ctl.flex ? ctl.flex : '100%')}}" fxFlex.gt-sm="{{(ctl.smflex ? ctl.smflex : '48%')}}" *ngSwitchCase="'currency'">
          <mat-label>{{ctl.text ? ctl.text : ctl.name}}</mat-label>
          <input [name]="ctl.name" [autocomplete]="ctl.autocomplete" type="number" matInput formControlName="{{ctl.name}}">
          <span matPrefix>$&nbsp;</span>
          <mat-error *ngIf="fGroup.controls[ctl.name].invalid">
          {{getErrorMessage(ctl.name, ctl.text)}}
          </mat-error>
        </mat-form-field>

        <!-- INPUT AS CHECKBOX -->
        <div *ngSwitchCase="'checkbox'" fxLayoutAlign="start center" class="checkbox-container" fxFlex="{{(ctl.flex ? ctl.flex : '100%')}}" fxFlex.gt-sm="{{(ctl.smflex ? ctl.smflex : '48%')}}">
          <mat-checkbox formControlName="{{ctl.name}}">
            {{ctl.text ? ctl.text : ctl.name}}
          </mat-checkbox>
        </div>

        <!-- INPUT AS DEFAULT -->
        <mat-form-field appearance="standard" fxFlex="{{(ctl.flex ? ctl.flex : '100%')}}" fxFlex.gt-sm="{{(ctl.smflex ? ctl.smflex : '48%')}}" *ngSwitchDefault>
          <mat-label>{{ctl.text ? ctl.text : ctl.name}}</mat-label>
          <input [name]="ctl.name" [autocomplete]="ctl.autocomplete" [type]="ctl.type ? ctl.type : 'textbox'" matInput formControlName="{{ctl.name}}">
          <span matSuffix *ngIf="ctl.unit">{{ctl.unit}}</span>
          <mat-error *ngIf="fGroup.controls[ctl.name].invalid">
          {{getErrorMessage(ctl.name, ctl.text)}}
          </mat-error>
        </mat-form-field>

      </ng-container>
  </div>
  `,
  styles: ['.checkbox-container{min-height: 60px;}'],
})
export class WrapInputsComponent implements OnInit {
  @Input()
  controls: Array<IInputConfig>;
  @Input()
  fGroup: FormGroup;

  getErrorMessage(controlName: string, text: string) {
    const ctl = this.fGroup.controls[controlName];
    if (ctl.hasError('required')) {
      return `El campo "${text ? text : controlName}" es requerido`;
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
      return `Valor invalido para ${text ? text : controlName} `;
    }
  }

  constructor(public media: ObservableMedia, public deviceService: DeviceDetectorService) {}

  ngOnInit() {}
}

/**
 * name, text?, flex?, smflex?, type?, slectOptions?, min?, max?, autocomplete?
 */
export interface IInputConfig {
  name: string;
  text?: string;
  flex?: string;
  smflex?: string;

  /**
   * [select: 'debe contener tambien selecOptions', date, currency, checkbox, default]
   */
  type?: string;

  /**
   * {display: texto a Mostrar, value: valor del option}
   */
  selectOptions?: Array<ISelectOptions>;
  min?: any;
  max?: any;
  autocomplete?: string;
  unit?: string;
}
export interface ISelectOptions {
  display: string;
  value: any;
}

@Component({
  selector: 'wrap-input-container,[wrap-input-container]',
  template: `<ng-content></ng-content>`,
  styles: [],
})
export class WrapInputsContainerComponent implements AfterContentInit {
  @Input()
  fGroup: FormGroup;
  @ContentChildren(WrapInputsComponent)
  wraps: QueryList<WrapInputsComponent>;

  constructor() {}

  ngAfterContentInit() {
    for (const wrap of this.wraps.toArray()) {
      wrap.fGroup = this.fGroup;
    }
  }
}
