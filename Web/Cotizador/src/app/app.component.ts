import { Component, OnInit, Renderer2 } from '@angular/core';
import { MatSidenav, MatDrawer } from '@angular/material';
import { ObservableMedia } from '@angular/flex-layout';
import { state, trigger, transition, animate, style, group, query } from '@angular/animations';
import { UsuariosService } from './usuarios.service';
import { RouterOutlet } from '@angular/router';

export const fadeAnimation = trigger('fadeAnimation', [
  // The '* => *' will trigger the animation to change between any two states
  transition('* => *', [
    // The query function has three params.
    // First is the event, so this will apply on entering or when the element is added to the DOM.
    // Second is a list of styles or animations to apply.
    // Third we add a config object with optional set to true, this is to signal
    // angular that the animation may not apply as it may or may not be in the DOM.
    query(':enter', [style({ opacity: 0 })], { optional: true }),
    query(
      ':leave',
      // here we apply a style and use the animate function to apply the style over 0.3 seconds
      [style({ opacity: 1 }), animate('0.2s ease-in-out', style({ opacity: 0 }))],
      { optional: true }
    ),
    query(':enter', [style({ opacity: 0 }), animate('0.2s ease-in-out', style({ opacity: 1 }))], {
      optional: true,
    }),
  ]),
]);

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  animations: [
    trigger('darkness', [
      transition('* => *', [
        style({
          opacity: 0.1,
        }),
        animate('800ms cubic-bezier(.92,.78,.75,.99)'),
      ]),
    ]),
    fadeAnimation,
  ],
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

  getState(outletRef: RouterOutlet) {
    return {
      value: outletRef.activatedRoute.snapshot.params.index,
    };
  }

  constructor(
    private media: ObservableMedia,
    private render: Renderer2,
    public usuariosService: UsuariosService
  ) {}

  ngOnInit() {
    this.darkTheme = localStorage.getItem('theme') === 'dark' ? true : false;
    if (!this.usuariosService.hasToken()) {
      this.usuariosService.goToRoute('../login');
    }
  }

  sideNavOpend() {
    return this.media.isActive('lt-md');
  }

  signOut() {
    this.usuariosService.signOut();
  }

  OpenSideNav(drawer: MatSidenav) {
    drawer.open();
  }
}
