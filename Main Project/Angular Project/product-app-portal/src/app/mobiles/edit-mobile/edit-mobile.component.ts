import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { Mobile } from '../mobile';
import { MobileService } from '../mobile.service';

@Component({
  selector: 'app-edit-mobile',
  templateUrl: './edit-mobile.component.html',
  styleUrls: ['./edit-mobile.component.css']
})
export class EditMobileComponent implements OnInit {
  id!: number;
  mobile!: Mobile;
  editMobileFormGroup!: FormGroup;
  constructor(private route: ActivatedRoute, private mobileService: MobileService, private formBuilder: FormBuilder, private router: Router) {
    console.log("EditMobileComponent constructor")
    this.route.params.subscribe((params: Params) => {
      this.id = +params["id"]
    })
  }

  ngOnInit(): void {
    this.mobile = this.mobileService.getMobile(this.id);
    this.editMobileFormGroup = this.formBuilder.group({
      productName: [this.mobile.productName, Validators.required],
      price: [this.mobile.price, Validators.required],
      image: [this.mobile.image, Validators.required],
      description: [this.mobile.description],
      otherImages: this.formBuilder.array([])
    })
    // this.editMobileFormGroup.controls['otherImages'].setValue(this.mobile.otherImages)
    this.mobile.otherImages?.forEach((image, index) => {
      this.otherImages.push(this.formBuilder.control(image))
    })
  }
  get otherImages() {
    return this.editMobileFormGroup.get('otherImages') as FormArray;
  }
  addOtherImage() {
    this.otherImages.push(this.formBuilder.control(''));
  }
  onSubmit() {
    this.mobileService.updateMobile(this.id, this.editMobileFormGroup.value);
    this.onCancel();
  }
  onDelete(index: number) {
    this.otherImages.removeAt(index);
  }
  onCancel() {
    this.router.navigate(['/mobiles'])
  }
}
