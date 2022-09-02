
import { AbstractControl } from '@angular/forms';

export function EmailValidation(value: string) {
  return (control: AbstractControl) => {
    if (control.value === value) {
      control.setErrors({ sameEmail: true });
      return { sameEmail: true }
    } else {
      control.setErrors(null);
      // control.setErrors({ sameEmail: true });
      return null;
    }
  }
}
// export function EmailValidation(value: string): ValidatorFn {
//   return (control: AbstractControl): ValidationErrors | null => {
//     const forbidden = control.value === value;
//     return forbidden ? { sameEmail: true } : null;
//   };
// }

