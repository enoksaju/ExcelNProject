import { Injectable, NgZone } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Router } from '@angular/router';

export enum Actions { Add, Remove }

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
  providedIn: 'root'
})
export class UsuariosService {
  public UserRoles: string[] = [];
  constructor(private http: HttpClient, private router: Router, private ngZone: NgZone) {
    this.Initialice();
  }

  public Initialice() {
    this.Roles()
      .then(val => this.UserRoles = val)
      .catch(err => console.log(err.error.Message));
  }

  public Roles(UsuarioId: number = null) {
    return this.http.post<string[]>('api/Account/UserRoles', UsuarioId).toPromise();
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
  public login(userLogin: UserLogin, toRoute: string = '') {
    this.http.post('/TOKEN',
      'username=' + userLogin.username + '&password=' + userLogin.password + '&grant_type=password',
      { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } })
      .subscribe(
        (resp: any) => {
          sessionStorage.setItem('userName', resp.userName);
          sessionStorage.setItem('accessToken', resp.access_token);
          sessionStorage.setItem('refreshToken', resp.refresh_token);
          this.Initialice();
          this.goToRoute(toRoute);
        }, error => {
          console.log(error);
        },
    );
  }

  public CurrentIsInRol(role: string): boolean {
    const roles = role.split(',');
    let ret: boolean;

    for (const v of roles) {
      ret = this.UserRoles.includes(v.replace(' ', ''));
      if (ret) {
        break;
      }
    }

    return ret;
  }

  public ManageRoles(data: AddRemoveUserRoleModel) {
    return this.http.post('/api/Account/ManageRoles', data)
      .toPromise();
  }

  /**
  * Cierra la sesión actual
  */
  public signOut() {
    sessionStorage.removeItem('accessToken');
    sessionStorage.removeItem('refreshToken');
    sessionStorage.removeItem('userName');
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
  public goToRoute(route: string = 'main') {
    this.ngZone.run(() => {
      this.router.navigate([route]);
    });
  }
}
