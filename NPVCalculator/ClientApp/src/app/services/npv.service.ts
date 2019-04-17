import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map } from 'rxjs/operators';

import { NPVQuery } from '../classes/npvquery';
import { Observable } from 'rxjs';

const httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
    providedIn: 'root'
})
export class NPVService {

    apiUrl = `${this.baseUrl}api`;

    constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

    computeNPV(query: NPVQuery): Observable<NPVQuery> {
        return this.http.post<NPVQuery>(`${this.apiUrl}/npv`, query, httpOptions);
    }

    getPreviousQueries(): Observable<Array<NPVQuery>> {
        return this.http.get<Array<NPVQuery>>(`${this.apiUrl}/npv`);
    }
}
