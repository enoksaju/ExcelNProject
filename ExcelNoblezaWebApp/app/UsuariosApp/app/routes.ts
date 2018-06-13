import { NgModule } from '@angular/core';
import { Routes, Route, RouterModule } from '@angular/router';
import { IndexComponent, AddUserComponent, UsuariosComponent } from './components/app';


export const routes: Routes = [
  {
    path: 'users',
    component: UsuariosComponent,
    children: [
      { path: 'index', component: IndexComponent },
      { path: 'adduser', component: AddUserComponent },
      { path: '', redirectTo: 'index', pathMatch: 'full' }
    ]
  },
  { path: '', redirectTo: '/users/index', pathMatch: 'full' },
  { path: '**', redirectTo: '/users/index', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: true })],
  exports: [RouterModule]
})
export class AppRoutingModule { }