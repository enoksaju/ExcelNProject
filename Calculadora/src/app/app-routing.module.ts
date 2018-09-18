import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { InicioComponent } from './inicio/inicio.component';
import { MetrosLinealesComponent } from './metros-lineales/metros-lineales.component';

const routes: Routes = [
  { path: 'inicio', component: InicioComponent },
  { path: 'metros', component: MetrosLinealesComponent},
  { path: '', redirectTo: 'inicio', pathMatch: 'full' },
  { path: '**', redirectTo: 'inicio' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: true })],
  exports: [RouterModule]
})
export class AppRoutingModule {}
