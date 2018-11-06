import { Component, OnInit, Input } from '@angular/core';
import { ObservableMedia } from "@angular/flex-layout";
import { Router } from '@angular/router';
import { UserService } from '../../../common/Services/user.service'

@Component({
  selector: 'administrar-page',
  template: '<router-outlet></router-outlet>',
  styles: []
})
export class AdministrarComponent implements OnInit {
  constructor(private router: Router, private userService: UserService) { };
  ngOnInit(): void {

    this.userService.isAdminNominas().then(y => !y && this.router.navigate(["/index"])).catch(() => this.router.navigate(["/index"]))

  };
}