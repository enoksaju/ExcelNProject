import { Routes, Route } from '@angular/router';
import { IndexComponent, SearchComponent, ProgressComponent } from './components/app';


export const routes: Routes = [
  { path: '', redirectTo: '/index', pathMatch: 'full' },
  { path: 'index', component: IndexComponent },
  { path: 'search', component: SearchComponent },
  { path: 'progress', component: ProgressComponent }
]