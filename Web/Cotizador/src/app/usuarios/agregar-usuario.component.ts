import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, AbstractControl } from '../../../node_modules/@angular/forms';
import { MatDialogRef } from '../../../node_modules/@angular/material';
import { UsuariosService } from '../usuarios.service';
import { DialogIcons } from '../dialog.component';
import { DialogService } from '../dialog.service';

@Component({
  selector: 'app-agregar-usuario',
  template: `
  <div style="position:relative;" fxLayout="column">
  <mat-dialog-content>
      <form [formGroup]="userForm" fxLayout="column" fxLayoutAlign="center center" (ngSubmit)="onSubmit()" fxFlexFill>
          <div fxLayout="column">
              <mat-form-field>
                  <input formControlName="Nombre" matInput placeholder="Nombre">
                  <mat-error *ngIf="userForm.controls.Nombre.hasError('required')">
                      El Nombre del usuario es requerido.
                  </mat-error>
              </mat-form-field>

              <div fxLayout="row wrap" fxLayoutAlign="space-between start" fxLayoutGap="5px">
                  <mat-form-field fxFlex="100%" fxFlex.gt-sm="48%">
                      <input formControlName="ApellidoPaterno" matInput placeholder="Apellido Paterno">
                      <mat-error *ngIf="userForm.controls.ApellidoPaterno.hasError('required')">
                          El Apellido Paterno es requerido.
                      </mat-error>
                  </mat-form-field>
                  <mat-form-field fxFlex="100%" fxFlex.gt-sm="48%">
                      <input formControlName="ApellidoMaterno" matInput placeholder="Apellido Materno">
                      <mat-error *ngIf="userForm.controls.ApellidoMaterno.hasError('required')">
                          El Apellido Materno es requerido.
                      </mat-error>
                  </mat-form-field>
              </div>

              <mat-form-field>
                  <input type="number" formControlName="Clave" matInput placeholder="Clave de Trabajador">
                  <mat-error *ngIf="userForm.controls.Clave.hasError('required')">
                    La clave es requerida.
                  </mat-error>
                  <mat-error *ngIf="userForm.controls.Clave.hasError('pattern')">
                    El valor debe ser numerico y contener al menos 4 digitos.
                  </mat-error>
              </mat-form-field>

              <mat-form-field>
                  <input type="email" formControlName="Email" matInput placeholder="Correo Electronico">
                  <mat-error *ngIf="userForm.controls.Email.hasError('email')">
                      El Email no es valido.
                  </mat-error>
                  <mat-error *ngIf="userForm.controls.Email.hasError('required')">
                      El Email es requerido.
                  </mat-error>
              </mat-form-field>

              <mat-form-field>
                  <input type="password" formControlName="Password" matInput placeholder="Contraseña">
                  <mat-error *ngIf="userForm.controls.Password.hasError('required')">
                      La contraseña es requerida.
                  </mat-error>
                  <mat-error *ngIf="userForm.controls.Password.hasError('pattern')">
                      La contraseña debe contener al menos un digito y una letra Mayuscula y debe ser de mas de 8 caracteres de largo.
                  </mat-error>
              </mat-form-field>

              <mat-form-field>
                  <input type="password" formControlName="ConfirmPassword" matInput placeholder="Confirme Contraseña">
                  <mat-error *ngIf="userForm.controls.ConfirmPassword.hasError('required')">
                      El confirmacion de la contraseña es requerida.
                  </mat-error>
                  <mat-error *ngIf="userForm.controls.ConfirmPassword.hasError('MatchPassword')">
                      Las contraseñas no coinciden
                  </mat-error>
              </mat-form-field>
              <button type="submit" mat-raised-button color="primary">Registrar</button>
          </div>
      </form>
  </mat-dialog-content>
  <!-- CloseButton -->
  <button class="closeButton" mat-dialog-close tabIndex="3" color="warn" mat-icon-button>
      <mat-icon>close</mat-icon>
  </button>
</div>
  `,
  styles: []
})
export class AgregarUsuarioComponent implements OnInit {

  userForm: FormGroup;
  constructor(
    public dialogRef: MatDialogRef<AgregarUsuarioComponent>,
    private fb: FormBuilder,
    private dialogService: DialogService,
    private usuariosService: UsuariosService) {
    this.createForm();
  }
  ngOnInit() {
  }
  /**
   * Crea el formulario para agregar un usuario
   */
  createForm() {
    this.userForm = this.fb.group({
      Nombre: ['', Validators.required],
      ApellidoPaterno: ['', Validators.required],
      ApellidoMaterno: ['', Validators.required],
      Email: ['', [Validators.email, Validators.required]],
      Password: ['', [Validators.required, Validators.pattern('^(?=.*\\d)[A-Za-z\\d#$@!%&*?]{8,}$')]],
      ConfirmPassword: ['', Validators.required],
      Clave: ['', [Validators.required, Validators.pattern('^[0-9]{4,}$')]]
    }, {
        validator: PasswordValidation.MatchPassword
      });
  }

  /**
 * Envia a la API los datos de registro del usuario
 */
  onSubmit() {
    if (this.userForm.valid) {
      this.usuariosService.registrar(this.userForm.value)
        .subscribe(success => { this.dialogService.showDialog('Correcto...', 'Se agrego correctamente el usuario, <br />Por favor, confirme el registro mediante el correo electronico que hemos enviado.', { Icon: DialogIcons.Success }); },
          error => {
            this.dialogService.showDialog('Error en los Datos', this.dialogService.getModelError(error), { Icon: DialogIcons.Error });
          }
        );

    } else {
      this.dialogService.showDialog('Error en los Datos', 'Por favor, complete los campos adecuadamente', { Icon: DialogIcons.Error });
    }
  }
}

/**
 * Clase para comprobar que los password sean correctos
 */
export class PasswordValidation {
  static MatchPassword(AC: AbstractControl) {
    const password = AC.get('Password').value; // to get value in input tag
    const confirmPassword = AC.get('ConfirmPassword').value; // to get value in input tag
    if (password !== confirmPassword) {
      AC.get('ConfirmPassword').setErrors({ MatchPassword: true });
    } else {
      return null;
    }
  }
}
