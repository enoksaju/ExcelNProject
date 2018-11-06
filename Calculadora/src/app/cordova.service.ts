import { Injectable, NgZone } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class CordovaService {
  private resume: BehaviorSubject<boolean>;
  constructor(private zone: NgZone) {
    this.resume = new BehaviorSubject<boolean>(null);
    document.addEventListener('resume', e => {
      this.zone.run(() => {
        this.onResume();
      });
    });
  }

  get cordova(): Cordova {
    return window.cordova; // _window().cordova;
  }
  get onCordova(): Boolean {
    return !!window.cordova; // _window().cordova;
  }
  public onResume(): void {
    this.resume.next(true);
  }
}
