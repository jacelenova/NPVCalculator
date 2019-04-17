import { RateValidatorDirective } from './rate-validator.directive';
import { ElementRef } from '@angular/core';

class MockElementRef implements ElementRef {
    nativeElement = {};
}

describe('RangeValidatorDirective', () => {
  it('should create an instance', () => {
    const directive = new RateValidatorDirective();
    expect(directive).toBeTruthy();
  });
});
