import { Component, OnInit, OnDestroy, Inject } from '@angular/core';
import { IOtro, CatalogosService, ROUTE_OTROS } from '../../../catalogos.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Subscription } from 'rxjs';
import { IInputConfig } from '../../../common/wrap-inputs/wrap-inputs.component';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { DialogResults, DialogIcons } from '../../../dialog.component';
import { DialogService } from '../../../dialog.service';
import { UsuariosService } from '../../../usuarios.service';

@Component({
  selector: 'cat-add-edit-otros',
  templateUrl: './add-edit-otros.component.html',
  styleUrls: ['./add-edit-otros.component.scss']
})
export class AddEditOtrosComponent implements OnInit, OnDestroy {

  isNew: boolean;
  isLoading: boolean;
  entity: IOtro;
  form: FormGroup;

  onSuccess$: Subscription;
  onError$: Subscription;

  ViewForm: IInputConfig[][] = [
    [
      {
        name: 'Nombre',
        text: 'Nombre',
        smflex: '100%',
      },
    ],
    [{ name: 'Costo', type: 'currency' }, { name: 'Precio', type: 'currency' }],
  ];

  constructor(
    public dialogRef: MatDialogRef<AddEditOtrosComponent, DialogResults>,
    @Inject(MAT_DIALOG_DATA) public data: IOtro,
    private catalogosService: CatalogosService,
    private dialogService: DialogService,
    private fb: FormBuilder,
    private usuariosService: UsuariosService,
  ) {
    this.entity = data;
    this.isNew = this.entity ? false : true;
    this.isLoading = false;
  }

  ngOnInit(): void {
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
  ngOnDestroy(): void {
    this.onSuccess$.unsubscribe();
    this.onError$.unsubscribe();
  }

  async createForm() {
    this.entity = this.entity ? this.entity : {};

    this.form = this.fb.group({
      OtroId: [this.entity.OtroId],
      Nombre: [this.entity.Nombre, Validators.required],
      Costo: [this.entity.Costo, Validators.required],
      Precio: [this.entity.Precio, Validators.required],
    });
  }

  async onSubmit() {
    this.isLoading = true;
    if (this.form.valid) {
      this.entity = Object.assign(this.entity, this.form.value);
      if (this.isNew) {
        this.catalogosService.postEntity(this.entity, ROUTE_OTROS);
      } else {
        this.catalogosService.putEntity(this.entity, ROUTE_OTROS);
      }
    }
  }

}
