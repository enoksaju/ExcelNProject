import { Injectable, NgZone } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';
import { Observable, BehaviorSubject } from '../../node_modules/rxjs';

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

export interface User {
  Nombre: string;
  ApellidoPaterno: string;
  ApellidoMaterno: string;
  Estatus: any;
  Email: string;
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
  private data1 = new BehaviorSubject<boolean>(false);
  private User = new BehaviorSubject<BasicInfoUser>({
    Nombre: 'Desconocido',
    Email: '--',
    EmailConfirmaed: false,
    Roles: [],
    Id: '0',
  });

  public UserRoles: string[] = [];
  // public isAdmin_: Observable<boolean>;

  constructor(private http: HttpClient, private router: Router, private ngZone: NgZone) {
    this.refreshisAdmin();
  }

  private refreshisAdmin() {
    if (this.hasToken()) {
      this.getUserRoles()
        .toPromise()
        .then(r => {
          this.UserRoles = r;
          let ret: boolean = false;
          for (const v of ['Administrador', 'Sistemas', 'Develop']) {
            if (this.UserRoles != null && this.UserRoles.includes(v.replace('', ''))) {
              ret = true;
            }
          }
          this.data1.next(ret);
        });

      this.GetUsers()
        .toPromise()
        .then(u =>
          this.User.next(u.filter(p => p.Id.toString() === this.getUserId().toString())[0]),
        );
    }
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
          sessionStorage.setItem('userName', resp.userName);
          sessionStorage.setItem('userId', resp.userId);
          sessionStorage.setItem('userRoles', resp.userRoles);
          sessionStorage.setItem('accessToken', resp.access_token);
          sessionStorage.setItem('refreshToken', resp.refresh_token);
          this.refreshisAdmin();
          this.goToRoute(toRoute);
          successCallback();
        },
        (error: HttpErrorResponse) => {
          console.log(error);
          errorCallback(error);
        },
      );
  }

  public getRolesAvailables(): Observable<string[]> {
    return this.http.get<string[]>('/api/Account/Roles');
  }
  public getUserInfo() {
    return this.User.asObservable();
  }

  public getUserRoles() {
    return this.http.get<string[]>('/api/Account/UserRoles');
  }

  public isAdmin() {
    return this.data1.asObservable();
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
    sessionStorage.removeItem('myRoles');
    sessionStorage.removeItem('userRoles');
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
