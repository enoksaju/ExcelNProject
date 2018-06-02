import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { enableProdMode } from '@angular/core';
import { AppModule } from './app/app.module';
import 'hammerjs';

import '../common/prototypes/date.extensions';
import '../common/prototypes/string.extensions';

enableProdMode();
platformBrowserDynamic().bootstrapModule(AppModule).catch(err => console.log(err));