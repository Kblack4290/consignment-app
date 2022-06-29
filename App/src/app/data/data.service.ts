import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, of } from 'rxjs';
import { FormSettings } from './form-settings';

@Injectable({
  providedIn: 'root',
})
export class DataService {
  constructor(private http: HttpClient) {}

  postFormSettings(formSettings: FormSettings): Observable<any> {
    const headers = { 'content-type': 'application/json' };
    const body = JSON.stringify(formSettings);
    console.log(body);

    return this.http
      .post('https://localhost:7219/api/Consignment', body, {
        headers,
      })
      .pipe(
        catchError((err) => {
          console.error(err);
          throw err;
        })
      );

    // return of(formSettings);
  }
}
