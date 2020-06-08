import { Component, Inject } from '@angular/core';
import { MediaMatcher, BreakpointObserver } from '@angular/cdk/layout';
import { IdentityService } from './Services/identity.service';
import { element } from 'protractor';
import { DOCUMENT } from '@angular/common';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  title = 'Angular';
  mobileQuery: MediaQueryList;
  dark: boolean;


  constructor(@Inject(DOCUMENT) private document: Document,
    private media: MediaMatcher,
    private breakpoint: BreakpointObserver,
    public identityService: IdentityService) {

    // Leo el tema desde el almacenamiento local
    this.dark = localStorage.getItem('isDark') === 'false' ? false : true;
    this.refreshBodyDark()

    // Configuro el manejador del evento change del mediaQuery 'print'
    this.mobileQuery = media.matchMedia('print');
    this.mobileQuery.addEventListener('change', () => {
      this.refreshBodyDark();
    });


  }

  // Refresco el tema si ha cambiado el mediaQuery o el estado del boton Dark
  refreshBodyDark() {
    if (this.dark && !this.breakpoint.isMatched('print')) this.document.body.classList.add('dark');
    else this.document.body.classList.remove('dark');
  }
  // Almaceno el nuevo valor del tema al activar el cambio del boton Dark
  toggleChange() {
    localStorage.setItem('isDark', String(this.dark));
    this.refreshBodyDark();
  }

  // Al iniciar verifico si el Token existe, si no existe redireccino al componente login
  ngOnInit(): void {
    if (!this.identityService.hasToken()) {
      this.identityService.goToRoute('login');
    }
  }

  // Elimino los listener
  ngDestroy(): void {
    this.mobileQuery.removeEventListener('change', () => { });
  }
}
