import { Component, OnInit, Input , Inject} from '@angular/core';
import { ObservableMedia } from "@angular/flex-layout";
import { Headers, Http, RequestOptions } from '@angular/http';
import { DomSanitizer } from '@angular/platform-browser';
import { SafeResourceUrl } from "@angular/platform-browser";
import { FormControl, Validators } from '@angular/forms';

import { MatSnackBar, MAT_SNACK_BAR_DATA } from '@angular/material'

//Services

import { OTService, infoOT, GetOTModel, Procesos, TIPOS, TIPOSIMPRESION } from '../services/ot.service';


@Component({
  templateUrl: './search.component.html',
  styles: ['.pad{padding:10px; margin:10px;}.marg-25{margin-right:25px!important}']
}) export class SearchComponent implements OnInit {
  OT = new FormControl(localStorage.getItem("OT") ? localStorage.getItem("OT") : '', [Validators.required]);
  getOTModel: GetOTModel = new GetOTModel();
  model: infoOT = new infoOT();
  Instrucciones: any[] = [];
  secondstate: boolean = false;
  isSearching: boolean = false;

  constructor(public media: ObservableMedia, private http: Http, private _sanitizer: DomSanitizer, private otService: OTService, private snackBar: MatSnackBar) { }
  ngOnInit(): void { }

  buscarOT(folio: string): void {
    this.isSearching = true;
    this.getOTModel.OrderNumber = folio;
    this.otService.verOt(this.getOTModel).then((t) => {
      this.secondstate = true;
      this.model = t;
      this.Instrucciones = [];
      Object.keys(this.model).forEach((k, i) => {
        let t = new RegExp("^INST?([A-Z])*", "g"),
          pushInst = (name: string, value: string) => {
            value.trim().length > 0 && this.Instrucciones.push({
              nombre: name.charAt(4).toUpperCase() + name.substring(5).toLowerCase(),
              value: value
            });
          };
        t.test(k) && pushInst(k, this.model[k]);
      }); 
      this.isSearching = false;
    }, r => {
      this.snackBar.openFromComponent(ErrorSnackComponent, { duration: 5000, data: r });
      this.isSearching = false;
    });
  }
}

@Component({
  selector: 'snakbar-error',
  template: `
<section class="mat-typography">
  <mat-icon color="warn">warning</mat-icon>
  <span class="">
    {{data.Message}}
  </span>
</section>

`,
  styles: [``]
}) export class ErrorSnackComponent {
  constructor( @Inject(MAT_SNACK_BAR_DATA) public data: any) { }
}