import { Component, OnInit, OnDestroy } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';
import { CatalogosService, IImpresora, ROUTE_IMPRESORAS } from '../../../catalogos.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'cat-detail-impresora',
  templateUrl: './detail-impresora.component.html',
  styleUrls: ['./detail-impresora.component.scss'],
})
export class DetailImpresoraComponent implements OnInit, OnDestroy {
  Id: number;
  entity: IImpresora;
  isLoading: boolean = true;
  notFound: boolean = false;
  routeSub$: Subscription;
  routeSub2$: Subscription;

  constructor(
    private http: HttpClient,
    private route: ActivatedRoute,
    private catalogosService: CatalogosService,
  ) {
    this.routeSub2$ = this.route.url.subscribe(() => {
      this.isLoading = true;
      this.notFound = false;
    });

    this.routeSub$ = this.route.params.subscribe(params => {
      this.Id = +params['Id'];
      this.catalogosService
        .getEntity<IImpresora>(this.Id, ROUTE_IMPRESORAS)
        .then(val => {
          this.entity = val;
          this.isLoading = false;
        })
        .catch(err => {
          this.notFound = true;
          this.isLoading = false;
          console.log(err);
        });
    });
  }

  ngOnInit() {}
  ngOnDestroy() {
    this.routeSub$.unsubscribe();
    this.routeSub2$.unsubscribe();
  }
}
