import { Component, OnInit, Inject } from '@angular/core';
import { ICliente, CatalogosService } from '../../catalogos.service';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { DialogService } from '../../dialog.service';
import { DialogButtonsFlags, DialogIcons } from '../../dialog.component';
import { UsuariosService } from '../../usuarios.service';
import { ISelectOptions } from '../../common/wrap-inputs/wrap-inputs.component';

@Component({
  selector: 'cat-add-cliente',
  template: `
    <form style="position:relative;" fxLayout="column" [formGroup]="ClienteForm" (ngSubmit)="onSubmit()" >
      <h2 mat-dialog-title>{{IsNew ? 'Agregar' : 'Editar'}} Cliente</h2>
      <mat-divider class="dialog-divider"></mat-divider>
      <!-- Contenido del dialogo -->
      <div mat-dialog-content fxLayout="column" class="mat-typography" style="min-height: 300px;">
        <!-- spinner -->
        <div fxLayoutAlign="center center" fxFlex="100%">
          <mat-spinner *ngIf="isLoading" color="accent" diameter="80"></mat-spinner>
        </div>
        <!-- Form -->
        <div *ngIf="!isLoading"  fxLayout="column" fxFlex="100%">
          <div fxLayout="column">
            <wrap-inputs [controls]="[{name:'ClaveCliente', text:'Clave', smflex:'100%'}]" [fGroup]="ClienteForm"></wrap-inputs>
            <wrap-inputs [controls]="[{name:'NombreCliente', text:'Nombre', smflex:'100%'}]" [fGroup]="ClienteForm"></wrap-inputs>
            <wrap-inputs [controls]="[{name:'NombreContacto', text:'Nombre del Contacto', smflex:'100%'}]" [fGroup]="ClienteForm"></wrap-inputs>
            <wrap-inputs [controls]="[{name:'Telefono', text:'Telefono'},{name:'Email', text: 'Email'}]" [fGroup]="ClienteForm"></wrap-inputs>
            <wrap-inputs [controls]="[{name: 'Domicilio', text:'Dirección', smflex:'100%'}]" [fGroup]="ClienteForm"></wrap-inputs>
            <wrap-inputs [controls]="[{name: 'Ciudad', text: 'Ciudad'},{name:'Estado', text:'Estado'}]" [fGroup]="ClienteForm"></wrap-inputs>
            <wrap-inputs *ngIf="showSelect()" [controls]="[{
              name:'AgenteId',
              text:'Agente',
              smflex:'100%',
              type:'select',
              selectOptions:agentes
            }]" [fGroup]="ClienteForm">
            </wrap-inputs>
          </div>
        </div>
      </div>

      <div mat-dialog-actions fxLayout="row" fxFlex="100%" fxLayoutAlign="center center">
        <button type="submit" mat-raised-button color="warn">{{IsNew ? 'Guardar' : 'Actualizar'}}</button>
      </div>
      <!-- CloseButton -->
      <button class="closeButton" mat-dialog-close tabIndex="3" color="warn" mat-icon-button>
          <mat-icon>close</mat-icon>
      </button>
  </form>
  `,
  styles: []
})
export class AddClienteComponent implements OnInit {
  Cliente: ICliente;
  IdCliente_: number;
  IsNew: boolean;
  isLoading: boolean;
  ClienteForm: FormGroup;
  agentes: Array<ISelectOptions>;

  constructor(public dialogRef: MatDialogRef<AddClienteComponent>,
    @Inject(MAT_DIALOG_DATA) public data: number,
    private catalogosService: CatalogosService,
    private dialogService: DialogService,
    private fb: FormBuilder,
    private usuariosService: UsuariosService
  ) {
    this.IdCliente_ = data;
    this.IsNew = data ? false : true;
    this.isLoading = !this.IsNew;
  }

  showSelect() {
    return this.usuariosService.CurrentIsInRol('Sistemas,Develop, Administrador');
  }

  ngOnInit() {
    this.createForm();
    this.usuariosService.GetUsers().subscribe(
      users => {
        this.agentes = new Array<ISelectOptions>();
        users.forEach(v => {
          this.agentes.push({ display: v.Nombre, value: v.Id });
        });
        if (this.ClienteForm) { this.isLoading = false; }
      },
      err => {
        this.agentes = new Array<ISelectOptions>({ display: 'Ninguno', value: 0 });
      }
    );
  }


  async onSubmit() {
    if (this.ClienteForm.valid) {
      this.isLoading = true;
      const c = () => this.isLoading = false;
      if (this.IsNew) {
        this.catalogosService.postCliente(this.ClienteForm.value)
          .subscribe(
            success => this.dialogService.showDialog('Correcto...', success, { Icon: DialogIcons.Success })
            .then(() => this.dialogRef.close()),
            error => this.dialogService.showDialog('Error!!', this.dialogService.getModelError(error), { buttons: DialogButtonsFlags.Ok, Icon: DialogIcons.Error })
              .then(c),
            c
          );

      } else {
        this.catalogosService.putCliente(this.ClienteForm.value)
          .subscribe(
            success => this.dialogService.showDialog('Correcto...', success, { Icon: DialogIcons.Success })
            .then(() => this.dialogRef.close()),
            error => this.dialogService.showDialog('Error!!', this.dialogService.getModelError(error), { buttons: DialogButtonsFlags.Ok, Icon: DialogIcons.Error })
              .then(c),
            c
          );
      }

    } else {
      this.dialogService.showDialog('Error!!', 'Por Favor, complete correctamente los campos del formulario', { buttons: DialogButtonsFlags.Ok, Icon: DialogIcons.Error });
    }
  }

  async createForm() {
    const MyId: number = +sessionStorage.getItem('userId');
    this.Cliente = this.IdCliente_ ? await this.catalogosService.getCliente(this.IdCliente_) : {
      ClaveCliente: '', NombreCliente: '', NombreContacto: '', Telefono: '', Email: '', Domicilio: '', Ciudad: '', Estado: '', AgenteId: MyId, NombreEjecutivo: ''
    };

    this.ClienteForm = this.fb.group({
      ClaveCliente: [this.Cliente.ClaveCliente, [Validators.required, Validators.pattern('[0-9A-Za-z-]{6,}')]],
      NombreCliente: [this.Cliente.NombreCliente, Validators.required],
      NombreContacto: [this.Cliente.NombreContacto, Validators.required],
      Telefono: [this.Cliente.Telefono, Validators.pattern('[0-9+]{0,3}[0-9]{3,3}[0-9]{7,7}')],
      Email: [this.Cliente.Email, Validators.email],
      Domicilio: [this.Cliente.Domicilio],
      Ciudad: [this.Cliente.Ciudad],
      Estado: [this.Cliente.Estado],
      AgenteId: [this.Cliente.AgenteId],
      Id: [this.Cliente.Id]
    });

    if (this.agentes) { this.isLoading = false; }
  }
}
