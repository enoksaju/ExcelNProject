import { BrowserModule } from '@angular/platform-browser';
import { NgModule, Inject, CUSTOM_ELEMENTS_SCHEMA, LOCALE_ID } from '@angular/core';
import {
  APP_BASE_HREF,
  HashLocationStrategy,
  LocationStrategy,
  registerLocaleData,
} from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { CustomBreakPointsProvider } from './custom-breackpoints';
import localeMx from '@angular/common/locales/es-MX';
import { DeviceDetectorModule } from 'ngx-device-detector';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './/material.module';
import { TokenInterceptor } from './token-interceptor';
import { MatPaginatorIntlCro } from './mat-paginator-intl-cro';
import { MatPaginatorIntl } from '@angular/material';
import { LoginComponent } from './login/login.component';
import { UsuariosComponent } from './usuarios/usuarios.component';
import { CatalogosComponent } from './catalogos/catalogos.component';
import { AgregarUsuarioComponent } from './usuarios/agregar-usuario.component';
import { DialogComponent } from './dialog.component';
import { ManageRolesComponent } from './usuarios/manage-roles.component';
import { ClientesComponent } from './catalogos/clientes/clientes.component';
import { AddClienteComponent } from './catalogos/clientes/add-cliente.component';
import {
  WrapInputsComponent,
  WrapInputsContainerComponent,
} from './common/wrap-inputs/wrap-inputs.component';
import { FamiliasMaterialesComponent } from './catalogos/familias-materiales/familias-materiales.component';
import { MyCardComponent } from './common/my-card/my-card.component';
import { AddEditFamiliaMaterialesComponent } from './catalogos/familias-materiales/add-edit-familia-materiales.component';
import { MovimientosFamiliasMaterialesComponent } from './catalogos/familias-materiales/movimientos-familias-materiales.component';
import { BottomActionsMyCardComponent } from './common/my-card/bottom-actions-my-card.component';
import { AddMovimientosFamiliasMaterialesComponent } from './catalogos/familias-materiales/add-movimientos-familias-materiales.component';
import { MaterialesComponent } from './catalogos/materiales/materiales.component';
import { AddEditMaterialComponent } from './catalogos/materiales/add-edit-material.component';
import { DetailMaterialComponent } from './catalogos/materiales/detail-material/detail-material.component';
import { ImpresorasComponent } from './catalogos/impresoras/impresoras.component';
import { DetailImpresoraComponent } from './catalogos/impresoras/detail-impresora/detail-impresora.component';
import { AddEditImpresoraComponent } from './catalogos/impresoras/add-edit-impresora/add-edit-impresora.component';
import { AddRodilloComponent } from './catalogos/impresoras/add-edit-impresora/add-rodillo.component';
import { AddConfigTintaComponent } from './catalogos/impresoras/add-edit-impresora/add-config-tinta.component';
import { InitialPageComponent } from './initial-page/initial-page.component';
import { TintasComponent } from './catalogos/tintas/tintas.component';
import { OtrosComponent } from './catalogos/otros/otros.component';
import { AddEditTintaComponent } from './catalogos/tintas/add-edit-tinta/add-edit-tinta.component';
import { AddEditOtrosComponent } from './catalogos/otros/add-edit-otros/add-edit-otros.component';

registerLocaleData(localeMx, 'es-MX');

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    UsuariosComponent,
    CatalogosComponent,
    AgregarUsuarioComponent,
    DialogComponent,
    ManageRolesComponent,
    ClientesComponent,
    AddClienteComponent,
    WrapInputsComponent,
    WrapInputsContainerComponent,
    FamiliasMaterialesComponent,
    MyCardComponent,
    AddEditFamiliaMaterialesComponent,
    MovimientosFamiliasMaterialesComponent,
    BottomActionsMyCardComponent,
    AddMovimientosFamiliasMaterialesComponent,
    MaterialesComponent,
    AddEditMaterialComponent,
    DetailMaterialComponent,
    ImpresorasComponent,
    DetailImpresoraComponent,
    AddEditImpresoraComponent,
    AddRodilloComponent,
    AddConfigTintaComponent,
    InitialPageComponent,
    TintasComponent,
    OtrosComponent,
    AddEditTintaComponent,
    AddEditOtrosComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    FormsModule,
    HttpClientModule,
    DeviceDetectorModule.forRoot()
  ],
  providers: [
    CustomBreakPointsProvider,
    { provide: LOCALE_ID, useValue: 'es-MX' },
    { provide: APP_BASE_HREF, useValue: '/' },
    { provide: HTTP_INTERCEPTORS, useClass: TokenInterceptor, multi: true },
    { provide: MatPaginatorIntl, useClass: MatPaginatorIntlCro },
    { provide: LocationStrategy, useClass: HashLocationStrategy },
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  bootstrap: [AppComponent],
  entryComponents: [
    AgregarUsuarioComponent,
    DialogComponent,
    ManageRolesComponent,
    AddClienteComponent,
    AddEditFamiliaMaterialesComponent,
    MovimientosFamiliasMaterialesComponent,
    BottomActionsMyCardComponent,
    AddMovimientosFamiliasMaterialesComponent,
    AddEditMaterialComponent,
    AddEditImpresoraComponent,
    AddRodilloComponent,
    AddConfigTintaComponent,
    AddEditTintaComponent,
    AddEditOtrosComponent,
  ],
})
export class AppModule {
  constructor(@Inject(APP_BASE_HREF) private baseHref: string) {
    console.log(`El HREF base es : ${this.baseHref}.`);
  }
}
