import { Component, OnInit, Input } from '@angular/core';
import { ObservableMedia } from "@angular/flex-layout";
import { Headers, Http, RequestOptions} from '@angular/http';
import { FormControl, Validators, NgForm } from '@angular/forms';
import { MatSnackBar } from '@angular/material';


@Component({
  selector: 'my-app',
  templateUrl: './app.component.html',
  styles: [`
.full-with{
    width:100%;
}
.logo{
    width:80%;
    max-width: 400px;
}
`]
})
export class AppComponent implements OnInit {

  urlAction: string;
  rvt: string;
  hide = true;
  message: string;
  NombreField = new FormControl('', [Validators.required]);
  PassField = new FormControl('', [Validators.required]);

  constructor(public media: ObservableMedia, private http: Http, public snackBar: MatSnackBar) {

    let msg: any = document.getElementById("messageModel");
    msg.value && this.snackBar.openFromComponent(errorSnackComponent, { duration: 10000 });

  }

  ngOnInit(): void {
    let tok: any = document.getElementsByName("__RequestVerificationToken")[0]
    this.rvt = tok.value;
    this.urlAction = document.location.href;  
  }

  onSubmit(f: NgForm) {
    let frm: any = document.getElementById('frmLogin');
    frm.submit();
  }
}

@Component({
  selector: "error-snack",
  template: '<mat-icon style="color: orange">warning</mat-icon> <span class="error mat-typography">   Error al iniciar sesión</span>',
  styles:['.error { color:red}']
})
export class errorSnackComponent { }