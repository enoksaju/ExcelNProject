import { Routes, Route } from '@angular/router';
import {
  IndexComponent,
  SolicitarComponent,
  SearchComponent,
  AdministrarComponent,
  ValidarComponent,
  ReporteComponent
} from './components/app';


export const routes: Routes = [
  { path: '', redirectTo: '/index', pathMatch: 'full' },
  { path: 'index', component: IndexComponent },
  { path: 'solicitar', component: SolicitarComponent },
  { path: 'descargar', component: SearchComponent },
  {
    path: 'administrar', component: AdministrarComponent,
    children: [
      { path: 'validar', component: ValidarComponent },
      { path: 'reporte', component: ReporteComponent },
    ]
  }
]