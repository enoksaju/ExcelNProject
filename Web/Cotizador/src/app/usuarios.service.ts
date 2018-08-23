import { Injectable, NgZone } from '@angular/core';
import { HttpClient, HttpParams, HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';
import { Observable, observable } from '../../node_modules/rxjs';
import { map } from 'rxjs/operators';
import { async } from '../../node_modules/@types/q';

export enum Actions {
  Add,
  Remove,
}

/**
 * Clase  que contiene los datos de inicio de sesión
 */
export class UserLogin {
  grant_type: 'password';
  username: string;
  password: string;
}

export interface UserInfo {
  Email: string;
  Password: string;
  ConfirmPassword: string;
  Nombre: string;
  ApellidoPaterno: string;
  ApellidoMaterno: string;
  Clave: number;
}

export interface BasicInfoUser {
  Nombre: string;
  Email: string;
  EmailConfirmaed: boolean;
  Id: string;
  Roles: string[];
}

export interface AddRemoveUserRoleModel {
  Role: string;
  Action: Actions;
  UserId: string;
}

@Injectable({
  providedIn: 'root',
})
export class UsuariosService {
  public myRoles: string[];

  // public UserRoles: string[] = [];
  constructor(private http: HttpClient, private router: Router, private ngZone: NgZone) {
    this.Initialice();
  }

  public Initialice() {
    this.getUserRoles().subscribe(r => (this.myRoles = r));
  }

  public getUserRoles(UsuarioId: number = null) {
    return this.http.post<string[]>('api/Account/UserRoles', UsuarioId);
  }
  /**
   * Registra un usuario nuevo en la App
   */
  public registrar(userInfo: UserInfo) {
    return this.http.post('/api/Account/Register', userInfo);
  }

  /**
   * Regresa la lista de usuarios disponibles
   */
  public GetUsers() {
    return this.http.get<BasicInfoUser[]>('/api/Account/users');
  }

  /**
   * Genera el Token de credenciales
   * @param userLogin Credenciales de incio de sesión
   */
  public login(
    userLogin: UserLogin,
    toRoute: string = '',
    successCallback: Function = () => {},
    errorCallback: (error: HttpErrorResponse) => void
  ) {
    this.http
      .post(
        '/TOKEN',
        'username=' +
          userLogin.username +
          '&password=' +
          userLogin.password +
          '&grant_type=password',
        { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } }
      )
      .subscribe(
        (resp: any) => {
          sessionStorage.setItem('userName', resp.userName);
          sessionStorage.setItem('userId', resp.userId);
          sessionStorage.setItem('accessToken', resp.access_token);
          sessionStorage.setItem('refreshToken', resp.refresh_token);
          this.Initialice();
          this.goToRoute(toRoute);
          successCallback();
        },
        (error: HttpErrorResponse) => {
          console.log(error);
          errorCallback(error);
        }
      );
  }

  public getRolesAvailables(): Observable<string[]> {
    return this.http.get<string[]>('/api/Account/Roles');
  }

  public CurrentIsInRol(role: string): Observable<boolean> {
    return new Observable<boolean>(observer => {
      const roles = role.split(',');
      let ret: boolean = false;

      const resolve = function(myRoles_: string[]) {
        for (const v of roles) {
          if (myRoles_ != null && myRoles_.includes(v.replace('', ''))) {
            ret = true;
          }
        }
        observer.next(ret);
        observer.complete();
      };

      if (!this.myRoles) {
        this.getUserRoles()
          .toPromise()
          .then(rols => {
            this.myRoles = rols;
            resolve(this.myRoles);
          });
      } else {
        resolve(this.myRoles);
      }
    });
  }

  public ManageRoles(data: AddRemoveUserRoleModel) {
    return this.http.post('/api/Account/ManageRoles', data).toPromise();
  }

  /**
   * Cierra la sesión actual
   */
  public signOut() {
    sessionStorage.removeItem('accessToken');
    sessionStorage.removeItem('refreshToken');
    sessionStorage.removeItem('userName');
    sessionStorage.removeItem('userId');
  }

  public getUserId(): number {
    return +sessionStorage.getItem('userId');
  }

  /**
   * Indica si existe el Token de autenticación en el almacenanmiento de sesión.
   */
  public hasToken(): boolean {
    return sessionStorage.getItem('accessToken') ? true : false;
  }

  /**
   * Direcciona la ruta actual a la ruta en el parametro
   * @param route Ruta de destino
   */
  public goToRoute(route: string = '') {
    this.ngZone.run(() => {
      this.router.navigate([route]);
    });
  }
}
