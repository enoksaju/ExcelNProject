import { Component, OnInit, Input } from '@angular/core';
import { ObservableMedia } from "@angular/flex-layout";
import { Headers, Http } from '@angular/http';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

import { UserService, AppItem } from '../../../common/Services/user.service'

@Component({
  selector: 'home-aplicaciones',
  templateUrl: './aplicaciones.component.html',
  styleUrls: ['./aplicaciones.component.css']
})
export class AplicacionesComponent implements OnInit {

  Apps: AppItem[] = new Array <AppItem>();

  constructor(
    public media: ObservableMedia,
    private http: Http,
    private router: Router,
    private userService: UserService
  ) { }

  ngOnInit(): void {
    // Retorna al inicio si no se ha iniciado sesion
    this.userService.isLoged().then(
      y => {
        if (!y) this.router.navigate(["/main"]);
      }
    ).catch(() => this.router.navigate(["/main"]))

    this.userService.GetApps()
      .then(t => {
        t.forEach(v => this.Apps.push(v));
      })
      .catch()
  }

  toLink(e:string): void {
    console.log(e)
  }

}
