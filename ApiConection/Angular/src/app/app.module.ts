import { BrowserModule, DomSanitizer } from '@angular/platform-browser';
import { NgModule, LOCALE_ID, } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialDesignModule } from './material-design.module';
import { CalSemComponent } from './cal-sem/cal-sem.component';
import { MatIconRegistry } from '@angular/material/icon';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ItemOTComponent, OptionsSelectedItemOverviewSheet, DialogDetailsCalendarItem } from './cal-sem/item-ot/item-ot.component';
import { TokenInterceptor } from './Services/Interceptor/TokenInterceptor';
import { LoginComponent } from './login/login.component';
import localeMx from '@angular/common/locales/es-MX';
import { registerLocaleData } from '@angular/common';
import { FilterPipe } from './Services/pipe/filter.pipe';
import { DialogComponent } from './Services/Dialog/dialog.component';
import { ProgressWorkOrderComponent } from './cal-sem/progress-work-order/progress-work-order.component';

import { PdfViewerModule } from 'ng2-pdf-viewer';

registerLocaleData(localeMx);

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    CalSemComponent,
    ItemOTComponent,
    LoginComponent,
    FilterPipe,
    DialogComponent,
    OptionsSelectedItemOverviewSheet,
    DialogDetailsCalendarItem,
    ProgressWorkOrderComponent
  ],
  entryComponents: [
    OptionsSelectedItemOverviewSheet, DialogDetailsCalendarItem
  ],
  imports: [
    BrowserModule,
    PdfViewerModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialDesignModule,
    HttpClientModule
  ],
  providers: [
    { provide: LOCALE_ID, useValue: 'es-MX' },
    { provide: HTTP_INTERCEPTORS, useClass: TokenInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
  constructor(matIconRegistry: MatIconRegistry, domSanitizer: DomSanitizer) {
    matIconRegistry.addSvgIconSet(domSanitizer.bypassSecurityTrustResourceUrl('./assets/mdi.svg'));
  }

}
