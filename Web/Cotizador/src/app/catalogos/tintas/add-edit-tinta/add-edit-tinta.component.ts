import { Component, OnInit, OnDestroy, Inject } from '@angular/core';
import { ITinta, CatalogosService, ROUTE_TINTAS } from '../../../catalogos.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Subscription } from 'rxjs';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { DialogResults, DialogIcons } from '../../../dialog.component';
import { DialogService } from '../../../dialog.service';
import { UsuariosService } from '../../../usuarios.service';
import { IInputConfig } from '../../../common/wrap-inputs/wrap-inputs.component';

@Component({
  selector: 'cat-add-edit-tinta',
  templateUrl: './add-edit-tinta.component.html',
  styleUrls: ['./add-edit-tinta.component.scss'],
})
export class AddEditTintaComponent implements OnInit, OnDestroy {
  isNew: boolean;
  isLoading: boolean;
  entity: ITinta;
  form: FormGroup;

  onSuccess$: Subscription;
  onError$: Subscription;

  ViewForm: IInputConfig[][] = [
    [
      {
        name: 'Nombre',
        text: 'Nombre de la Tinta',
        smflex: '100%',
      },
    ],
    [
      {
        name: 'Tipo',
        text: 'Tipo de Tinta',
        smflex: '100%',
      },
    ],
    [{ name: 'Costo', type: 'currency' }, { name: 'Precio', type: 'currency' }],
  ];

  constructor(
    public dialogRef: MatDialogRef<AddEditTintaComponent, DialogResults>,
    @Inject(MAT_DIALOG_DATA) public data: ITinta,
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
      TintaId: [this.entity.TintaId],
      Nombre: [this.entity.Nombre, Validators.required],
      Tipo: [this.entity.Tipo],
      Costo: [this.entity.Costo, Validators.required],
      Precio: [this.entity.Precio, Validators.required],
    });
  }

  async onSubmit() {
    this.isLoading = true;
    if (this.form.valid) {
      this.entity = Object.assign(this.entity, this.form.value);
      if (this.isNew) {
        this.catalogosService.postEntity(this.entity, ROUTE_TINTAS);
      } else {
        this.catalogosService.putEntity(this.entity, ROUTE_TINTAS);
      }
    }
  }
}
