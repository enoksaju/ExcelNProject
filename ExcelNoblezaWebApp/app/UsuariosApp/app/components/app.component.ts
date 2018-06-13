import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';
import { ObservableMedia } from "@angular/flex-layout";
import { Headers, Http, RequestOptions } from '@angular/http';
import { Menu, SubMenu, Item } from '../../../common/components/main'
import { UserService } from '../../../common/Services/user.service'


@Component({
  selector: 'my-app',
  templateUrl: './app.component.html'
})

export class AppComponent implements OnInit {
  private headers = new Headers({ 'Content-Type': 'application/json' });

  rvt: string;
  items: Item[] = [
    new Item("Usuarios", "Administrar usuarios registrados", "home", '/users/index'),
    new Item("Agregar Usuario", "Crear un nuevo usuario", "home", '/users/adduser')
  ];
  Menu: Menu = new Menu(this.items, "Principal");
  Menus: Menu[] = [this.Menu];

  constructor(public media: ObservableMedia, private http: Http, private Router: Router, private userService: UserService) { }

  ngOnInit(): void {
    this.rvt = (<any>document.getElementsByName("__RequestVerificationToken")[0]).value;
  }
}