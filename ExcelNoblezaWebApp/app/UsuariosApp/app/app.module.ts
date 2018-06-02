import { NgModule, Input } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule } from '@angular/http';
import { AppRoutingModule } from './routes';

import { DateValueAccessorModule } from '../../common/date-value-accessor/index';

// Material Secction
import { MaterialModule } from '../../homeApp/app/MyMaterialModule.module'
import { MainComponent, MenuItemsComponent } from '../../common/components/main';
import { MatIconRegistry, MAT_DATE_LOCALE } from '@angular/material';
import { SmdFabSpeedDialActions, SmdFabSpeedDialComponent, SmdFabSpeedDialTrigger } from '../../common/components/fab-speed-dial/index'
// AppSection
import { AppComponent, IndexComponent, RoleUpdateDialog, UsuariosComponent, AddUserComponent } from './components/app';


//Servicios
import { UserService } from '../../common/Services/user.service';
import { TrabajadorService } from '../../common/Services/trabajador.service';
import { DialogsModule } from '../../common/Services/dialog.service';
import { ConverterService } from '../../common/Services/converter.service';
import { UsuariosService } from '../app/services/Usuario.service'

import 'rxjs/add/observable/of';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/debounceTime';
import 'rxjs/add/operator/distinctUntilChanged';
import 'rxjs/add/operator/switchMap';
import 'rxjs/add/observable/merge';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/startWith';
import 'rxjs/add/operator/toPromise';


@NgModule({
  imports: [
    BrowserModule,
    HttpModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
    DateValueAccessorModule,
    DialogsModule,
    AppRoutingModule
  ],
  declarations: [
    AppComponent, IndexComponent, RoleUpdateDialog, UsuariosComponent, AddUserComponent,
    MainComponent,
    MenuItemsComponent,
    SmdFabSpeedDialActions, SmdFabSpeedDialComponent, SmdFabSpeedDialTrigger
  ],
  providers: [
    UsuariosService,
    MatIconRegistry,
    UserService,
    ConverterService,
    TrabajadorService,
    { provide: MAT_DATE_LOCALE, useValue: 'es-MX' }
  ],
  bootstrap: [
    AppComponent
  ],
  entryComponents: [
    RoleUpdateDialog
  ]
})
export class AppModule {
  constructor(public matIconRegister: MatIconRegistry) {
    this.matIconRegister.registerFontClassAlias("fontawesome", "fa");
  }
}