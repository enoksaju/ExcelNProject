import { Component, OnInit } from '@angular/core';
import { UserLogin, IdentityService } from '../Services/identity.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-login',
  template: `
<div fxLayout="column" fxFlex="100%" fxFlexFill fxLayoutAlign="center center">
  <mat-card fxLayout="column" class="mat-elevation-z20">
    <img mat-card-image fxFlex="100%" src="assets/logocol.svg">
    <mat-card-header>
      <mat-card-title>Bienvenido</mat-card-title>
      <mat-card-subtitle>Para continuar, por favor inicie sesión</mat-card-subtitle>
    </mat-card-header>
    <mat-card-content fxLayout="column">
      <mat-form-field color="accent">
        <mat-label>Correo Electronico</mat-label>
        <input matInput [(ngModel)]="userLogin.username">
        <mat-icon matSuffix svgIcon="account"></mat-icon>
      </mat-form-field>
      <br />
      <mat-form-field color="accent">
        <input type="password" [(ngModel)]="userLogin.password" matInput placeholder="Contraseña">
        <mat-icon matSuffix svgIcon="key"></mat-icon>
      </mat-form-field>
    </mat-card-content>
    <mat-card-actions fxLayoutAlign="space-around center">
      <button mat-raised-button color="primary" (click)="login()">
        <mat-icon svgIcon="login"></mat-icon>
        Entrar
      </button>
    </mat-card-actions>
  </mat-card>
</div>`
})
export class LoginComponent implements OnInit {
  loading: boolean = false;
  userLogin: UserLogin = { username: '', password: '', grant_type: 'password' };
  toRoute: string;
  sub: any;

  constructor(private identityService: IdentityService,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.sub = this.route.queryParams.subscribe(v => {
      this.toRoute = v.toRoute;
      console.log(v.toRoute);
    });
  }

  login() {
    this.loading = true;
    const promiseLogin = this.identityService.login(
      this.userLogin,
      this.toRoute,
      () => {
        this.loading = false;
      },
      e => {
        this.loading = false;
      }
    );
  }
}
