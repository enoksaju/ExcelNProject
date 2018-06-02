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
  rvt: string;
  items: Item[] = [
    new Item("Inicio", "Pagina de Inicio", "home", '/index'),
    new Item("Buscar", "Obtener una Orden de Trabajo", "search", '/search'),
    new Item("Progreso", "Ver progreso de la Orden de Trabajo", "timeline", '/progress')
  ];
  Menu: Menu = new Menu(this.items, "Principal");
  Menus: Menu[] = [this.Menu];

  constructor(public media: ObservableMedia, private http: Http, private Router: Router, private userService: UserService) { }

  ngOnInit(): void {
    this.rvt = (<any>document.getElementsByName("__RequestVerificationToken")[0]).value;
  }
}