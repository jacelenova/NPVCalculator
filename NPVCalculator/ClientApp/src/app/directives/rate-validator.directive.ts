import { Directive, Input } from '@angular/core';
import { NG_VALIDATORS, AbstractControl, ValidationErrors } from '@angular/forms';

@Directive({
    selector: '[appRateValidator]',
    providers: [{provide: NG_VALIDATORS, useExisting: RateValidatorDirective, multi: true}]
})
export class RateValidatorDirective {
    // tslint:disable-next-line:no-input-rename
    @Input('appRateValidator') rateValidator: void;
    @Input() low: number;
    @Input() high: number;

    constructor() { }

    validate(control: AbstractControl): ValidationErrors {
        if (this.low > this.high) {
            return { rateValidation: 'Rate validation failed.' };
        }
        return null;
    }
}
