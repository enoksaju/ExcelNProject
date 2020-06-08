import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { CalSemComponent } from './cal-sem/cal-sem.component';
import { LoginComponent } from './login/login.component';
import { AuthGuard } from './Services/Interceptor/AuthGuard';
import { Roles } from './Services/identity.service';
import { ProgressWorkOrderComponent } from './cal-sem/progress-work-order/progress-work-order.component';



const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'progreso-ot/:ot', component: ProgressWorkOrderComponent },
  {
    path: 'cal', data: { roles: [Roles.AdministradorProduccion] }, canActivate: [AuthGuard],
    children: [
      {
        path: '', component: CalSemComponent
      },
      { path: 'progreso/:ot', component: ProgressWorkOrderComponent }
    ]
  },
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'login', component: LoginComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: true })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
