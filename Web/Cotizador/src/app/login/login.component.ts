import { Component, OnInit, OnDestroy } from "@angular/core";
import { UserLogin, UsuariosService } from "../usuarios.service";
import { Router, ActivatedRoute } from "../../../node_modules/@angular/router";

@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.scss"]
})
export class LoginComponent implements OnInit, OnDestroy {
  loading: boolean = false;
  toRoute: string;
  userLogin: UserLogin = { username: "", password: "", grant_type: "password" };
  sub: any;

  constructor(
    private usuariosService: UsuariosService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.sub = this.route.queryParams.subscribe(v => {
      this.toRoute = v.toRoute;
    });
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }

  login() {
    const promiseLogin = this.usuariosService.login(
      this.userLogin,
      this.toRoute
    );
  }
}
