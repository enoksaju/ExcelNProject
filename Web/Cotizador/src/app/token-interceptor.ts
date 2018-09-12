import { Injectable, NgZone } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpResponse,
  HttpErrorResponse,
  HttpResponseBase
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap, filter, map } from 'rxjs/operators';
import { Router } from '@angular/router';

@Injectable()
export class TokenInterceptor implements HttpInterceptor {

  constructor(private router: Router, private ngZone: NgZone) { }
  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const started = Date.now();

    request = request.clone({
      setHeaders: {
        Authorization: 'Bearer ' + sessionStorage.getItem('accessToken')
      }
    });

    return next.handle(request).pipe(tap(event => {
      // if (event instanceof HttpResponse) {
      //   const elapsed = Date.now() - started;
      //   console.log(`La respuesta desde ${request.urlWithParams} tomó ${elapsed} ms.`);
      // }
    }));
  }
}
