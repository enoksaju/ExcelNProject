import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { ObservableMedia } from "@angular/flex-layout";
import { Router } from '@angular/router';
import { TrabajadorService, Estatus, DataReport, ResultReport } from '../../../common/Services/trabajador.service'
import { Http } from "@angular/http";
import { DataSource } from '@angular/cdk/collections';
import { Observable } from 'rxjs/Observable';
import { MatPaginator, MatSort, MatTable } from '@angular/material';
import { ConverterService } from '../../../common/Services/converter.service';

@Component({
  selector: 'reporte-page',
  templateUrl: './reporte.component.html',
  styleUrls: ['./reporte.component.css']
})

export class ReporteComponent implements OnInit {
  displayedColumns = ['Clave', 'Folio', 'Dia1', 'Dia2', 'Dia3', 'Dia4', 'Dia5', 'Dia6', 'Dia7', 'Dia8', 'Dia9', 'Dia10', 'Concepto', 'Estatus', 'Validado', 'Comentarios']

  dataSource: ReporteDataSource | null;
  dataReport: DataReport | null;
  DateSearch: string | null;

  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatTable) table: MatTable<ReporteDataSource>

  constructor(private Router: Router, private trabajadorService: TrabajadorService, private converterService: ConverterService) { };

  ngOnInit(): void {
    this.dataReport = new DataReport();
    this.dataReport.Fecha = this.ultimoMartes();
    this.DateSearch = this.getShortFechaString(this.dataReport.Fecha);
    this.dataReport.Estatus = Estatus.Nuevo;
    this.dataSource= new ReporteDataSource(this.trabajadorService, this.sort, this.dataReport);
  };

  setDataReportFecha(searchFecha: string): void {    
    this.dataReport.Fecha = (searchFecha + " 00:00:00").toDate("yyyy-mm-dd hh-ii-ss");
  }

  private getDateforDay(days: number):string[] {
    let d = this.dataReport.Fecha.plusToDate("day", days), ret: string[] = [];

    ret.push((d.getDate() < 10 ? '0' : '') + d.getDate());
    ret.push(d.getMonthName()) //((d.getMonth() + 1) < 10 ? '0' : '') + (d.getMonth() + 1)) 
    ret.push(d.getFullYear().toString())

    return ret;
  }

  private downloadExcel(table: any): void {
    var t = this.converterService.toXls(document.getElementsByClassName(table)[0], "Prueba"), dwn = document.createElement("a"), dt = this.dataReport.Fecha;
    dwn.href = t;
    dwn.setAttribute('download', "Reporte Permisos " + dt.getDay() + " " + dt.getMonthName() + " " + dt.getFullYear() + ".xls");
    dwn.click()
  };

  private getShortFechaString(date: Date): string {
    var d = date;
    var ret = d.getFullYear() + "-" + ((d.getMonth() + 1) < 10 ? '0' : '') + (d.getMonth() + 1) + '-' + (d.getDate() < 10 ? '0' : '') + d.getDate();
    return ret;
  }

  private ultimoMartes(): Date  {
    var now = new Date();
    var day = now.getDay();
    var t = (o: number): number => {
      switch (o) {
        case 0:
          return 5;
        case 1:
          return 6;
        case 2:
          return 7;
        default:
          return day - 3
      }
    }
    return new Date(new Date().setDate(now.getDate() - t(day)));
  }
}

class ReporteDataSource extends DataSource<ResultReport>{
  resultLength: number = 0;
  isLoadingResults = false;
  isRateLimitReached = false;

  constructor(private trabajadorService: TrabajadorService, private sort: MatSort, private dataReport: DataReport) {
    super();
  }


  connect(): Observable<ResultReport[]> {


    const displayDataChanges = [
      this.sort.sortChange,
      this.dataReport.changeValues
    ];

    return Observable.merge(...displayDataChanges)
      .startWith(null)
      .switchMap(() => {
        this.isLoadingResults = true;
        return this.trabajadorService.GetReportPermisos(this.dataReport);
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