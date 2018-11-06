import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';

export interface IMaterial {
  id: number;
  nombre: string;
  abrev: string;
  densidad: number;
}

export interface IMaterialConfig {
  Calibre: number;
  Ancho: number;
  GramosTinta?: number;
}

export enum Centros {
  _3_Pulgadas = 3,
  _6_Pulgadas = 6,
}

export class ProductionConfig {
  public Material: IMaterial;
  public MaterialConfig: IMaterialConfig;

  public Velocidad?: number;
  public Tinta = 0;
  public AltoRollo?: number;
  public Centro?: Centros;
  public Desarrollo?: number;
  public Repeticiones?: number;
  public Cantidad?: number;
  public Metros?: number;

  public CalcularMetrosLineales(Peso: number): number {
    const calculo =
      (Peso * 100000) /
      ((this.MaterialConfig.Calibre * this.Material.densidad + this.Tinta) *
        this.MaterialConfig.Ancho);
    this.Metros = calculo;
    return calculo;
  }

  public CalcularKg(Metros: number) {
    
  }

}

const INSERT_MATERIAL_SQL = 'INSERT INTO materiales (nombre, abrev, densidad) VALUES (?,?,?)';

const CREATE_MATERIALES_TABLE =
  'CREATE TABLE IF NOT EXISTS materiales (id INTEGER PRIMARY KEY, nombre VARCHAR, abrev VARCHAR, densidad FLOAT)';

const INITIAL_MATERIALES: IMaterial[] = [
  {
    id: 1,
    nombre: 'Polietileno de Baja Densidad',
    abrev: 'PELD',
    densidad: 0.925,
  },
  {
    id: 2,
    nombre: 'Polietileno de Alta Densidad',
    abrev: 'PEHD',
    densidad: 0.95,
  },
  {
    id: 3,
    nombre: 'Polipropileno',
    abrev: 'PP',
    densidad: 0.905,
  },
  {
    id: 4,
    nombre: 'Polipropileno Biorientado',
    abrev: 'BOPP',
    densidad: 0.905,
  },
  {
    id: 5,
    nombre: 'Polipropileno Biorientado Perlescente',
    abrev: 'BOPP Perlescente',
    densidad: 0.65,
  },
  {
    id: 6,
    nombre: 'Tereftalato de Polietileno',
    abrev: 'PET',
    densidad: 1.38,
  },
  {
    id: 7,
    nombre: 'Tereftalato de Polietileno Glicol',
    abrev: 'PET-G',
    densidad: 1.38,
  },
  {
    id: 8,
    nombre: 'Cloruro de Polivinilo',
    abrev: 'PVC',
    densidad: 1.4,
  },
  {
    id: 9,
    nombre: 'Papel',
    abrev: 'PAPEL',
    densidad: 1.38,
  },
];

const SELECT_ALL_MATERIALS = 'SELECT * FROM materiales';

@Injectable({
  providedIn: 'root',
})
export class PeliculasService {
  private materialesObj: BehaviorSubject<IMaterial[]> = new BehaviorSubject<IMaterial[]>([]);

  private materialObj: BehaviorSubject<IMaterial> = new BehaviorSubject<IMaterial>(
    INITIAL_MATERIALES[0],
  );

  private materialConfigObj: BehaviorSubject<IMaterialConfig> = new BehaviorSubject<
    IMaterialConfig
  >({ Ancho: 0, Calibre: 0 });

  private DB: Database;

  initialiceMaterialTable(tx: SQLTransaction) {
    return new Promise((resolve, rejected) => {
      tx.executeSql(
        'select id from materiales',
        [],
        (tx_, res_) => {
          if (res_.rows.length <= 0) {
            INITIAL_MATERIALES.forEach((itm, idx, arr) => {
              tx.executeSql(
                INSERT_MATERIAL_SQL,
                [itm.nombre, itm.abrev, itm.densidad],
                (tx__, res__) => resolve(),
              );
            });
          } else {
            resolve();
          }
        },
        e => {
          return true;
        },
      );
    });
  }

  constructor(private http: HttpClient) {
    this.DB = window.openDatabase('flexCalc', '1.0', 'flexCalc', 2 * 1024 * 1024);

    this.DB.transaction(
      tx => {
        tx.executeSql(CREATE_MATERIALES_TABLE, [], (tx_, res_) => {
          console.log('Initialize Table');
          this.initialiceMaterialTable(tx_).then(() => {
            console.log('refreshing Collection');
            this.refreshCollection(tx).then(() => {
              const _mat = localStorage.getItem('Sel_Mat_id');
              console.log('searching material...');
              tx.executeSql(
                'SELECT * FROM materiales WHERE id=?',
                [_mat ? _mat : '1'],
                (tx__, val) => {
                  this.materialObj.next(val.rows.item(0));
                  console.log('found material...');
                },
                (tx__, error): boolean => {
                  this.materialObj.error(error);
                  return false;
                },
              );
              const _loc = localStorage.getItem('Conf_Mat');
              const conf = JSON.parse(_loc ? _loc : '{ "Ancho": "0", "Calibre": "0" }');
              this.materialConfigObj.next(conf);
            });
          });
        });
      },
      e => alert(e.message),
    );
  }

  private refreshCollection(tx: SQLTransaction) {
    return new Promise<IMaterial[]>((resolve, rejected) => {
      tx.executeSql(
        SELECT_ALL_MATERIALS,
        [],
        (tx__, results) => {
          const res__: IMaterial[] = new Array<IMaterial>();
          for (let i = 0; i < results.rows.length; i++) {
            res__.push(results.rows.item(i));
          }
          this.materialesObj.next(res__);
          console.log('refreshed...');
          resolve(res__);
        },
        (tx__, error): boolean => {
          this.materialesObj.next([]);
          return false;
        },
      );
    });
  }

  getSelectedMaterial() {
    return this.materialObj.asObservable();
  }

  getMaterialConfig() {
    return this.materialConfigObj.asObservable();
  }

  refreshCurrentMaterialConfig(val: IMaterialConfig) {
    localStorage.setItem('Conf_Mat', JSON.stringify(val));
    this.materialConfigObj.next(val);
  }

  refreshSelectedMaterial(val: IMaterial) {
    localStorage.setItem('Sel_Mat_id', val.id.toString());
    this.materialObj.next(val);
  }

  Materiales() {
    return this.materialesObj.asObservable();
  }

  AddMaterial(obj: IMaterial) {
    this.DB.transaction(tx => {
      tx.executeSql(INSERT_MATERIAL_SQL, [obj.nombre, obj.abrev, obj.densidad], (tx_, result) =>
        this.refreshCollection(tx),
      );
    });
  }
}
