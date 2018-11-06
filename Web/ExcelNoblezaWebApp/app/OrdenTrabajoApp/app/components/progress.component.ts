import { Component, OnInit, Input } from '@angular/core';
import { ObservableMedia } from "@angular/flex-layout";
import { Headers, Http, RequestOptions } from '@angular/http';

@Component({
  template: `
<h3>Progress</h3>
`,
  styles: []
}) export class ProgressComponent implements OnInit {
  constructor(public media: ObservableMedia, private http: Http) { }
  ngOnInit(): void {

  }
}