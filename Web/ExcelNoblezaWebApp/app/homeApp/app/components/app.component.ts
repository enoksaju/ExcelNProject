import { Component, OnInit, Input } from '@angular/core';
import { ObservableMedia } from "@angular/flex-layout";
import { Headers, Http } from '@angular/http';
import { HttpHeaders } from '@angular/common/http';

import { Menu, SubMenu, Item } from '../../../common/components/menuitem.component'

import { UserService } from '../../../common/Services/user.service'

@Component({
  selector: 'my-app',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  isloged = false;
  loginPath = '/Account/Login';
  logoffPath = "javascript:document.getElementById('logoutForm').submit()";

  Items: Item[] = [
    new Item("Inicio", "Pagina de Inicio", "home", "/main"),
    new Item("Productos", "Nuestros Productos", "work", null, new SubMenu(
      [
        new Item("Peliculas", "Peliculas Impresas y Laminadas", null, "/productos/peliculas"),
        new Item("Bolsas y Pouches", "Bolsas y Pouches", null, "/productos/bolsas"),
        new Item("Polietileno", "Polietileno Termoencogible", null, "/productos/polietileno"),
        new Item("Etiquetas", "Etiquetas", null, "/productos/etiquetas"),
        new Item("Innovaciones", "Innovaciones", null, "/productos/innovaciones")
      ]
    )),
    new Item("Contacto", "Comunicate con nosotros", "phone", "/contacto"),
    // new Item("About", "Acerca de esta pagina", "help", "/about"),
  ];

  Menu: Menu = new Menu(this.Items);

  /**
   * /@description: Retorna el valor de RequestVerificationToken
   */
  token(): string {
    let tok: any = document.getElementsByName("__RequestVerificationToken")[0]
    return tok.value;
  }

  /**
   * /@description: Accion que se realiza al presionar el boton de inicio o cierre de sesión.
   */
  LogClick(): void {
    if (this.isloged) {
      let frm: any = document.getElementById('logoutForm');
      frm.submit();
    } else {
      window.location.replace('/Account/Login');
    }
  };

  constructor(
    public media: ObservableMedia,
    private http: Http,
    private userService: UserService
  ) { }

  ngOnInit(): void {
    this.userService.isLoged().then(r => this.isloged = r);
    this.userService.GetMenu().then(r => {
      r.forEach((v, i) => {
        this.Menu.Items.push(v)
      });
    });
  }
}
