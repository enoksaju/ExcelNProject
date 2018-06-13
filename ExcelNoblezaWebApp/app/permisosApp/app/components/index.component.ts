import { Component, OnInit, Input } from '@angular/core';
import { ObservableMedia } from "@angular/flex-layout";
import { Headers, Http, RequestOptions } from '@angular/http';


@Component({
  selector: 'index-page',
  templateUrl: './index.component.html',
  styles: []
})
export class IndexComponent implements OnInit {
  constructor(public media: ObservableMedia, private http: Http) { }

  ngOnInit(): void { }
}