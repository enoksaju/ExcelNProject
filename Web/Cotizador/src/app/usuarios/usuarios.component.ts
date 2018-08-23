import { Component, OnInit } from '@angular/core';
import { BasicInfoUser, UsuariosService, UserInfo } from '../usuarios.service';
import { MatDialog } from '@angular/material';
import { AgregarUsuarioComponent } from './agregar-usuario.component';
import { ManageRolesComponent } from './manage-roles.component';

@Component({
  selector: 'adm-usuarios.cc',
  templateUrl: './usuarios.component.html',
  styleUrls: ['./usuarios.component.scss'],
})
export class UsuariosComponent implements OnInit {
  Usuarios: BasicInfoUser[];
  displayedColumns: string[] = ['Nombre', 'Email', 'EmailConfirmed', 'Roles'];
  constructor(private usuarioService: UsuariosService, private dialog: MatDialog) {}

  ngOnInit() {
    this.usuarioService
      .CurrentIsInRol('Administrador,Sistemas,Develop')
      .toPromise()
      .then(isAdmin => {
        if (isAdmin) {
          this.refreshUsers();
        } else {
          this.usuarioService.goToRoute();
        }
      });
  }

  private async refreshUsers() {
    this.Usuarios = await this.usuarioService.GetUsers().toPromise();
  }
  addUser() {
    const ref = this.dialog.open(AgregarUsuarioComponent, { disableClose: true });
    ref.afterClosed().subscribe(() => {
      this.refreshUsers();
    });
  }
  editRoles(user: UserInfo) {
    const ref = this.dialog.open(ManageRolesComponent, { disableClose: true, data: user });
  }
}
