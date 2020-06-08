import { Injectable, NgZone } from '@angular/core';
import { BehaviorSubject, Observable, Subscription } from 'rxjs';
import { HttpErrorResponse, HttpClient, JsonpInterceptor } from '@angular/common/http';
import { Router } from '@angular/router';
import { map, flatMap } from 'rxjs/operators';

/**
 * Clase  que contiene los datos de inicio de sesión
 */
export class UserLogin {
  grant_type: 'password';
  username: string;
  password: string;
}

export interface iUser {
  Nombre: string;
  ApellidoPaterno: string;
  ApellidoMaterno: string;
  Estatus?: any;
  Email?: string;
  Clave?: number;
  Roles?: string[];
  Id: string;
}

export enum Roles {
  Develop = 'Develop',
  Administrador = "Administrador",
  Sistemas = "Sistemas",
  Usuario = "Usuario",
  Consultas = "Consultas",
  AdministradorRecursosHumanos = "Administrador Recursos Humanos",
  UsuarioRecursosHumanos = "Usuario Recursos Humanos",
  SupervisorProduccion = "Supervisor Produccion",
  AdministradorProduccion = "Administrador Produccion",
  UsuarioProduccion = "Usuario Produccion",
  AdministradorVentas = "Administrador Ventas",
  EjecutivoVentas = "Ejecutivo Ventas",
  AuxiliarVentas = "Auxiliar Ventas"
}


@Injectable({
  providedIn: 'root'
})
export class IdentityService {
  private data1 = new BehaviorSubject<boolean>(false);

  private User_: BehaviorSubject<iUser>;
  public currentUser: Observable<iUser>;

  public get currenUserValue(): iUser {
    return this.User_.value;

  }

  public RolesLibrary = { rl: Roles };

  constructor(private http: HttpClient, private router: Router, private ngZone: NgZone) {
    // if (sessionStorage.getItem('userData')) {
    //   let usr = JSON.parse(sessionStorage.getItem('userData'));
    //   this.User_.next(usr);
    //   console.log(usr);
    // }

    this.User_ = new BehaviorSubject<iUser>(JSON.parse(sessionStorage.getItem('userData')));
    this.currentUser = this.User_.asObservable();
  }

  getUSerInfo() {
    return this.User_.asObservable();
  }

  UserHasRoles(roles: string[]): Boolean {
    return this.currenUserValue.Roles.some(rol => {
      if (roles && roles.indexOf(rol) > -1) {
        return true;
      }
    });
  }

  /**
  * Genera el Token de credenciales
  * @param userLogin Credenciales de incio de sesión
  */
  public login(
    userLogin: UserLogin,
    toRoute: string = '',
    successCallback: Function = () => { },
    errorCallback: (error: HttpErrorResponse) => void,
  ) {
    this.http
      .post(
        '/TOKEN',
        'username=' +
        userLogin.username +
        '&password=' +
        userLogin.password +
        '&grant_type=password',
        { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } },
      )
      .subscribe(
        (resp: any) => {
          sessionStorage.setItem('accessToken', resp.access_token);
          sessionStorage.setItem('refreshToken', resp.refresh_token);
          let now = new Date();
          let c = new Date(now.setSeconds(now.getSeconds() + resp.expires_in));
          sessionStorage.setItem('expireAt', JSON.stringify(c))
          sessionStorage.setItem('userData', resp.data);
          this.User_.next(JSON.parse(resp.data));
          this.goToRoute(toRoute);
          successCallback();
        },
        (error: HttpErrorResponse) => {
          console.log(error);
          errorCallback(error);
        },
      );
  }

  public refreshToken() {
    console.log('refreshing Token...');
    return this.http.post<any>('/TOKEN',
      'refresh_token=' + sessionStorage.getItem('refreshToken') + '&grant_type=refresh_token',
      { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } })
      .pipe(
        map(tok => {
          sessionStorage.setItem('accessToken', tok.access_token);
          sessionStorage.setItem('refreshToken', tok.refresh_token);
          let now = new Date();
          let c = new Date(now.setSeconds(now.getSeconds() + tok.expires_in));
          sessionStorage.setItem('expireAt', JSON.stringify(c));
          console.log('token was refreshed');
          return true;
        }))
  }

  public isTokenExpired(): boolean {
    let ExpireDate: Date = new Date(JSON.parse(sessionStorage.getItem('expireAt')));
    let now = new Date(Date.now());
    return now > ExpireDate;
  }

  /**
   * Cierra la sesión actual
   */
  public signOut() {
    sessionStorage.clear();
    this.goToRoute('login');
  }

  /**
   * Indica si existe el Token de autenticación en el almacenanmiento de sesión.
   */
  public hasToken(): boolean {
    return (sessionStorage.getItem('accessToken') ? true : false);
  }

  /**
   * Direcciona la ruta actual a la ruta en el parametro
   * @param route Ruta de destino
   */
  public goToRoute(route: string = '', options: any = {}) {
    this.ngZone.run(() => {
      this.router.navigate([route], options);
    });
  }
}
