import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IdentityService } from '../Services/identity.service';
import { MatSelectionListChange } from '@angular/material/list';
import { statusProcesoProduccion } from '../Services/planeacion-produccion.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {


  constructor(private httpClient: HttpClient, public identityService: IdentityService) { }

  valSubscriber: any;
  vals: string[];
  loading: boolean;

  ngOnInit(): void {
    this.loading = true;
    this.valSubscriber = this.httpClient.get<string[]>("api/values").subscribe(val => {
      this.vals = val;
      this.loading = false;
    })


  }
}
