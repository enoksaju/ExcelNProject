import { Component, OnInit, OnDestroy, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription, interval } from 'rxjs';
import { PlaneacionProduccionService, OrderData } from 'src/app/Services/planeacion-produccion.service';
import { map } from 'rxjs/operators';
import { PDFDocumentProxy, PdfViewerComponent } from 'ng2-pdf-viewer';
import { NestedTreeControl } from '@angular/cdk/tree';
import { MatTreeNestedDataSource } from '@angular/material/tree';


@Component({
  templateUrl: './progress-work-order.component.html',
  styleUrls: ['./progress-work-order.component.scss']
})
export class ProgressWorkOrderComponent implements OnInit, OnDestroy {
  id: string;
  data: OrderData;
  private sub: Subscription;
  private sub2: Subscription;
  private sub3: Subscription;

  @ViewChild(PdfViewerComponent)
  private pdfComponent: PdfViewerComponent;

  treeControl = new NestedTreeControl<any>(node => {
    console.log(node);
    return node.items
  });
  dataSource = new MatTreeNestedDataSource<any>();
  hasChild = (_: number, node: any) => !!node.items && node.items.length > 0;


  constructor(
    private route: ActivatedRoute,
    private planeacionProduccionService: PlaneacionProduccionService) { }



  ngOnInit(): void {

    this.planeacionProduccionService.CleanDataOrder();

    this.sub = this.route.params.subscribe(param => {

      this.id = param['ot'];

      this.planeacionProduccionService.UpdateDataOrder(this.id);

      this.sub2 = this.planeacionProduccionService.DetailsOT.subscribe(data => {
        this.data = data;
      });

      this.sub3 = interval(30000)
        .pipe(map(c => {
          console.log(c);
          return c;
        }))
        .subscribe((c) => {
          this.planeacionProduccionService.UpdateDataOrder(this.id);
        });

    });
  }



  ngOnDestroy(): void {
    this.sub.unsubscribe();
    this.sub2.unsubscribe();
    this.sub3.unsubscribe();
  }

  pdf: PDFDocumentProxy;
  outline: any;

  loadComplet(pdfData: any) {
    console.log(pdfData);
    this.pdf = pdfData;

    this.pdf.getOutline().then((u: any) => {

      console.log(u);
      this.dataSource = u;
    });
  }

  navigateTo(destination: any) {
    this.pdfComponent.pdfLinkService.navigateTo(destination);
  }

  printPDF() {
    var isMobile = navigator.userAgent.match(
      /(iPhone|iPod|iPad|Android|webOS|BlackBerry|IEMobile|Opera Mini)/i);

    if (!isMobile) window.open(this.pdfComponent.src.toString()).print();
    if (isMobile) window.open(this.pdfComponent.src.toString());

  }
}



