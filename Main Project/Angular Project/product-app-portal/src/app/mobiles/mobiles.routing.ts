import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginGuard } from '../login/login.guard';
import { AddMobileComponent } from './add-mobile/add-mobile.component';
import { EditMobileComponent } from './edit-mobile/edit-mobile.component';
import { MobileListComponent } from './mobile-list/mobile-list.component';

const MobileRoutes: Routes = [
  {
    path: "", component: MobileListComponent, canActivate: [LoginGuard], data: { animation: 'ListPage' }
  },
  {
    path: "add-mobile", component: AddMobileComponent, data: { animation: 'AddPage' }
  }, {
    path: ":id", component: EditMobileComponent, data: { animation: 'AddPage' }
  }
]
@NgModule({
  imports: [RouterModule.forChild(MobileRoutes)],
  exports: [RouterModule]
})
export class MobileRoutingModule { }
