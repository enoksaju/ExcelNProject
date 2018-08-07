import { Component, OnInit, Renderer2 } from '@angular/core';
import { MatSidenav, MatDrawer } from '@angular/material';
import { ObservableMedia } from '@angular/flex-layout';
import { state, trigger, transition, animate, style } from '@angular/animations';
import { UsuariosService } from './usuarios.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  animations: [
    trigger('darkness', [
      transition('* => *', [
        style({
          opacity: 0.1
        }),
        animate('800ms cubic-bezier(.92,.78,.75,.99)')
      ])
    ])
  ]
})
export class AppComponent implements OnInit {
  _darkTheme: boolean;

  // Declaracion de la propiedad darkTheme
  set darkTheme(val: boolean) {
    this._darkTheme = val;
    localStorage.setItem('theme', val ? 'dark' : 'light');
    if (val) {
      this.render.removeClass(document.body, 'lt');
    } else {
      this.render.addClass(document.body, 'lt');
    }
  }
  get darkTheme() {
    return this._darkTheme;
  }

  constructor(private media: ObservableMedia, private render: Renderer2, public usuariosService: UsuariosService) { }

  ngOnInit() {
    this.darkTheme = localStorage.getItem('theme') === 'dark' ? true : false;
    if (!this.usuariosService.hasToken()) { this.usuariosService.goToRoute('../login'); }
  }

  sideNavOpend() {
    return this.media.isActive('lt-md');
  }

  signOut() {
    this.usuariosService.signOut();
  }

  OpenSideNav(drawer: MatDrawer) {
    drawer.open();
  }
}
