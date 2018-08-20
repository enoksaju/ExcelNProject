import { BrowserModule } from '@angular/platform-browser';
import { NgModule, Inject } from '@angular/core';
import { APP_BASE_HREF } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

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
import { WrapInputsComponent} from './common/wrap-inputs/wrap-inputs.component';



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
    WrapInputsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [
    { provide: APP_BASE_HREF, useValue: '/' },
    { provide: HTTP_INTERCEPTORS, useClass: TokenInterceptor, multi: true },
    { provide: MatPaginatorIntl, useClass: MatPaginatorIntlCro }
  ],
  bootstrap: [AppComponent],
  entryComponents: [AgregarUsuarioComponent, DialogComponent, ManageRolesComponent, AddClienteComponent]
})
export class AppModule {
  constructor(@Inject(APP_BASE_HREF) private baseHref: string) {
    console.log(`El HREF base es : ${ this.baseHref }.` );
  }
}
