import { Component, OnInit, Input, ViewChild, Inject } from '@angular/core';
import { ObservableMedia } from "@angular/flex-layout";
import { Router } from '@angular/router';
import { TrabajadorService, Estatus, DataReport, ResultReport } from '../../../common/Services/trabajador.service'
import { Http } from "@angular/http";
import { DataSource } from '@angular/cdk/collections';

import { MatPaginator, MatSort, MatTable, MatDialog, MatDialogRef, MAT_DIALOG_DATA, MatSnackBar, MAT_SNACK_BAR_DATA } from '@angular/material';
import { UsuariosService, UsuarioServiceClass, UsuarioReturnModel, roleAction, AccionesRoles } from '../services/Usuario.service'

import { Observable } from 'rxjs/Observable';
import { DialogsService } from '../../../common/Services/dialog.service';



@Component({
  selector: 'index-page',
  templateUrl: './index.component.html',
  styles: [`.example-table { overflow: auto; min-height: 300px;}.mat-row, .mat-header-row {min-width: 800px;}.example-loading-shade {position: absolute; top: 0; left: 0; bottom: 0px; right: 0; background: rgba(0, 0, 0, 0.15); z-index: 1; display: flex; align-items: center; justify-content: center;}.example-rate-limit-reached { color: #980000; max-width: 360px; text-align: center;}`]
})

export class IndexComponent implements OnInit {
  displayedColumns = ['Buttons','Usuario', 'Nombre', 'Email', 'Roles'];
  dataSource: UsuarioDataSource | null;
  usuarioServiceClass: UsuarioServiceClass | null;
  

  @ViewChild(MatTable) table: MatTable<UsuarioDataSource>;
  @ViewChild(MatSort) sort: MatSort;

  constructor(private usuariosService: UsuariosService, private router: Router, private dialog: MatDialog, private dlg: DialogsService) { }

  ngOnInit(): void {
    this.usuarioServiceClass = new UsuarioServiceClass();
    this.dataSource = new UsuarioDataSource(this.usuariosService, this.sort, this.usuarioServiceClass)
  }

  canDelete(row: UsuarioReturnModel): boolean {
   return row.Roles.indexOf('Develop') === -1 && row.Roles.indexOf('Admin') === -1
  }

  EditRole(row: UsuarioReturnModel): void {
    let action: roleAction = roleAction.defaultValue(row.UserId),
    dialogRef = this.dialog.open(RoleUpdateDialog, {
      width: '250px',
      data: action
    });

    dialogRef.afterClosed().subscribe(result => {
      result && (<string>result.Role).trim() != "Admin" && this.usuariosService.updateRoles(result)
        .then(r => {
          this.dlg.snackSuccess(r);
          this.usuarioServiceClass.Refresh();
        }, e => {
          this.dlg.snackError(JSON.parse(e).Message || JSON.parse(e));
        }
        );
    });
  }

  deleteUser(row: UsuarioReturnModel): void{

    this.dlg.confirm("Confirme", "Realmente desea borrar al usuario " + row.FullName, "Si,  Borrar", "No, Cancelar").subscribe(response => {
      if (response) {
        this.usuariosService.DeleteUser(row.UserId).then(
          t => {
            this.usuarioServiceClass.Refresh();
            console.log(t);
          });
      }
    },
      () => { }
    )
  }

  Back(): void {
    window.location.href='/';
  }

  AddUser(): void {
    
  }

};


class UsuarioDataSource extends DataSource<UsuarioReturnModel>{
  resultLength: number = 0;
  isLoadingResults = false;
  isRateLimitReached = false;

  constructor(private usuarioService: UsuariosService, private sort: MatSort, private usuarioServiceClass: UsuarioServiceClass) {
    super();
  }

  connect(): Observable<UsuarioReturnModel[]> {

    const displayDataChanges = [
      this.sort.sortChange,
      this.usuarioServiceClass.eRefresh
    ];

    return Observable.merge(...displayDataChanges)
      .startWith(null)
      .switchMap(() => {
        this.isLoadingResults = true;
        return this.usuarioService.getTrabajadores(this.usuarioServiceClass);
      })
      .map(data => {
        this.isLoadingResults = false;
        this.isRateLimitReached = false;
        this.resultLength = data.length;
        return data; /// Resultados
      })
      .catch((e) => {
        console.error(e);
        this.isLoadingResults = false;
        this.isRateLimitReached = true;
        return Observable.of([]);
      })

    // return null;
  };
  disconnect() { };
}

@Component({
  selector: 'role-update-dialog',
  template: `
<h1 mat-dialog-title>Editar Roles</h1>
<div mat-dialog-content>
        <div>
          <mat-form-field fxFlex="100">
            <input matInput placeholder="Rol" tabindex="3" [(ngModel)]="data.Role" />
          </mat-form-field>
        </div>
        <div>
          <mat-form-field fxFlex="100">
            <mat-select placeholder="Accion" tabindex="4" [(ngModel)]="data.Action" >
              <mat-option *ngFor="let key of acciones" [value]="key.value">{{key.label}}</mat-option>
            </mat-select>
          </mat-form-field>
        </div>
</div>
<div mat-dialog-actions>
  <button mat-button [mat-dialog-close]="data" tabindex="2">Continuar</button>
  <button mat-button (click)="onNoClick()" tabindex="-1">Cancelar</button>
</div>
`,
})export class RoleUpdateDialog implements OnInit {
  acciones: any[] = [];
  constructor(public dialogRef: MatDialogRef<RoleUpdateDialog>, @Inject(MAT_DIALOG_DATA) public data: roleAction) { }

  onNoClick(): void {
    this.dialogRef.close();
  }

  ngOnInit(): void {
    let d = AccionesRoles;
    this.acciones = Auxiliares.getEnumValues(d);
  }
}


class AddUsuarioModel {
  Email: string;
  UserName: string;
  Nombre: string;
  ApellidoPaterno: string;
  ApellidoMaterno: string;
  Password: string;
  ConfirmPassword: string;
}


class Auxiliares {
  static getEnumValues(_enum: any): any[] {
    //return Object.keys(_enum).filter(k => !isNaN(Number(k)));
    var r: any[] = [];
    var obj = Object.keys(_enum);
    var values = obj.filter(u => isNaN(Number(u)));
    obj.filter(u => !isNaN(Number(u)))
      .forEach((v, i) => {
        r.push({ value: Number(v), label: values[i] });
      });
    return r;
  }
}
