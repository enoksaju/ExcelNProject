import { NgModule, Input } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule } from '@angular/http';
import { RouterModule, PreloadAllModules } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { routes } from './routes';
import { DateValueAccessorModule } from '../../common/date-value-accessor/index';

// Material Secction
import { MaterialModule } from '../../homeApp/app/MyMaterialModule.module'
import { MainComponent, MenuItemsComponent } from '../../common/components/main';
import { MatIconRegistry, MAT_DATE_LOCALE } from '@angular/material';
import { SmdFabSpeedDialActions, SmdFabSpeedDialComponent, SmdFabSpeedDialTrigger } from '../../common/components/fab-speed-dial/index'
// AppSection
import { AppComponent, IndexComponent, SolicitarComponent, SearchComponent, AdministrarComponent, ValidarComponent, ReporteComponent } from './components/app';


//Servicios
import { UserService } from '../../common/Services/user.service';
import { TrabajadorService } from '../../common/Services/trabajador.service';
import { DialogsModule } from '../../common/Services/dialog.service';
import { PermisoDetailsModule } from './services/permisodetails.service';
import { ConverterService } from '../../common/Services/converter.service';



@NgModule({
  imports: [
    BrowserModule,
    HttpModule,
    MaterialModule, //Angular Material
    RouterModule.forRoot(routes, { useHash: true, preloadingStrategy: PreloadAllModules }),
    FormsModule,
    ReactiveFormsModule,
    ReactiveFormsModule,
    DateValueAccessorModule,
    DialogsModule,
    PermisoDetailsModule
  ],
  declarations: [
    AppComponent, IndexComponent, SolicitarComponent, SearchComponent, ValidarComponent, AdministrarComponent, ReporteComponent,
    MainComponent,
    MenuItemsComponent,
    SmdFabSpeedDialActions, SmdFabSpeedDialComponent, SmdFabSpeedDialTrigger
  ],
  providers: [
    MatIconRegistry,
    UserService,
    ConverterService,
    TrabajadorService,
    { provide: MAT_DATE_LOCALE, useValue: 'es-MX' }
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