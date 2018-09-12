import { Component, OnInit, Inject, OnDestroy } from '@angular/core';
import {
  IImpresora,
  CatalogosService,
  ILinea,
  ROUTE_IMPRESORAS,
  IRodillo,
  IConfigTintaMaquina,
} from '../../../catalogos.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Subscription } from 'rxjs';
import { IInputConfig, ISelectOptions } from '../../../common/wrap-inputs/wrap-inputs.component';
import { DialogResults, DialogIcons } from '../../../dialog.component';
import { MatDialogRef, MAT_DIALOG_DATA, MatDialog } from '@angular/material';
import { DialogService } from '../../../dialog.service';
import { UsuariosService } from '../../../usuarios.service';
import { HttpClient } from '@angular/common/http';
import { AddRodilloComponent } from './add-rodillo.component';
import { AddConfigTintaComponent } from './add-config-tinta.component';



const invalidValue: string = 'El valor que intenta agregar es invalido!';
const success: string = 'Correcto!';
const error: string = 'Error!';
const ROUTE_LINEAS: string = 'api/Catalogos/lineas';



@Component({
  selector: 'cat-add-edit-impresora',
  templateUrl: './add-edit-impresora.component.html',
  styles: [],
})
export class AddEditImpresoraComponent implements OnInit, OnDestroy {
  isNew: boolean;
  isLoading: boolean;
  entity: IImpresora;
  form: FormGroup;

  onSuccess$: Subscription;
  onError$: Subscription;

  tintaToAdd: IConfigTintaMaquina = {};

  ViewForm: IInputConfig[][];

  constructor(
    public dialogRef: MatDialogRef<AddEditImpresoraComponent, DialogResults>,
    @Inject(MAT_DIALOG_DATA) public data: IImpresora,
    private catalogosService: CatalogosService,
    private dialogService: DialogService,
    private fb: FormBuilder,
    private usuariosService: UsuariosService,
    private http: HttpClient,
    private dialog: MatDialog,
  ) {
    this.entity = data;
    this.isNew = this.entity ? false : true;
    this.isLoading = true;

    this.http
      .get<ILinea[]>(ROUTE_LINEAS)
      .toPromise()
      .then(value => {
        const lineas: ISelectOptions[] = value.map(i => ({
          display: i.Nombre,
          value: i.Id,
        }));
        this.ViewForm = [
          [
            {
              name: 'Linea_Id',
              text: 'Linea',
              type: 'select',
              selectOptions: lineas,
            },
          ],
          [
            {
              name: 'NombreMaquina',
              text: 'Nombre de la Impresora',
            },
            {
              name: 'ModeloMaquina',
              text: 'Modelo de la Impresora',
            },
          ],

          [
            { name: 'Velocidad', type: 'number' },
            { name: 'Decks', text: 'Unidades Disponibles', type: 'number' },
          ],
          [
            {
              name: 'CostoArranque',
              text: 'Costo de Arranque',
              type: 'currency',
            },
            {
              name: 'PorcentajeDesperdicio',
              text: '% Desperdicio',
              unit: '%',
            },
          ],
          [
            {
              name: 'CostoTurno',
              text: 'Costo por Turno',
              type: 'currency',
            },
            {
              name: 'MinutosTurno',
              text: 'Minutos por Turno',
              type: 'number',
            },
          ],
          [
            {
              name: 'AnchoMinimoImpresion',
              text: 'Ancho Minimo de Impresión',
              type: 'number',
              unit: 'cm',
            },
            {
              name: 'AnchoMaximoImpresion',
              text: 'Ancho Maximo de Impresión',
              type: 'number',
              unit: 'cm',
            },
          ],
          [
            {
              name: 'AnchoMinimoMaterial',
              text: 'Ancho Minimo del Material',
              type: 'number',
              unit: 'cm',
            },
            {
              name: 'AnchoMaximoMaterial',
              text: 'Ancho Maximo del Material',
              type: 'number',
              unit: 'cm',
            },
          ],
        ];
        this.isLoading = false;
      });
  }

