import { Component, OnInit, Inject, OnDestroy } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { DialogResults, DialogIcons } from '../../dialog.component';
import {
  CatalogosService,
  IFamiliasMateriales,
  ROUTE_FAMILIA_MATERIALES,
} from '../../catalogos.service';
import { DialogService } from '../../dialog.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UsuariosService } from '../../usuarios.service';
import { Observable, Subscription } from 'rxjs';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-add-edit-familia-materiales',
  template: `
    <!-- spinner -->
    <div *ngIf="isLoading" fxLayoutAlign="center center" fxFlex="100%">
      <mat-spinner  color="accent" diameter="80"></mat-spinner>
    </div>
    <form  *ngIf="!isLoading" fxFlex="100%" style="position:relative;" fxLayout="column"
    [formGroup]="form" (ngSubmit)="onSubmit()" >
      <h2 mat-dialog-title>{{isNew ? 'Agregar' : 'Editar'}} Cliente</h2>
      <mat-divider class="dialog-divider"></mat-divider>

      <!-- Contenido del dialogo -->
      <div mat-dialog-content fxLayout="column" class="mat-typography">

        <!-- Form -->
        <div *ngIf="!isLoading"  fxLayout="column" fxFlex="100%">
          <div fxLayout="column">
            <wrap-inputs [controls]="[{name:'NombreFamilia', text:'Nombre', smflex:'100%'}]" [fGroup]="form"></wrap-inputs>
          </div>
        </div>
      </div>

      <div mat-dialog-actions fxLayout="row" fxFlex="80px" fxLayoutAlign="center center">
        <button type="submit" mat-raised-button color="warn">{{isNew ? 'Guardar' : 'Actualizar'}}</button>
      </div>

      <!-- CloseButton -->
      <button class="closeButton" mat-dialog-close tabIndex="3" color="warn" mat-icon-button>
          <mat-icon>close</mat-icon>
      </button>
    </form>
  `,
  styles: [],
})
export class AddEditFamiliaMaterialesComponent implements OnInit, OnDestroy {
  entidad: IFamiliasMateriales;
  idEntity: number;
  isNew: boolean;
  isLoading: boolean;
  form: FormGroup;

  onSuccess$: Subscription;
  onError$: Subscription;

  constructor(
    public dialogRef: MatDialogRef<AddEditFamiliaMaterialesComponent, DialogResults>,
    @Inject(MAT_DIALOG_DATA) public data: number,
    private catalogosService: CatalogosService,
    private dialogService: DialogService,
    private fb: FormBuilder,
    private usuariosService: UsuariosService
  ) {
    this.idEntity = data;
    this.isNew = data ? false : true;
    this.isLoading = !this.isNew;
  }
  ngOnInit() {
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
  ngOnDestroy() {
    this.onSuccess$.unsubscribe();
    this.onError$.unsubscribe();
  }

  async createForm() {
    this.entidad = this.idEntity
      ? await this.catalogosService.getEntity<IFamiliasMateriales>(
          this.idEntity,
          ROUTE_FAMILIA_MATERIALES
        )
      : { NombreFamilia: '' };

    this.form = this.fb.group({
      Id: [this.entidad.Id],
      NombreFamilia: [this.entidad.NombreFamilia, Validators.required],
    });

    this.isLoading = false;
  }

  async onSubmit() {
    if (this.form.valid) {
      this.isLoading = true;

      if (this.isNew) {
        this.catalogosService.postEntity(this.form.value, ROUTE_FAMILIA_MATERIALES);
      } else {
        this.catalogosService.putEntity(this.form.value, ROUTE_FAMILIA_MATERIALES);
      }
    }
  }
}
