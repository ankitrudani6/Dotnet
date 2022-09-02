import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { LoginGuard } from './login/login.guard';
import { RegisterComponent } from './login/register/register.component';

const routes: Routes = [
  { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
  { path: 'dashboard', component: DashboardComponent },
  { path: 'register', component: RegisterComponent },
  {
    path: 'login',
    loadChildren: () => import("./login/login.module").then(m => m.LoginModule),
  },
  {
    path: 'mobiles',
    loadChildren: () => import("./mobiles/mobiles.module").then(m => m.MobilesModule),
    canLoad: [LoginGuard]
  },
  { path: '**', redirectTo: 'dashboard' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
