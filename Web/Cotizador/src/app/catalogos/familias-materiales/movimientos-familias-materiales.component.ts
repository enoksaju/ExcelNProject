import { Component, OnInit, Inject, ViewChild, HostListener, Sanitizer } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA, MatPaginator, MatSort, MatDialog } from '@angular/material';
import { DialogResults } from '../../dialog.component';
import {
  CatalogosService,
  ROUTE_MOVIMIENTOS_PRECIO_FAMILIA_MATERIALES,
  prefixApi,
  ROUTE_MOVIMIENTOS_PRECIO_FAMILIA_MATERIALES_CHARTS,
  ROUTE_FAMILIA_MATERIALES,
  IFamiliasMateriales,
} from '../../catalogos.service';
import { Observable, observable, of, merge } from 'rxjs';
import { startWith, switchMap, map, catchError, delay } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';

import { Chart } from 'chart.js';

import { DomSanitizer } from '@angular/platform-browser';
import { formatDate } from '@angular/common';
import { AddMovimientosFamiliasMaterialesComponent } from './add-movimientos-familias-materiales.component';

@Component({
  selector: 'app-movimientos-familias-materiales',
  templateUrl: './movimientos-familias-materiales.component.html',
  styles: [],
})
export class MovimientosFamiliasMaterialesComponent implements OnInit {
  displayedColumns: string[] = ['FechaOperacion', 'FechaRegistro', 'Valor'];
  resultsLength = 0;
  isLoadingResults = true;
  isRateLimitReached = false;
  dataSource: any[] = [];
  NombreFamilia: string;

  chart_: any = {};
  // chartData: ISeries[];
  // curve: any = shape.curveStepAfter;
  // xMaxScale = new Date();
  // xMinScale: Date;

  constructor(
    public dialogRef: MatDialogRef<MovimientosFamiliasMaterialesComponent, DialogResults>,
    @Inject(MAT_DIALOG_DATA) public data: number,
    private catalogosService: CatalogosService,
    private http: HttpClient,
    private dialog: MatDialog
  ) {
    merge()
      .pipe(
        startWith({}),
        switchMap(() => {
          this.isLoadingResults = true;
          return this.catalogosService.getCollectionsOfEntity(
            data,
            ROUTE_MOVIMIENTOS_PRECIO_FAMILIA_MATERIALES
          );
        }),
        map(dt => {
          this.isLoadingResults = false;
          this.isRateLimitReached = false;
          return dt;
        }),
        catchError(() => {
          this.isLoadingResults = false;
          this.isRateLimitReached = true;
          return of([]);
        })
      )
      .subscribe(dat => (this.dataSource = dat));

    this.catalogosService
      .getEntity(this.data, ROUTE_FAMILIA_MATERIALES)
      .then((fam: IFamiliasMateriales) => {
        this.NombreFamilia = fam.NombreFamilia;
      });
  }

  ngOnInit() {
    this.http
      .get(`${prefixApi}${ROUTE_MOVIMIENTOS_PRECIO_FAMILIA_MATERIALES_CHARTS}/${this.data}`)
      .subscribe((res: ISeries[]) => {
        const labels = res[0].series.map(v => formatDate(v.name, 'mediumDate', 'es-MX'));
        const values = res[0].series.map(v => v.value);

        const ctx = document.getElementById(`movs${this.data}`) as HTMLCanvasElement;

        const _chart = new Chart(ctx, {
          type: 'line',
          data: {
            labels: labels,
            datasets: [
              {
                label: 'Movimientos',
                data: values,
                fill: false,
                borderColor: '#3cba9f',
                lineTension: 0,
              },
            ],
          },
          options: {
            legend: { display: true },
            responsive: true,
            maintainAspectRatio: false,
            scales: {
              xAxes: [{ display: true }],
              yAxes: [{ display: true, ticks: { beginAtZero: true } }],
            },
          },
        });

        this.chart_ = _chart;

        const mediaQueryList = window.matchMedia('print');
        mediaQueryList.addListener(function(mql) {
          if (mql.matches) {
            _chart.resize();
            delay(1000);
            console.log('webkit equivalent of onbeforeprint');
          }
        });
      });
  }

  imageOfChart(chart: any) {
    if (chart.toBase64Image !== undefined) {
      return chart.toBase64Image();
    }
    return '';
  }

  add() {
    this.dialog
      .open<AddMovimientosFamiliasMaterialesComponent, number, DialogResults>(
        AddMovimientosFamiliasMaterialesComponent,
        {
          disableClose: true,
          data: this.data,
          width: '450px',
        }
      )
      .afterClosed()
      .toPromise()
      .then(m => {
        if (m === DialogResults.Ok) {
          this.dialogRef.close(DialogResults.Ok);
        }
      });
  }
  // private convertDates(target, ...properties) {
  //   for (const prop of properties) {
  //     target[prop] = new Date(target[prop]);
  //   }
  //   return target;
  // }
}

export interface ISeries {
  name: string;
  series: ISeriesData[];
}
export interface ISeriesData {
  name: Date;
  value: number;
}
