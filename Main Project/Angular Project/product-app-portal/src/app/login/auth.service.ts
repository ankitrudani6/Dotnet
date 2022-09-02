import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject, throwError } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { User } from '../Models/user.model';
import { UserApi } from './user-api';
@Injectable({
  providedIn: 'root'
})
export class AuthService {
  user = new BehaviorSubject<any>(null);
  registerURL: string = environment.apiURL + 'api/Authenticate/register';
  loginURL: string = environment.apiURL + 'api/Authenticate/login';
  private tokenExpirationTimer: any;
  constructor(private router: Router, private http: HttpClient) { }
  register(userData: User) {
    return this.http.post(this.registerURL, {
      username: userData.firstName,
      email: userData.email,
      password: userData.password
    }).pipe(
      catchError(this.handleError)
    );

  }
  login(email: string, password: string) {
    return this.http.post(this.loginURL, {
      email: email,
      password: password
    }).pipe(
      catchError(this.handleError),
      tap((resData: any) => {
        this.handleAuthentication(
          resData.email,
          resData.localId,
          resData.token,
          resData.expiration
        );
      })
    );

  }
  private handleAuthentication(
    email: string,
    userId: string,
    token: string,
    expiresIn: string
  ) {
    // const expirationDate = new Date(new Date().getTime() + expiresIn * 1000);
    const expirationDate = expiresIn;
    const user = new UserApi(email, userId, token, expirationDate);
    this.user.next(user);
    const getMilliseconds = new Date(expiresIn).valueOf() - new Date().valueOf();
    this.autoLogout(getMilliseconds);
    localStorage.setItem('userData', JSON.stringify(user));
  }

  private handleError(errorRes: HttpErrorResponse) {
    let errorMessage = 'An unknown error occurred!';
    if (!errorRes.error || !errorRes.error.error) {
      // return throwError(errorMessage);
      return throwError(() => new Error(errorMessage));
    }
    switch (errorRes.error.error.message) {
      case 'EMAIL_EXISTS':
        errorMessage = 'This email exists already';
        break;
      case 'EMAIL_NOT_FOUND':
        errorMessage = 'This email does not exist.';
        break;
      case 'INVALID_PASSWORD':
        errorMessage = 'This password is not correct.';
        break;
    }
    // return throwError(errorMessage);
    return throwError(() => new Error(errorMessage));
  }
  autoLogin() {
    const userData: {
      email: string;
      id: string;
      _token: string;
      _tokenExpirationDate: string;
    } = JSON.parse(localStorage.getItem('userData')!);
    if (!userData) {
      return;
    }

    const loadedUser = new UserApi(
      userData.email,
      userData.id,
      userData._token,
      userData._tokenExpirationDate
    );

    if (loadedUser.token) {
      this.user.next(loadedUser);
      const expirationDuration =
        new Date(userData._tokenExpirationDate).getTime() -
        new Date().getTime();
      this.autoLogout(expirationDuration);
    }
  }
  logout() {
    this.user.next(null);
    this.router.navigate(['/login']);
    localStorage.removeItem('userData');
    if (this.tokenExpirationTimer) {
      clearTimeout(this.tokenExpirationTimer);
    }
    this.tokenExpirationTimer = null;
  }

  autoLogout(expirationDuration: number) {
    this.tokenExpirationTimer = setTimeout(() => {
      this.logout();
    }, expirationDuration);
  }

}
