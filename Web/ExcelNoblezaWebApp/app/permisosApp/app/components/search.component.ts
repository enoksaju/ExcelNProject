import { Component, OnInit, Input } from '@angular/core';
import { ObservableMedia } from "@angular/flex-layout";
import { Http, ResponseContentType } from "@angular/http";
import { TrabajadorService } from '../../../common/Services/trabajador.service';
import { DomSanitizer } from '@angular/platform-browser';
import { SafeResourceUrl } from "@angular/platform-browser";
import { FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'search-page',
  templateUrl: './search.component.html',
  styles: []
})
export class SearchComponent implements OnInit {
  Folio = new FormControl(localStorage.getItem("Folio") ? localStorage.getItem("Folio") : '', [Validators.required, Validators.minLength(11), Validators.maxLength(11)]);
  showPDF: boolean = false;
  safeResourceUrl: SafeResourceUrl;

  constructor(public media: ObservableMedia, private http: Http, private trabajadorService: TrabajadorService, private _sanitizer: DomSanitizer) { }
  ngOnInit(): void {
    if (!/Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent)) {
      this.buscarFolio(this.Folio.value);
    }
  }
  
  buscarFolio(_folio: string): void {
    localStorage.setItem("Folio", _folio);

    if (/Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent)) {
      this.trabajadorService.DescargarPDF(_folio);
    }
    else {
      this.trabajadorService.GetPermisoPDFUrl(_folio).subscribe(r => {
        this.safeResourceUrl = r;
        this.showPDF = true;
      });
    }
  };
}