import { DialogIcons } from './../dialog.component';
import { DialogService } from './../dialog.service';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { UserLogin, UsuariosService } from '../usuarios.service';
import { Router, ActivatedRoute } from '../../../node_modules/@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit, OnDestroy {
  loading: boolean = false;
  toRoute: string;
  userLogin: UserLogin = { username: '', password: '', grant_type: 'password' };
  sub: any;

  constructor(
    private usuariosService: UsuariosService,
    private router: Router,
    private route: ActivatedRoute,
    private dialogService: DialogService
  ) { }

  ngOnInit() {
    this.sub = this.route.queryParams.subscribe(v => {
      this.toRoute = v.toRoute;
    });
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }

  login() {
    this.loading = true;
    const promiseLogin = this.usuariosService.login(
      this.userLogin,
      this.toRoute,
      () => {
        this.loading = false;
      },
      e => {
        this.dialogService.showDialog('Error...', e.error.error_description, {
          Icon: DialogIcons.Error
        });
        this.loading = false;
      }
    );
  }
}
