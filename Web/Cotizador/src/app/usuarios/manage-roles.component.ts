import { Component, OnInit, Inject } from '@angular/core';
import { BasicInfoUser, UsuariosService, Actions } from '../usuarios.service';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { DialogService } from '../dialog.service';
import { DialogIcons, DialogButtonsFlags, DialogResults } from '../dialog.component';

@Component({
  selector: 'app-manage-roles',
  template: `
  <div fxLayout="column" class="mat-typography">
  <h3>Usuario: {{User.Nombre}}</h3>
  <h3>Email: {{User.Email}}</h3>
  <mat-divider></mat-divider>
  <div mat-dialog-content fxFlex="100%">
      <p>Roles del usuario:</p>
      <mat-chip-list #chipList class="mat-chip-list-stacked" aria-orientation="vertical">

          <ng-container *ngFor="let itm of User.Roles">

              <mat-chip color="accent" selected (removed)="removeRol(itm)" [removable]="true">
                  {{itm}}
                  <span style="flex: 1 1 100%"></span>
                  <mat-icon matChipRemove>cancel</mat-icon>
              </mat-chip>

          </ng-container>


      </mat-chip-list>
      <br />
      <div fxLayout="row">
          <p>El rol "Usuario" no puede ser removido.</p>
      </div>
  </div>
  <mat-divider></mat-divider>
  <div matDialogActions fxLayout="column">
      <div fxLayout="row" style="font-size: 18px;" fxLayoutGap="5px">
          <mat-form-field fxFlex>
              <input #rolInput name="rol" matInput placeholder="Rol">
          </mat-form-field>
          <div fxLayoutAlign="center center" >
              <button [disabled]="!rolInput.value" mat-mini-fab  (click)="addRole(rolInput.value)" color="primary">
                  <mat-icon>add</mat-icon>
              </button>
          </div>
      </div>
      <button mat-stroked-button mat-dialog-close color="warn">Cerrar</button>
  </div>
</div>
  `,
  styles: []
})
export class ManageRolesComponent {
  User: BasicInfoUser;
  constructor(
    public dialogRef: MatDialogRef<ManageRolesComponent>,
    @Inject(MAT_DIALOG_DATA) public data: BasicInfoUser,
    private usuariosService: UsuariosService,
    private dialogService: DialogService
  ) {
    this.User = this.data;
  }

  addRole(role: string) {
    if (!this.User.Roles.includes(role)) {
      this.usuariosService.ManageRoles({ UserId: this.User.Id, Action: Actions.Add, Role: role })
        .then(
          val => {
            console.log(val);
            this.User.Roles.push(role);
          },
          err => this.dialogService.showDialog('Error', err.error.Message, { Icon: DialogIcons.Error }));
    }
  }

  removeRol(role: string) {
    if (role !== 'Usuario') {
      this.dialogService.showDialog(
        'Confirmar',
        'Deasea remover el rol ' + role,
        { Icon: DialogIcons.Question, buttons: DialogButtonsFlags.Yes | DialogButtonsFlags.No })
        .then((resp) => {
          if (resp === DialogResults.Yes) {
            this.usuariosService.ManageRoles({ UserId: this.User.Id, Action: Actions.Remove, Role: role })
              .then(
                val => {
                  console.log(val);
                  const idx = this.User.Roles.indexOf(role);
                  if (idx > -1) {
                    this.User.Roles.splice(idx, 1);
                  }
                },
                err => this.dialogService.showDialog('Error', err.error.Message, { Icon: DialogIcons.Error }));
          }
        });

    } else {
      this.dialogService.showDialog('Error', 'El rol Usuario no se puede eliminar', { Icon: DialogIcons.Error });
    }
  }
}
