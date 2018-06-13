import { NgModule, Input } from '@angular/core';
import { FormsModule , ReactiveFormsModule} from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule } from '@angular/http';
import { RouterModule, PreloadAllModules } from '@angular/router';
import { routes } from './routes';
// Material Secction
import { MaterialModule } from './MyMaterialModule.module'
import { NgxGalleryModule } from 'ngx-gallery';
import { MatIconRegistry } from '@angular/material';

// AppSection
import { AppComponent } from './components/app.component';
import { MainComponent } from './components/main.component';
import { AplicacionesComponent } from './components/aplicaciones.component';
import { ContactoComponent } from './components/contacto.component';

import { ProductsComponent, PeliculasComponent, BolsasComponent, PolietilenoComponent, EtiquetasComponent, InnovacionesComponent } from './components/products/products';

//Common Components
import { MenuItemsComponent } from '../../common/components/menuitem.component';
import { Carousel, Slide } from '../../common/components/carousel.component';
import { CardContentComponent } from '../../common/components/cardcontainer.component';


//Servicios
import { UserService } from '../../common/Services/user.service'



@NgModule({
  imports: [
    BrowserModule,
    HttpModule,
    MaterialModule, //Angular Material
    RouterModule.forRoot(routes, { useHash: true, preloadingStrategy: PreloadAllModules}),
    FormsModule,
    ReactiveFormsModule,
    NgxGalleryModule
  ],
  declarations: [
    AppComponent,
    MainComponent,    
    AplicacionesComponent,
    MenuItemsComponent,
    Carousel, Slide,
    CardContentComponent,
    ProductsComponent,
    PeliculasComponent,
    BolsasComponent,
    PolietilenoComponent,
    EtiquetasComponent,
    InnovacionesComponent,
    ContactoComponent
  ],
  providers: [
    MatIconRegistry,
    UserService
  ],
  bootstrap: [
    AppComponent
  ]
})
export class AppModule {
  constructor(public matIconRegister: MatIconRegistry) {
    this.matIconRegister.registerFontClassAlias("fontawesome", "fa");
  }
}
