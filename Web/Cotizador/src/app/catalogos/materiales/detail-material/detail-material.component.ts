import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import {
  CatalogosService,
  IMaterial,
  ROUTE_MATERIALES,
  prefixApi
} from '../../../catalogos.service';
import { HttpClient } from '@angular/common/http';
import { formatDate } from '@angular/common';
import { Chart } from 'chart.js';
import { delay } from 'rxjs/operators';

@Component({
  selector: 'cat-detail-material',
  templateUrl: './detail-material.component.html',
  styleUrls: ['./detail-material.component.scss']
})
export class DetailMaterialComponent implements OnInit, OnDestroy {
  Id: number;
  entity: IMaterial;
  isLoading: boolean = true;
  notFound: boolean = false;
  routeSub$: Subscription;
  routeSub2$: Subscription;

  chart_: any = {};

  constructor(
    private http: HttpClient,
    private route: ActivatedRoute,
    private catalogosService: CatalogosService
  ) {
    this.routeSub2$ = this.route.url.subscribe(() => {
      this.isLoading = true;
      this.notFound = false;
    });

    this.routeSub$ = this.route.params.subscribe(params => {
      this.Id = +params['Id'];
      this.catalogosService
        .getEntity<IMaterial>(this.Id, ROUTE_MATERIALES)
        .then(val => {
          this.entity = val;
          this.isLoading = false;
          this.fillChart(val.Id);
        })
        .catch(err => {
          this.notFound = true;
          this.isLoading = false;
          console.log(err);
        });
    });

    Chart.plugins.register({
      afterDatasetsDraw: function(chart) {
        const ctx = chart.ctx;

        chart.data.datasets.forEach(function(dataset, i) {
          const meta = chart.getDatasetMeta(i);
          if (!meta.hidden) {
            meta.data.forEach(function(element: any, index) {
              // Draw the text in black, with the specified font

              ctx.fillStyle = '#000';

              const fontSize = 12;
              const fontStyle = 'normal';
              const fontFamily = 'Roboto';
              ctx.font = Chart.helpers.fontString(
                fontSize,
                fontStyle,
                fontFamily
              );

              // Just naively convert to string for now
              const dataString = '$' + dataset.data[index].toString();

              // Make sure alignment settings are correct
              ctx.textAlign = 'center';
              ctx.textBaseline = 'middle';

              const padding = 5;
              const position = element.tooltipPosition();
              ctx.fillText(
                dataString,
                position.x,
                position.y - fontSize / 2 - padding
              );
            });
          }
        });
      }
    });
  }

  ngOnInit() {}
  ngOnDestroy() {
    this.routeSub$.unsubscribe();
    this.routeSub2$.unsubscribe();
  }

  fillChart(id: number) {
    this.http
      .get(`${prefixApi}${ROUTE_MATERIALES}/chart/${id}`)
      .subscribe((val: Array<any>) => {
        const labels = val.map(v => formatDate(v.label, 'mediumDate', 'es-MX').split(' '));
        const values = val.map(v => v.data);

        const ctx = document.getElementById(
          `movimientos${id}`
        ) as HTMLCanvasElement;

        const _chart = new Chart(ctx, {
          type: 'line',
          data: {
            labels: labels,
            datasets: [
              {
                label: 'Comportamiento del precio',
                data: values,
                fill: false,
                borderColor: '#3cba9f',
                lineTension: 0
              }
            ]
          },
          options: {
            legend: { display: true },
            responsive: true,
            maintainAspectRatio: false,
            scales: {
              xAxes: [{ display: true }],
              yAxes: [{ display: true }]
            }
          }
        });

        this.chart_ = _chart;

        const mediaQueryList = window.matchMedia('print');
        mediaQueryList.addListener(function(mql) {
          console.log(mql);
          if (mql.matches) {
            _chart.resize();
            console.log('cambiando tamaño');
            delay(500);
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
}
