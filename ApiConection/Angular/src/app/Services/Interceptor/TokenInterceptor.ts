import { Injectable } from '@angular/core';
import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest, HttpClient, HttpErrorResponse } from '@angular/common/http';
import { throwError, of, Observable, config } from 'rxjs';
import { tap, filter, map, flatMap, catchError, retry, switchMap } from 'rxjs/operators';
import { IdentityService } from '../identity.service';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';

@Injectable()
export class TokenInterceptor implements HttpInterceptor {

  constructor(
    private httpClient: HttpClient,
    private identityService: IdentityService,
    private router: Router,
    private _snackBar: MatSnackBar) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(this.attachTokenToRequest(req)).pipe(
      catchError((error: HttpErrorResponse) => {
        if (error instanceof HttpErrorResponse) {
          if (error.status === 401) {
            return this.handleHttpResponseError(req, next);
          }
        }
        return throwError(error);
      }))
  }


  private handleHttpResponseError(request: HttpRequest<any>, next: HttpHandler) {
    const accessToken = this.identityService.hasToken();
    if (!accessToken) {
      this.identityService.goToRoute('login', { queryParams: { 'toRoute': this.router.url } });
      this._snackBar.open('No hay credenciales para este recurso, inicie sesión', '', { duration: 5000 })
      return of(null);
    }
    let expire = this.identityService.isTokenExpired()
    if (!expire) {
      return next.handle(this.attachTokenToRequest(request));
    } else {
      return this.identityService.refreshToken()
        .pipe(
          switchMap(result => {
            return next.handle(this.attachTokenToRequest(request))
          }), catchError((err: HttpErrorResponse) => {
            console.log(err.status);
            sessionStorage.clear();
            this.identityService.goToRoute('login', { queryParams: { 'toRoute': this.router.url } });
            this._snackBar.open('La sesion expiró, inicie sesion nuevamente', '', { duration: 5000 })
            return of(null);
          })
        );
    }
  }

  private attachTokenToRequest(request: HttpRequest<any>) {
    let token = sessionStorage.getItem('accessToken');
    return request.clone({
      setHeaders: {
        Authorization: `Bearer ${token}`
      }
    });
  }
}

        // if (response.status === 401) {

        //   console.log(req.urlWithParams + ' regresó con error 401')

        //   return this.http.post().catch();

          // return this.httpClient.post<Observable<any>>('/TOKEN',
          //   'refresh_token=' + sessionStorage.getItem('refreshToken') + '&grant_type=refresh_token',
          //   { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } })
          //   .pipe(
          //     catchError((data: any) => {
          //       console.log('enter error2');
          //       return next.handle(req);
          //     }),
          //     flatMap((data: any) => {
          //       console.log('enter error');
          //       sessionStorage.setItem('accessToken', data.access_token);
          //       sessionStorage.setItem('refreshToken', data.refresh_token);
          //       token = data.access_token;
          //       req = req.clone({
          //         setHeaders: {
          //           Authorization: 'Bearer ' + token
          //         }
          //       });
          //       return next.handle(req);
          //     })
          //   )
//         }
//       })
//     );
//   }
// }
