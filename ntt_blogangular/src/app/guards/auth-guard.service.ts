import { Injectable } from '@angular/core';
import { AuthService } from '../services/auth.service';
import {
  CanActivate, Router,
  ActivatedRouteSnapshot,
  RouterStateSnapshot
} from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthGuardService implements CanActivate {

  constructor(
      private auth: AuthService,
      private router: Router
  ) {}

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    if (this.auth.isAuthenticated) {
      return true;

    } else {
      // TODO: Store the attempted URL for redirecting
      // this.authService.redirectUrl = url;

      this.router.navigate(['/login']);
      return false;
    }
  }

}
