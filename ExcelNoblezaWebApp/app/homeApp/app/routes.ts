import { Routes, Route } from '@angular/router';
import { MainComponent } from './components/main.component';
import { AplicacionesComponent} from './components/aplicaciones.component';
import { ContactoComponent } from './components/contacto.component';

import {
  ProductsComponent,
  PeliculasComponent,
  BolsasComponent,
  PolietilenoComponent,
  EtiquetasComponent,
  InnovacionesComponent
} from './components/products/products';

export const routes: Routes = [
  { path: '', redirectTo: '/main', pathMatch: 'full' },
  { path: 'main', component: MainComponent },
  { path: 'aplicaciones', component: AplicacionesComponent },
  { path: 'contacto', component: ContactoComponent },
  {
    path: 'productos',
    component: ProductsComponent,
    children: [
      {
        path: 'peliculas',
        component: PeliculasComponent
      },
      {
        path: 'bolsas',
        component: BolsasComponent
      },
      {
        path: 'polietileno',
        component: PolietilenoComponent
      },
      {
        path: "etiquetas",
        component: EtiquetasComponent
      },
      {
        path: "innovaciones",
        component: InnovacionesComponent
      }
    ]
  },
  { path: '**', redirectTo: '/main', pathMatch: 'full' }
]