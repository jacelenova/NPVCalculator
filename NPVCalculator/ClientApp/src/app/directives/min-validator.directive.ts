import { Directive, Input } from '@angular/core';
import { NgModel, AbstractControl, ValidationErrors, NG_VALIDATORS } from '@angular/forms';

enum MinMax {
    Min = 0,
    Max = 1
}

@Directive({
    selector: '[appMinValidator]',
    providers: [{provide: NG_VALIDATORS, useExisting: MinValidatorDirective, multi: true}]
})
export class MinValidatorDirective {
    @Input('appMinValidator') appMinValidator: MinMax;
    @Input() exclude = false;
    @Input() model: NgModel;
    constructor() { }

    validate(control: AbstractControl): ValidationErrors {
        if ((this.exclude && control.value <= this.appMinValidator) || control.value < this.appMinValidator) {
            return { minValidation: 'Min validation failed.' };
        }
        return null;
    }

}
