import { NgModule, Input } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule } from '@angular/http';
import { RouterModule, PreloadAllModules } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
// Material Secction
import { MaterialModule } from '../../homeApp/app/MyMaterialModule.module'

// AppSection
import { AppComponent, errorSnackComponent} from './components/app.component';
//import { MainComponent } from './components/main.component';
//import { AboutComponent } from './components/about.component'

@NgModule({
  imports: [
    BrowserModule,
    HttpModule,
    MaterialModule, //Angular Material
    FormsModule,
    ReactiveFormsModule
  ],
  declarations: [
    AppComponent,
    errorSnackComponent
  ],
  bootstrap: [
    AppComponent
  ],
  entryComponents: [
    errorSnackComponent
  ]
})
export class AppModule { }