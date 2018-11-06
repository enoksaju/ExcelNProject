import { Component, OnInit, OnDestroy, ViewChild, ElementRef } from '@angular/core';
import { PeliculasService, IMaterial, IMaterialConfig } from '../peliculas.service';
import { Subscription } from 'rxjs';
import { MatSelect } from '@angular/material';
import { FormGroup, FormControl } from '@angular/forms';

export class MetrosLineales {
  public MaterialConfig: IMaterialConfig;
  public IMaterial: IMaterial;
  
  
}

@Component({
  selector: 'cal-metros-lineales',
  templateUrl: './metros-lineales.component.html',
  styleUrls: ['./metros-lineales.component.scss'],
})
export class MetrosLinealesComponent implements OnInit, OnDestroy {
  materiales: IMaterial[];
  materialId: number;
  material: IMaterial;

  MaterialConfig: IMaterialConfig;

  private materialesS: Subscription;
  private materialS: Subscription;
  private materialConfigS: Subscription;

  constructor(private peliculasService: PeliculasService) {}
  ngOnInit() {
    this.materialS = this.peliculasService.getSelectedMaterial().subscribe(v => {
      this.materialId = v.id;
      this.material = v;
    });
    this.materialConfigS = this.peliculasService
      .getMaterialConfig()
      .subscribe(v => (this.MaterialConfig = v));
    this.materialesS = this.peliculasService.Materiales().subscribe(mt => (this.materiales = mt));
  }
  ngOnDestroy() {
    this.materialesS.unsubscribe();
    this.materialS.unsubscribe();
  }
  onMaterialChange(event) {
    this.peliculasService.refreshSelectedMaterial(this.materiales.find(o => o.id === event.value));
  }
  updateMaterialConfig() {
    this.peliculasService.refreshCurrentMaterialConfig(this.MaterialConfig);
  }
  log(any: string) {
    const av = document.getElementById(any).clientHeight;
    console.log(av);
    alert(JSON.stringify(av));
  }
}
