import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';
import { Item, Menu } from '../components/menuitem.component'
import 'rxjs/add/operator/toPromise';

export class AppItem {
  Label: string;
  Icon: string;
  Link: string
  Color: string;
  Description: string;
  fail: boolean = false;
  constructor(Label: string, Icon: string, Link: string, Color: string = null, Description: string = null, fa: boolean= false) {
    this.Label = Label;
    this.Icon = Icon.toLowerCase();
    this.Color = Color;
    this.Link = Link;
  }
}

@Injectable() export class UserService {
  private headers = new Headers({ 'Content-Type': 'application/json' }); 

  constructor(private http: Http) { }

  isLoged(): Promise<boolean> {
    return this.http.get("../../../../../../../../api/home/isloged")
      .toPromise().then(response => response.json() as boolean)
      .catch(this.handleError);
  };

  isAdminNominas(): Promise<boolean> {
    return this.http.get("../../../../../../../../api/apiPermisos/isAdmin")
      .toPromise().then(response => response.json() as boolean)
      .catch(this.handleError);
  }

  GetMenu(): Promise<Item[]> {
    return this.http.get("../../../../../../../../api/home/getmenu")
      .toPromise()
      .then(r => r.json() as Item[])
      .catch(this.handleError);
  }

  GetMenuPermisos(): Promise<Menu[]> {
    return this.http.get('../../../../../../../../../../api/apiPermisos/getMenu')
      .toPromise()
      .then(r => r.json() as Menu[])
      .catch(this.handleError)
  }

  GetApps(): Promise<AppItem[]> {
    return this.http.get('../../../../../../../../api/home/getApps')
      .toPromise()
      .then(t => t.json() as AppItem[])
      .catch(this.handleError);
  }

  private handleError(error: any): Promise<any> {
    console.error('An error occurred', error);
    return Promise.reject(error.message || error);
  }

}
