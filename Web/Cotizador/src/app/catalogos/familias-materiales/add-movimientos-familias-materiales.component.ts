import { Component, OnInit, OnDestroy, Inject } from '@angular/core';
import { DialogResults, DialogIcons } from '../../dialog.component';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import {
  CatalogosService,
  ROUTE_MOVIMIENTOS_PRECIO_FAMILIA_MATERIALES,
} from '../../catalogos.service';
import { DialogService } from '../../dialog.service';
import {
  FormBuilder,
  FormGroup,
  Validators,
  ValidatorFn,
  AbstractControl,
  ValidationErrors,
} from '@angular/forms';
import { Subscription } from 'rxjs';

@Component({
  selector: 'cat-add-movimientos-familias-materiales',
  template: `
    <!-- spinner -->
    <div *ngIf="isLoading" fxLayoutAlign="center center" fxFlex="100%">
      <mat-spinner  color="accent" diameter="80"></mat-spinner>
    </div>
    <!-- Formulario -->
    <form *ngIf="!isLoading" fxFlex="100%" style="position:relative;" fxLayout="column"
      [formGroup]="form" (ngSubmit)="onSubmit()">

      <h2 mat-dialog-title>Agregar Movimiento</h2>
      <mat-divider class="dialog-divider"></mat-divider>

      <div mat-dialog-content fxLayout="column" class="mat-typography">
        <div fxLayout="column">

          <wrap-inputs [controls]="[{name:'FechaOperacion', type:'date', min:now, text:'Fecha de Operacion', smflex:'100%'}]" [fGroup]="form"></wrap-inputs>
          <wrap-inputs [controls]="[{name:'Valor', type:'number', text:'Incremento/Decremento', smflex:'100%'}]" [fGroup]="form"></wrap-inputs>

        </div>
      </div>

      <div mat-dialog-actions fxLayout="row" fxFlex="80px" fxLayoutAlign="center center">
        <button type="submit" mat-raised-button color="warn">Guardar</button>
      </div>

      <!-- CloseButton -->
      <button class="closeButton" mat-dialog-close tabIndex="3" color="warn" mat-icon-button>
        <mat-icon>close</mat-icon>
      </button>
    </form>
  `,
  styles: [],
})
export class AddMovimientosFamiliasMaterialesComponent implements OnInit, OnDestroy {
  form: FormGroup;
  isLoading: boolean = false;
  now = new Date(Date.now());

  onSuccess$: Subscription;
  onError$: Subscription;

  constructor(
    public dialogRef: MatDialogRef<AddMovimientosFamiliasMaterialesComponent, DialogResults>,
    @Inject(MAT_DIALOG_DATA) public data: number,
    private catalogosService: CatalogosService,
    private dialogService: DialogService,
    private fb: FormBuilder
  ) {
    this.onSuccess$ = this.catalogosService.onHttpComplete.pipe().subscribe(o => {
      this.dialogService
        .showDialog('Correcto...', o, { Icon: DialogIcons.Success })
        .then(() => this.dialogRef.close(DialogResults.Ok));
    });

    this.onError$ = this.catalogosService.onHttpError.pipe().subscribe(e => {
      this.dialogService
        .showDialog('Error...', this.dialogService.getModelError(e), {
          Icon: DialogIcons.Error,
        })
        .then(() => (this.isLoading = false));
    });

    this.createForm();
  }

  ngOnInit() {}
  ngOnDestroy() {
    this.onSuccess$.unsubscribe();
    this.onError$.unsubscribe();
  }

  async createForm() {
    this.form = this.fb.group({
      Valor: ['', [Validators.required]],
      FechaOperacion: ['', [Validators.required, Validators.min(Date.now())]],
      FamiliaMateriales_Id: [this.data],
    });
  }

  onSubmit() {
    if (this.form.valid) {
      this.isLoading = true;
      this.catalogosService.postEntity(
        this.form.value,
        ROUTE_MOVIMIENTOS_PRECIO_FAMILIA_MATERIALES
      );
    }
  }
}
