import { Component, OnInit, HostBinding } from '@angular/core';
import { CatalogosService, CatalogoMenuItem } from '../catalogos.service';

@Component({
  selector: 'cat-catalogos.cc',
  templateUrl: './catalogos.component.html',
  styleUrls: ['./catalogos.component.scss']
})
export class CatalogosComponent implements OnInit {
  Items: CatalogoMenuItem[];
  constructor(public catalogService: CatalogosService) { }

  ngOnInit() {
    this.RefreshCounters();
  }

  async RefreshCounters() {
    this.Items = await this.catalogService.getStatus();
  }

}
