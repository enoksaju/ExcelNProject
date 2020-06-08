

import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, Router } from '@angular/router';
import { IdentityService, iUser } from '../identity.service';

@Injectable({ providedIn: 'root' })
export class AuthGuard implements CanActivate {
  User: iUser;

  constructor(private identityService: IdentityService) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    const currentUser = this.identityService.currenUserValue;
    if (currentUser) {
      var y = currentUser.Roles.some(rol => {
        if (route.data.roles && route.data.roles.indexOf(rol) > -1) {
          return true;
        }
      });

      if (y) return true;
      this.identityService.goToRoute('/');
      return false;
    }
    this.identityService.goToRoute('login', { queryParams: { toRoute: state.url } });
    return false;
  }
}
