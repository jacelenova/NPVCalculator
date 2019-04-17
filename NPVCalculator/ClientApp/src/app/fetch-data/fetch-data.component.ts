import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NPVQuery } from '../classes/npvquery';
import { NPVService } from '../services/npv.service';
import { Observable } from 'rxjs/internal/Observable';

@Component({
    selector: 'app-fetch-data',
    templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent implements OnInit  {
    public queries: Observable<Array<NPVQuery>>;

    constructor(private npvService: NPVService, @Inject('BASE_URL') baseUrl: string, http: HttpClient) { }

    ngOnInit() {
        this.queries = this.npvService.getPreviousQueries();
    }
}
