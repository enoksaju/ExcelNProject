import { Component, OnInit } from '@angular/core';
import { CordovaService } from './cordova.service';

/**
 * Item de un Menu
 */
export class MenuItem {
  icono: string;
  texto: string;
  link: string;

  /**
   * Constructor del item de menu.
   * @param texto Texto que se mostrara en el menu.
   * @param icono Icono que se mostrara en el menu.
   */
  constructor(texto: string, options?: { link?: string; icono?: string }) {
    const defaults: { link: string; icono: string } = {
      link: null,
      icono: null
    };
    const _options = Object.assign(defaults, options);
    this.texto = texto;
    this.icono = _options.icono.toLowerCase();
    this.link = _options.link;
  }
}

@Component({
  selector: 'calc-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  menu: MenuItem[] = [
    new MenuItem('Inicio', { icono: 'home', link: 'inicio' }),
    new MenuItem('Metros Lineales', { icono: 'power_input', link: 'metros' }),
    new MenuItem('Alto de Rollo', { icono: 'toll', link: 'alto' }),
    new MenuItem('Piezas y Largo de Rollo', { icono: 'filter_9_plus', link: 'piezaslargo' }),
    new MenuItem('Diferencia de Color', { icono: 'invert_colors', link: 'diferenciacolor' }),
    new MenuItem('Catalogo Pantone', { icono: 'palette', link: 'pantone' })
  ];

  constructor(private cordovaService: CordovaService) {
    console.log(this.cordovaService.cordova);
  }
  ngOnInit(): void {}
}
