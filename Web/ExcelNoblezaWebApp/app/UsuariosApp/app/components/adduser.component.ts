import { Component, OnInit } from '@angular/core';
import { UsuariosService, UsuarioCreateModel } from '../services/Usuario.service'
import { FormControl, Validators, FormGroup } from '@angular/forms';
import { DialogsService } from '../../../common/Services/dialog.service';
import { Router } from '@angular/router';

@Component({
  selector: "add-user-page",
  templateUrl: './adduser.component.html'
}) export class AddUserComponent implements OnInit {
  user: UsuarioCreateModel;
  errors: Array<string> = [];
  Form: FormGroup = new FormGroup(
    {
      UserName: new FormControl(null, [Validators.required]),
      Email: new FormControl(null, [Validators.required, Validators.email]),
      Nombre: new FormControl(null, [Validators.required]),
      ApellidoPaterno: new FormControl(null, [Validators.required]),
      ApellidoMaterno: new FormControl(null, [Validators.required]),
      Password: new FormControl(null, [Validators.required]),
      ConfirmPassword: new FormControl(null, [Validators.required])
    }
  );


  constructor(private usuasioService: UsuariosService, private dlg: DialogsService, private router: Router) { }

  ngOnInit(): void {
    this.user = new UsuarioCreateModel();
  }

  onSubmit(): void {
    this.Form.valid && this.usuasioService.AddUser(UsuarioCreateModel.fromForm(this.Form))
      .then(t => {
        this.dlg.snackSuccess(t,1000).subscribe(() => { this.router.navigateByUrl('/users/index') });
      }, e => {
        this.errors = [];
        let res = JSON.parse(e);
        res.ModelState && (() => {
          for (let v in res.ModelState) { (<Array<string>>res.ModelState[v]).forEach(v => this.errors.push(v)); }
        })();
      });
    this.Form.invalid && this.dlg.snackError('Datos Incorrectos') && console.log('Formulario Invalido')
  }
}