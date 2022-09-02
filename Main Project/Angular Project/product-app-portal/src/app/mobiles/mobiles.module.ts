import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { AgGridModule } from 'ag-grid-angular';
import { ActionButtonGridComponent } from './action-button-grid/action-button-grid.component';
import { AddMobileComponent } from './add-mobile/add-mobile.component';
import { EditMobileComponent } from './edit-mobile/edit-mobile.component';
import { ImageFormatterCellComponent } from './image-formatter-cell/image-formatter-cell.component';
import { MobileListComponent } from './mobile-list/mobile-list.component';
import { MobileService } from './mobile.service';
import { MobileRoutingModule } from './mobiles.routing';
@NgModule({
  declarations: [
    MobileListComponent,
    AddMobileComponent,
    EditMobileComponent,
    ImageFormatterCellComponent,
    ActionButtonGridComponent
  ],
  imports: [
    CommonModule, MobileRoutingModule, FormsModule, ReactiveFormsModule, AgGridModule.withComponents([ImageFormatterCellComponent, ActionButtonGridComponent])
  ], providers: [MobileService]
})
export class MobilesModule { }
