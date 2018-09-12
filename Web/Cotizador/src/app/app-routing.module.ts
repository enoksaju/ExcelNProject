import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { UsuariosComponent } from './usuarios/usuarios.component';
import { CatalogosComponent } from './catalogos/catalogos.component';
import { ClientesComponent } from './catalogos/clientes/clientes.component';
import { FamiliasMaterialesComponent } from './catalogos/familias-materiales/familias-materiales.component';
import { MaterialesComponent } from './catalogos/materiales/materiales.component';
import { DetailMaterialComponent } from './catalogos/materiales/detail-material/detail-material.component';
import { ImpresorasComponent } from './catalogos/impresoras/impresoras.component';
import { DetailImpresoraComponent } from './catalogos/impresoras/detail-impresora/detail-impresora.component';
import { InitialPageComponent } from './initial-page/initial-page.component';

const routes: Routes = [
  { path: '', component: InitialPageComponent},
  { path: 'login', component: LoginComponent },
  { path: 'usuarios', component: UsuariosComponent },
  {
    path: 'catalogos',
    children: [
      { path: '', component: CatalogosComponent },
      { path: 'Clientes', component: ClientesComponent },
      { path: 'FamiliasMateriales', component: FamiliasMaterialesComponent },
      {
        path: 'Materiales',
        children: [
          { path: '', component: MaterialesComponent },
          { path: ':Id', component: DetailMaterialComponent }
        ]
      },
      {
        path: 'Impresoras',
        children: [
          { path: '', component: ImpresorasComponent },
          { path: ':Id', component: DetailImpresoraComponent }
        ]
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: true })],
  exports: [RouterModule]
})
export class AppRoutingModule {}
