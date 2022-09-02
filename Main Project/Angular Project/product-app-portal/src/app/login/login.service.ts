import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject, of, Subscription, throwError } from 'rxjs';
import { User } from '../Models/user.model';
const registeredUser: User[] = [{ userId: 1, email: 'test@g.com', password: 'test123', firstName: 'Test', lastName: 'User' }];
@Injectable({
  providedIn: 'root'
})
export class LoginService {
  userData = new BehaviorSubject<any>([]);
  isLoggedIn = new BehaviorSubject<boolean>(false);
  newRegisterUser: any;
  subscription!: Subscription;

  constructor(private router: Router,) {
    // this.userData = new BehaviorSubject<any>(JSON.parse(localStorage.getItem('user')!));
  }
  public get userValue() {
    return this.userData.value;
  }
  login(email: string, password: string) {
    this.subscription = this.userData.subscribe((res: any) => {
      this.newRegisterUser = res;
      console.log(1);

    });
    // let loginUser = this.newRegisterUser ? this.newRegisterUser : registeredUser[0];
    if (this.newRegisterUser.length > 0) {
      registeredUser.push(this.newRegisterUser[0]);
    };
    let loginUser = registeredUser.find((x: User) => x.email === email && x.password === password)
    if (loginUser) {
      let user: User = {
        userId: 1,
        email: loginUser.email,
        firstName: loginUser.firstName,
        lastName: loginUser.lastName,
        // password: userData.password
      }
      localStorage.setItem('user', JSON.stringify(user));
      setTimeout(() => {
        this.router.navigate(['dashboard']);
      }, 1000);
      this.isLoggedIn.next(true);
      return of(true);
    }
    else {
      return throwError("Username or password is incorrect")
    }

    // return this.isLoggedIn;
  }
  register(userData: User) {
    this.userData.next([userData]);

  }
  logout() {
    localStorage.clear();
    this.isLoggedIn.next(false);
    this.subscription.unsubscribe();
    this.router.navigate(['/login'])

  }

}
