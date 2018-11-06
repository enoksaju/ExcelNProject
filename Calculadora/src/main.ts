import { enableProdMode } from '@angular/core';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { AppModule } from './app/app.module';
import { environment } from './environments/environment';

import 'hammerjs';

if (environment.production) {
  enableProdMode();
}

// platformBrowserDynamic().bootstrapModule(AppModule)
//   .catch(err => console.log(err));
const bootstrap = () => {
  platformBrowserDynamic().bootstrapModule(AppModule);
};

if (window['cordova']) {
  console.log('Cordova found');
  document.addEventListener('deviceready', bootstrap);
  document.addEventListener('backbutton', e => {
    e.preventDefault();
  });
} else {
  console.log('Cordova not found');
  bootstrap();
}
