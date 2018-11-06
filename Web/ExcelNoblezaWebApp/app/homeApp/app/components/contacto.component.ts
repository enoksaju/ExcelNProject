import { Component, OnInit, Input } from '@angular/core';
import { FormControl, Validators, FormGroup } from '@angular/forms';
import { ObservableMedia } from "@angular/flex-layout";
import { MatSnackBar } from '@angular/material';

@Component({
  selector: 'home-contact',
  templateUrl: './contacto.component.html',
  styleUrls:['./contacto.component.css']
})
export class ContactoComponent implements OnInit {

  contactForm= new FormGroup ({
    name: new FormControl('', [Validators.required]),
    email: new FormControl('', [Validators.email, Validators.required]),
    phone: new FormControl(),
    title: new FormControl(),
    message: new FormControl('', [Validators.required, Validators.minLength(50), Validators.maxLength(300)])
  });

  constructor(public media: ObservableMedia, public snackBar: MatSnackBar) { }
  ngOnInit(): void {

  }

  private onSubmit(f:any): void {
    console.log(f);
    this.snackBar.open("Se envio la informacion correctamente. Gracias por Contactarnos.");
  }
}