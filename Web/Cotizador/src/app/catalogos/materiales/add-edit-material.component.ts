import { Component, OnInit, OnDestroy, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { AddEditFamiliaMaterialesComponent } from '../familias-materiales/add-edit-familia-materiales.component';
import { DialogResults, DialogIcons } from '../../dialog.component';
import {
  CatalogosService,
  IMaterial,
  ROUTE_MATERIALES,
  UnidadesMaterial,
  ICalibre,
  IFamiliasMateriales,
  ROUTE_FAMILIA_MATERIALES,
} from '../../catalogos.service';
import { DialogService } from '../../dialog.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UsuariosService } from '../../usuarios.service';
import { Subscription } from 'rxjs';
import { IInputConfig, ISelectOptions } from '../../common/wrap-inputs/wrap-inputs.component';

@Component({
  selector: 'cat-add-edit-material',
  templateUrl: './add-edit-material.component.html',
  styles: [],
})
export class AddEditMaterialComponent implements OnInit, OnDestroy {
  isNew: boolean;
  isLoading: boolean;
  entity: IMaterial;
  form: FormGroup;

  calibre: number;

  UnidadesMaterial = UnidadesMaterial;

  onSuccess$: Subscription;
  onError$: Subscription;

  ViewForm: IInputConfig[][];

  constructor(
    public dialogRef: MatDialogRef<AddEditFamiliaMaterialesComponent, DialogResults>,
    @Inject(MAT_DIALOG_DATA) public data: IMaterial,
    private catalogosService: CatalogosService,
    private dialogService: DialogService,
    private fb: FormBuilder,
    private usuariosService: UsuariosService,
  ) {
    this.entity = data;
    this.isNew = this.entity ? false : true;
    this.isLoading = true;
    this.catalogosService
      .getAllCollection<IFamiliasMateriales>(ROUTE_FAMILIA_MATERIALES)
      .toPromise()
      .then(value => {
        const fams: ISelectOptions[] = value.Items.map(i => ({
          display: i.NombreFamilia,
          value: i.Id,
        }));
        this.ViewForm = [
          [
            {
              name: 'FamiliaMateriales_Id',
              text: 'Familia de Materiales',
              smflex: '100%',
              type: 'select',
              selectOptions: fams,
            },
          ],
          [{ name: 'Apariencia' }, { name: 'Caracteristicas' }],
          [
            {
              name: 'Unidad',
              text: 'Unidad de Calibre',
              type: 'select',
              selectOptions: [{ display: 'Micras', value: 0 }, { display: 'CI', value: 1 }],
            },
            {
              name: 'FactorDensidad',
              text: 'Factor de Densidad',
              type: 'number',
            },
          ],
          [
            { name: 'PrecioInicial', text: 'Precio Inicial', type: 'currency' },
            { name: 'CostoInicial', text: 'Costo Inicial', type: 'currency' },
          ],
          [{ name: 'Metalizado', type: 'checkbox' }, { name: 'Convenio', type: 'checkbox' }],
          [{ name: 'FechaOperacion', text: 'Fecha de Operación', type: 'date' }],
        ];
        this.isLoading = false;
      });
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
    this.entity = this.entity
      ? this.entity
      : {
          Apariencia: '',
          Caracteristicas: '',
          Unidad: UnidadesMaterial.Micras,
          FactorDensidad: 0,
          PrecioInicial: 0,
          CostoInicial: 0,
          Metalizado: false,
          Convenio: false,
          FechaOperacion: new Date(),
          Calibres: new Array<ICalibre>(),
        };

    this.form = this.fb.group({
      Id: [this.entity.Id],
      FamiliaMateriales_Id: [this.entity.FamiliaMateriales_Id, Validators.required],
      Apariencia: [this.entity.Apariencia, Validators.required],
      Caracteristicas: [this.entity.Caracteristicas],
      Unidad: [this.entity.Unidad],
      FactorDensidad: [this.entity.FactorDensidad, Validators.required],
      PrecioInicial: [this.entity.PrecioInicial, Validators.required],
      CostoInicial: [this.entity.CostoInicial],
      Metalizado: [this.entity.Metalizado],
      Convenio: [this.entity.Convenio],
      FechaOperacion: [this.entity.FechaOperacion, Validators.required],
    });

    this.form.valueChanges.pipe().subscribe((g: IMaterial) => (this.entity.Unidad = g.Unidad));
  }

  async onSubmit() {
    if (this.form.valid) {
      this.entity = Object.assign(this.entity, this.form.value);
      if (this.isNew) {
        this.catalogosService.postEntity(this.entity, ROUTE_MATERIALES);
      } else {
        this.catalogosService.putEntity(this.entity, ROUTE_MATERIALES);
      }
    }
  }

  async RemoveCalibre(calibre: ICalibre) {
    const idx = this.entity.Calibres.indexOf(calibre);
    if (idx >= 0) {
      this.entity.Calibres.splice(idx, 1);
    } else {
      console.error('no se encontro el elemento en la coleccion');
    }
  }

  async AddCalibre(calibre: number) {
    if (
      calibre.toString() !== '' &&
      calibre >= 0 &&
      this.entity.Calibres.findIndex(t => t.Valor.toString() === calibre.toString()) === -1
    ) {
      this.entity.Calibres.push({ MaterialId: this.entity.Id, Valor: calibre });
    } else {
      this.dialogService.showDialog(
        'Error',
        'El valor que intenta agregar ya existe o es invalido',
        { Icon: DialogIcons.Error },
      );
      console.error('valor invalido');
    }
  }
}
