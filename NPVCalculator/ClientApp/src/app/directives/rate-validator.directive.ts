import { Directive, Input, ViewChild, ElementRef } from '@angular/core';
import { NG_VALIDATORS, AbstractControl, ValidationErrors, FormControl, NgModel, NgControl, NgForm } from '@angular/forms';

@Directive({
    selector: '[appRateValidator]',
    providers: [{provide: NG_VALIDATORS, useExisting: RateValidatorDirective, multi: true}]
})
export class RateValidatorDirective {
    // tslint:disable-next-line:no-input-rename
    @Input('appRateValidator') form: NgForm;
    @Input() low: string;
    @Input() high: string;

    constructor() { }

    validate(): ValidationErrors {
        if (this.form) {
            const lowControl = this.form.controls[this.low];
            const upperControl = this.form.controls[this.high];

            if (lowControl && upperControl) {
                if (lowControl.value > upperControl.value) {
                    console.log('error');
                    lowControl.setErrors({ rateValidation: 'Rate validation failed.' });
                    lowControl.markAsTouched();
                    upperControl.setErrors({ rateValidation: 'Rate validation failed.' });
                    upperControl.markAsTouched();
                } else {
                    if (lowControl.hasError('rateValidation')) {
                        lowControl.setErrors({'rateValidation': null});
                        lowControl.updateValueAndValidity();
                    }
                    if (upperControl.hasError('rateValidation')) {
                        upperControl.setErrors({'rateValidation': null});
                        upperControl.updateValueAndValidity();
                    }
                }
            }
        }
        return null;
    }
}
