import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { MobileService } from '../mobile.service';

@Component({
  selector: 'app-add-mobile',
  templateUrl: './add-mobile.component.html',
  styleUrls: ['./add-mobile.component.css']
})
export class AddMobileComponent implements OnInit, OnDestroy {
  @ViewChild('form') AddMobileForm!: NgForm;
  constructor(private mobileService: MobileService, private router: Router) {
    console.log("AddMobileComponent constructor")
  }
  isOtherImage: string = "no";
  otherImagesArray: any = ['', '', '', ''];
  ngOnInit(): void {
  }
  onSubmit(form: NgForm) {
    this.AddMobileForm.value["otherImages"] = this.otherImagesArray;
    console.log(this.AddMobileForm.value);
    this.mobileService.addMobile(this.AddMobileForm.value);
    this.onCancel();
  }
  onCancel() {
    this.router.navigate(['/mobiles'])
  }
  ngOnDestroy() { }
}
