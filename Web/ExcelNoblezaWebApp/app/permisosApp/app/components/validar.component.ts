import { Component, OnInit, Input, Output, ViewChild, EventEmitter } from '@angular/core';
import { ObservableMedia } from "@angular/flex-layout";
import { Http } from "@angular/http";
import { DataSource } from '@angular/cdk/collections';
import { MatPaginator, MatSort, MatTable } from '@angular/material';
import { Observable } from 'rxjs/Observable';
import { DialogsService } from '../../../common/Services/dialog.service';
import { PermisoDetailsService } from '../services/permisodetails.service'

import 'rxjs/add/observable/merge';
import 'rxjs/add/observable/of';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/startWith';
import 'rxjs/add/operator/switchMap';

@Component({
  selector: 'validar-page',
  templateUrl: './validar.component.html',
  styleUrls: ['./validar.component.css']
})

export class ValidarComponent implements OnInit {
  displayedColumns = ['chk', 'details', 'ValidacionId', 'Folio', 'TrabajadorId', 'TipoString', 'MotivoPermisoId', 'Inicio']
  Database: PermisosHttpDAO | null;
  dataSource: PermisosDataSource | null;
  Validacion: ValidacionClass | null;

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatTable) table: MatTable<PermisosDataSource>

  constructor(private http: Http, private dialogService: DialogsService, private permisoDetails: PermisoDetailsService) {
    this.Validacion = new ValidacionClass(this.http);
  };
  ngOnInit(): void {
    this.Database = new PermisosHttpDAO(this.http);
    this.dataSource = new PermisosDataSource(this.Database!, this.paginator, this.sort, this.Validacion);
  };

  validar(tipo: string): void {
    this.dialogService.confirm('Confirme', 'Realmente desea ' + tipo + ' los permisos seleccionados?', 'Si, ' + tipo)
      .subscribe(c => {
        c && this.Validacion.Afectar(AfectarTipo[tipo], this.foliosSeleccionados())
      })
  };

  foliosSeleccionados(): string[] {
    var t: any[] = this.table['_data'];
    var ret: string[] = [];
    t.filter((t: any) => t.selected).forEach(v => {
      ret.push(v.Id);
    });
    return ret;
  }

  markAll(a: any): void {
    var t: any[] = this.table['_data'];
    t.forEach(v => {
      v.selected = a.checked;
    })
    console.log(a.checked)
  }
  showDetails(p: any) {
    this.permisoDetails.showDetails(p)
      .subscribe(result => result.accion && this.Validacion.Afectar(result.accion, result.items));
  }
}

enum Validaciones {
  Todos = 0,
  Correctos = 1,
  FueraDeTiempo = 2,
  ParaFechaAnterior = 3
}

enum AfectarTipo {
  Aprobar,
  Denegar,
  Cancelar
}


/**
 * @description PROVEE ACCIONES Y CONTROLES PARA LA VALIDACION DE LOS PERMISOS
 */
class ValidacionClass {
  @Output() validacionChange: EventEmitter<any> = new EventEmitter();
  @Output() changeValues: EventEmitter<any> = new EventEmitter();

  private _validacion: Validaciones = Validaciones.Todos;

  set validacion(validacion: Validaciones) {
    this._validacion = validacion;
    this.validacionChange.emit(validacion)
  }
  get validacion(): Validaciones {
    return this._validacion;
  }
  validaciones: any[];

  Afectar(Tipo: AfectarTipo, Items: string[]): Promise<any> {
    return this.http.post('../../../../../../../../../../api/apiPermisos/afectar', { accion: Tipo, folios: Items })
      .toPromise()
      .then(response => {
        this.changeValues.emit(null);
        return true;
      })
      .catch(e => { return Promise.reject(e.message || e); });
  }

  constructor(private http: Http) {
    var v = Validaciones;
    this.validaciones = this.getEnumValues(v);
  }

  private getEnumValues(_enum: any): any[] {
    var r: any[] = [];
    var obj = Object.keys(_enum);
    var values = obj.filter(u => isNaN(Number(u)));
    obj.filter(u => !isNaN(Number(u)))
      .forEach((v, i) => {
        r.push({ value: Number(v), label: values[i].replace(/([A-Z])/g, ' $1').trim() });
      });
    return r;
  }

}

/**
 * @description CONEXION A LA BASE DE DATOS
 */
class PermisosHttpDAO {
  constructor(private http: Http) { }
  getReportPermisos(page: number, pageSize: number, order: string, sort: string, validacion: Validaciones) {
    const href = '../../../../../../../../../../api/apiPermisos/getPermisos/';
    const requestUrl = `${href}/${page + 1}/${pageSize}/${sort}/${order}/${validacion}`;
    return this.http.get(requestUrl).map(r => r.json() as any)
  }
}

/**
 * @description DATA SOURCE QUE DEVUELVE LOS PERMISOS A LA TABLA
 */
class PermisosDataSource extends DataSource<any>{

  resultLength: number = 0;
  isLoadingResults = false;
  isRateLimitReached = false;

  constructor(private permisosHttpDAO: PermisosHttpDAO, private paginator: MatPaginator, private sort: MatSort, private validacion: ValidacionClass) {
    super();
  }


  connect(): Observable<any[]> {

    const displayDataChanges = [
      this.sort.sortChange,
      this.paginator.page,
      this.validacion.validacionChange,
      this.validacion.changeValues
    ];

    this.sort.sortChange.subscribe(() => this.paginator.pageIndex = 0);

    return Observable.merge(...displayDataChanges)
      .startWith(null)
      .switchMap(() => {
        this.isLoadingResults = true;
        return this.permisosHttpDAO.getReportPermisos(
          this.paginator.pageIndex,
          this.paginator.pageSize,
          this.sort.direction,
          this.sort.active,
          this.validacion.validacion // Filtro de Validaciones 
        );
      })
      .map(data => {
        this.isLoadingResults = false;
        this.isRateLimitReached = false;
        this.resultLength = data.TotalLength; /// Largo de los resultados...
        return data.Items; /// Resultados
      })
      .catch((e) => {
        console.log('Catch');
        console.log(e);
        this.isLoadingResults = false;
        this.isRateLimitReached = true;
        return Observable.of([]);
      })

  }

  disconnect() { }
}
