import { TestBed } from '@angular/core/testing';

import { NPVService } from './npv.service';
import {HttpClientTestingModule} from '@angular/common/http/testing';

describe('NPVService', () => {
    beforeEach(() => TestBed.configureTestingModule({
        imports: [HttpClientTestingModule],
        providers: [NPVService, { provide: 'BASE_URL', useValue: '' }]
    }));

    it('should be created', () => {
        const service: NPVService = TestBed.get(NPVService);
        expect(service).toBeTruthy();
    });
});
