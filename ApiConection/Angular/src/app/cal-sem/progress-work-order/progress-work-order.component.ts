import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { PlaneacionProduccionService, OrderData } from 'src/app/Services/planeacion-produccion.service';

@Component({
  templateUrl: './progress-work-order.component.html',
  styleUrls: ['./progress-work-order.component.scss']
})
export class ProgressWorkOrderComponent implements OnInit, OnDestroy {
  id: string;
  data: OrderData;
  private sub: Subscription;
  private sub2: Subscription;

  constructor(private route: ActivatedRoute, private planeacionProduccionService: PlaneacionProduccionService) { }

  ngOnInit(): void {
    this.sub = this.route.params.subscribe(param => {
      this.id = param['ot'];
      this.sub2 = this.planeacionProduccionService.getProgress(this.id).subscribe(data => {
        this.data = data;
        console.log(data);
      });
    })
  }

  ngOnDestroy(): void {
    this.sub.unsubscribe();
    this.sub2.unsubscribe();
  }

}