  ngOnInit() {
    this.onSuccess$ = this.catalogosService.onHttpComplete.pipe().subscribe(o => {
      this.dialogService
        .showDialog(success, o, { Icon: DialogIcons.Success })
        .then(() => this.dialogRef.close(DialogResults.Ok));
    });

    this.onError$ = this.catalogosService.onHttpError.pipe().subscribe(e => {
      this.dialogService
        .showDialog(error, this.dialogService.getModelError(e), {
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
    this.entity = this.entity ? this.entity : { Rodillos: [], ConfiguracionTintas: [] };

    this.form = this.fb.group({
      Id: [this.entity.Id],
      NombreMaquina: [this.entity.NombreMaquina, Validators.required],
      ModeloMaquina: [this.entity.ModeloMaquina, Validators.required],
      CostoArranque: [this.entity.CostoArranque, [Validators.required, Validators.min(0.00001)]],
      CostoTurno: [this.entity.CostoTurno, [Validators.required, Validators.min(0.00001)]],
      PorcentajeDesperdicio: [this.entity.PorcentajeDesperdicio * 100, Validators.required],
      MinutosTurno: [this.entity.MinutosTurno, Validators.required],
      AnchoMinimoImpresion: [this.entity.AnchoMinimoImpresion, Validators.required],
      AnchoMaximoImpresion: [this.entity.AnchoMaximoImpresion, Validators.required],
      AnchoMinimoMaterial: [this.entity.AnchoMinimoMaterial, Validators.required],
      AnchoMaximoMaterial: [this.entity.AnchoMaximoMaterial, Validators.required],
      Velocidad: [this.entity.Velocidad, Validators.required],
      Decks: [this.entity.Decks, Validators.required],
      Linea_Id: [this.entity.Linea_Id, Validators.required],
    });
  }
  onSubmit() {
    if (this.form.valid) {
      this.entity = Object.assign(this.entity, this.form.value);
      this.entity.PorcentajeDesperdicio /= 100;
      if (this.isNew) {
        this.catalogosService.postEntity(this.entity, ROUTE_IMPRESORAS);
      } else {
        this.catalogosService.putEntity(this.entity, ROUTE_IMPRESORAS);
      }
    }
  }

  RemoveRodillo(rodillo: IRodillo) {
    this.entity.Rodillos.splice(this.entity.Rodillos.indexOf(rodillo), 1);
  }

  AddRodillo() {
    const dRef = this.dialog.open<AddRodilloComponent, any, IRodillo>(AddRodilloComponent, {
      disableClose: true,
      width: '400px',
    });

    dRef.afterClosed().subscribe(rod => {
      if (
        rod !== null &&
        rod.Cantidad > 0 &&
        rod.Medida > 0 &&
        this.entity.Rodillos.findIndex(t => t.Medida === rod.Medida) === -1
      ) {
        this.entity.Rodillos.push(rod);
      } else if (rod !== null) {
        this.dialogService.showDialog(error, invalidValue, { Icon: DialogIcons.Error });
      }
    });
  }

  RemoveConfTinta(tinta: IConfigTintaMaquina) {
    this.entity.ConfiguracionTintas.splice(this.entity.ConfiguracionTintas.indexOf(tinta), 1);
  }

  AddConfTinta() {
    const dRef = this.dialog.open<AddConfigTintaComponent, any, IConfigTintaMaquina>(
      AddConfigTintaComponent,
      {
        disableClose: true,
        width: '400px',
      },
    );

    dRef.afterClosed().subscribe(cf => {
      if (
        cf !== null &&
        cf.Cantidad > 0 &&
        cf.MinimoMetros > 0 &&
        this.entity.ConfiguracionTintas.findIndex(t => t.Cantidad === cf.Cantidad) === -1
      ) {
        this.entity.ConfiguracionTintas.push(cf);
      } else if (cf !== null) {
        this.dialogService.showDialog(error, invalidValue, { Icon: DialogIcons.Error });
      }
    });
  }
}
