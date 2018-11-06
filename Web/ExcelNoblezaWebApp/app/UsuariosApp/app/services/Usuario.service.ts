import { Injectable, Output, EventEmitter } from '@angular/core';
import { Headers, Http, ResponseContentType } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { DomSanitizer } from '@angular/platform-browser';
import { SafeResourceUrl } from "@angular/platform-browser";
import { FormGroup } from '@angular/forms';

export class UsuarioServiceClass {
  @Output() eRefresh: EventEmitter<any> = new EventEmitter();
  Refresh(): void {
    this.eRefresh.emit(null);
  }
}

export enum AccionesRoles {
  Agregar=1, Eliminar
}

export class roleAction {
  UserId: string;
  Role: string;
  Action: AccionesRoles;

  static defaultValue(id:string): roleAction {
    let r = new roleAction;
    r.Action = AccionesRoles.Agregar;
    r.Role = '';
    r.UserId = id;
    return r;
  }

}

export class UsuarioReturnModel {
  UserName: string;
  Email: string;
  UserId: string;
  FullName: string;
  Roles: string[];

  static fromData(UserName: string, UserId: string, Email: string, FullName: string, Roles: string[]) {
    let ret: UsuarioReturnModel = new UsuarioReturnModel();
    ret.UserName = UserName;
    ret.UserId = UserId;
    ret.Email = Email;
    ret.FullName = FullName;
    ret.Roles = Roles;
    return ret;
  }
  constructor() { };
}

export class UsuarioCreateModel {
  UserName: string;
  Email: string;
  Nombre: string;
  ApellidoPaterno: string;
  ApellidoMaterno: string;
  Password: string;
  ConfirmPassword: string;

  static fromForm(form: FormGroup): UsuarioCreateModel {
    var ret = new UsuarioCreateModel();

    ret.UserName = form.value.UserName || null;
    ret.Email = form.value.Email || null;
    ret.Nombre = form.value.Nombre || null;
    ret.ApellidoPaterno = form.value.ApellidoPaterno || null;
    ret.ApellidoMaterno = form.value.ApellidoMaterno || null;
    ret.Password = form.value.Password || null;
    ret.ConfirmPassword = form.value.ConfirmPassword || null;

    return ret;
  }
}

@Injectable() export class UsuariosService {
  private headers = new Headers({ 'Content-Type': 'application/json' });

  private handleError(error: any): Promise<any> {
    return Promise.reject(error._body || error);
  }

  getTrabajadores(usuarioService: UsuarioServiceClass): Observable<UsuarioReturnModel[]> {
    return this.http.get('../../../../../../../../../api/Usuarios/getAll')
      .map(response => response.json() as UsuarioReturnModel[])
  }

  updateRoles(data: roleAction): Promise<any> {
    return this.http.post('../../../../../../../../../api/Usuarios/roles', data, { headers: this.headers })
      .toPromise()
      .then(res => res.json() as any)
      .catch(this.handleError)
  }

  DeleteUser(id:string): Promise<any> {
    return this.http.delete('../../../../../../../../../api/Account/user?Id=' + id)
      .toPromise().then(res => res.json() as any)
      .catch(this.handleError)
  }

  AddUser(data: UsuarioCreateModel) {
    return this.http.post('../../../../../../../../../api/Account/user', data, { headers: this.headers })
      .toPromise().then(res => res.json() as any)
      .catch(this.handleError)
  }

  constructor(private http: Http) { }

}