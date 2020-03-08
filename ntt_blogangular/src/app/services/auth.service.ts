import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { URLSearchParams } from '@angular/http';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private _REGISTER_URL = 'http://localhost:45111/api/account/register';
  private _LOGIN_URL = 'http://localhost:45111/token';
  private _LOGOUT_URL = 'http://localhost:45111/api/Account/Logout';

  constructor(private _http: HttpClient, private router: Router) { }

  get isAuthenticated() {
    return !!sessionStorage.getItem('access_token');
  }

  get getCurrentUserName() {
    return sessionStorage.getItem('userName');
  }


  register(credentials) {
    return this._http.post<any>(this._REGISTER_URL, credentials)
      .subscribe(res => {
        const data = {
          username: credentials.username,
          password: credentials.password,
          grant_type: 'password'
        };
        this.login(data);

      }, errors => {
        this.router.navigate(['/register']);
        window.location.reload();
      });
  }

  login(credentials) {
    const queryString = this.getQueryString(credentials);

    this._http.post<any>(this._LOGIN_URL, queryString)
      .subscribe(res => {
        sessionStorage.setItem('access_token', res.access_token);
        sessionStorage.setItem('userName', res.userName);
        this.router.navigate(['/']);

      }, errors => {
        this.router.navigate(['/login']);
        window.location.reload();
      });
  }

  logout() {
    sessionStorage.removeItem('access_token');
    sessionStorage.removeItem('userName');
    this.router.navigate(['/']);
    this._http.post<any>(this._LOGOUT_URL, null);  // cancel session
  }

  getQueryString(credentials) {
    // Convert to query string since server dont accept json object
    const params = new URLSearchParams();
    for (const key in credentials) {
      if (credentials[key]) {
        params.set(key, credentials[key]);
      }
    }
    return params.toString();
  }
}
