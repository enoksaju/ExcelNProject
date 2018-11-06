import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { enableProdMode } from '@angular/core';
import { AppModule } from './app/app.module';

import '../common/prototypes/date.extensions';
import '../common/prototypes/string.extensions';

//import { environment } from './environments/environment';
enableProdMode();
platformBrowserDynamic().bootstrapModule(AppModule).catch(err => console.log(err));