import { Component, OnDestroy, OnInit } from '@angular/core';
import { ChildrenOutletContexts, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { AuthService } from './login/auth.service';
import { LoginService } from './login/login.service';
import { slideInAnimation } from './mobiles/animations';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  animations: [slideInAnimation]
})
export class AppComponent implements OnInit, OnDestroy {
  title = 'product-app-portal';
  isLoggedIn: boolean = false;
  userData: any;
  userSub!: Subscription;
  constructor(public loginService: LoginService, private authService: AuthService, private contexts: ChildrenOutletContexts, private router: Router) {
    this.userData = JSON.parse(localStorage.getItem('user')!);

    if (this.userData) { this.loginService.isLoggedIn.next(true); }
  }
  ngOnInit() {
    // this.loginService.isLoggedIn.subscribe((res: boolean) => {
    //   this.isLoggedIn = res;
    //   this.userData = JSON.parse(localStorage.getItem('user')!);
    // });
    this.authService.autoLogin();

    this.userSub = this.authService.user.subscribe((user: any) => {
      this.isLoggedIn = !!user;
      this.userData = JSON.parse(localStorage.getItem('userData')!);
    });

  }
  logout() {
    // this.loginService.logout();
    this.authService.logout();
  }
  getRouteAnimationData() {
    return this.contexts.getContext('primary')?.route?.snapshot?.data?.['animation'];
  }
  ngOnDestroy() {
    this.userSub.unsubscribe();
  }
}
