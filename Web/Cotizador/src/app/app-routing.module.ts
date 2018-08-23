import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { UsuariosComponent } from './usuarios/usuarios.component';
import { CatalogosComponent } from './catalogos/catalogos.component';
import { ClientesComponent } from './catalogos/clientes/clientes.component';
import { FamiliasMaterialesComponent } from './catalogos/familias-materiales/familias-materiales.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'usuarios', component: UsuariosComponent },
  {
    path: 'catalogos',
    children: [
      { path: '', component: CatalogosComponent },
      { path: 'Clientes', component: ClientesComponent },
      { path: 'FamiliasMateriales', component: FamiliasMaterialesComponent },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: true })],
  exports: [RouterModule],
})
export class AppRoutingModule {}
