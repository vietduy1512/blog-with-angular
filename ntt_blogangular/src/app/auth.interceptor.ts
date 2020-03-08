import { Injectable } from '@angular/core';
import { HttpInterceptor } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AuthInterceptor implements HttpInterceptor {

  constructor() { }

  intercept(req, next) {
    const access_token = sessionStorage.getItem('access_token');

    const authRequest = req.clone({
      headers: req.headers.set('Authorization', `Bearer ${access_token}`)
    });
    return next.handle(authRequest);
  }
}
