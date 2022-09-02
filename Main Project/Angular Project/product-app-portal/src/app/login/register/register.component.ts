import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../auth.service';
import { LoginService } from '../login.service';
import { ConfirmPasswordValidation } from './confirm-password.validators';
import { EmailValidation } from './email.validation';
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  registerFormGroup!: FormGroup;
  constructor(private formBuilder: FormBuilder, private router: Router, private loginService: LoginService, private authService: AuthService) { }

  ngOnInit(): void {
    this.registerFormGroup = this.formBuilder.group({
      firstName: ['', [Validators.required, Validators.maxLength(15)]],
      lastName: ['', [Validators.required, Validators.maxLength(15)]],
      email: ['', [Validators.required, Validators.email, Validators.maxLength(25), EmailValidation('test@g.com')]],
      password: ['', [Validators.minLength(5), Validators.required]],
      confirmPassword: ['', Validators.required]
    }
      , { validators: ConfirmPasswordValidation("password", "confirmPassword") }
    );
  }
  onSubmit() {
    console.log(this.registerFormGroup);
    if (this.registerFormGroup.invalid) {
      return;

    }
    // this.loginService.register(this.registerFormGroup.value);
    this.authService.register(this.registerFormGroup.value).subscribe((res: any) => {

      this.router.navigate(['/login']);
    });
    console.log(this.registerFormGroup.value);
  }
}
