import { Component, OnInit, Renderer2, OnDestroy } from '@angular/core';
import { MatSidenav, MatDrawer } from '@angular/material';
import { ObservableMedia } from '@angular/flex-layout';
import {
  state,
  trigger,
  transition,
  animate,
  style,
  group,
  query
} from '@angular/animations';
import { UsuariosService, BasicInfoUser } from './usuarios.service';
import {
  RouterOutlet,
  ActivatedRoute,
  Route,
  Router,
  NavigationEnd
} from '@angular/router';
import { Subscription, Observable } from 'rxjs';
import { delay, filter } from 'rxjs/operators';

export const fadeAnimation = trigger('fadeAnimation', [
  transition('* => *', [
    query(':enter', [style({ opacity: 0 })], { optional: true }),
    query(
      ':leave',
      [
        style({ opacity: 1 }),
        animate('0.2s ease-in-out', style({ opacity: 0 }))
      ],
      { optional: true }
    ),
    query(
      ':enter',
      [
        style({ opacity: 0 }),
        animate('0.2s ease-in-out', style({ opacity: 1 }))
      ],
      {
        optional: true
      }
    )
  ])
]);

const PRINT = 'print';

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
    ]),
    fadeAnimation
  ]
})
export class AppComponent implements OnInit, OnDestroy {
  _darkTheme: boolean;
  isAdmin: Observable<boolean>;
  subIAdmin$: Subscription;
  private previusDark: boolean;
  prevRoute: string;
  user: BasicInfoUser;

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
    return this.media.isActive(PRINT) ? false : this._darkTheme;
  }

  getState(outletRef: RouterOutlet) {
    return {
      value: outletRef.activatedRoute.snapshot.params.index
    };
  }

  constructor(
    private media: ObservableMedia,
    private render: Renderer2,
    public usuariosService: UsuariosService,
    public route: Router
  ) {
    this.isAdmin = this.usuariosService.isAdmin();
    this.route.events
      .pipe(filter(e => e instanceof NavigationEnd))
      .subscribe((u: NavigationEnd) => {
        const parts = u.url.split('/');
        let r: string = '';
        for (let i = 0; i < parts.length - 1; i++) {
          r += parts[i] === '' ? '' : '/' + parts[i];
        }
        this.prevRoute = r === '' ? '/' : r;
      });
  }

  ngOnInit() {
    this.darkTheme = localStorage.getItem('theme') === 'dark' ? true : false;

    if (!this.usuariosService.hasToken()) {
      this.usuariosService.goToRoute('../login');
    }

    this.media.asObservable().subscribe(u => {
      if (this.media.isActive(PRINT)) {
        this.render.addClass(document.body, 'lt');
        setTimeout(
          () =>
            (this.darkTheme =
              localStorage.getItem('theme') === 'dark' ? true : false),
          1
        );
      }
    });

    this.usuariosService.getUserInfo().subscribe(
      u => (this.user = u),
      () =>
        (this.user = {
          Nombre: 'Desconocido',
          Email: '--',
          EmailConfirmaed: false,
          Roles: [],
          Id: '0'
        })
    );
  }

  ngOnDestroy() {
    // this.subIAdmin$.unsubscribe();
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
