import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../auth.service';
import { LoginService } from '../login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  error: any;
  isLoggedIn: boolean = false;
  constructor(public loginService: LoginService, private router: Router, private authService: AuthService) { }
  userName = '';
  password = '';
  ngOnInit(): void {
    this.loginService.isLoggedIn.subscribe((res: boolean) => {
      this.isLoggedIn = res;
    });
  }
  onLoginClicked() {
    // 1. Without API
    // this.loginService.login(this.userName, this.password)
    //   .subscribe((res: any) => {

    //   },
    //     (error: any) => {
    //       this.error = error;
    //     }
    //   );

    // 2.With API
    this.authService.login(this.userName, this.password)
      .subscribe((res: any) => {
        setTimeout(() => {
          this.router.navigate(['dashboard']);
        }, 1000);
      },
        (error: any) => {
          this.error = error;
        }
      );

  }
}
