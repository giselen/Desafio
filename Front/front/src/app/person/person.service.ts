import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {ResponsePerson} from './person.model'
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class PersonService {

  private url = "http://localhost:5000/api/Person"

  constructor(public http: HttpClient) { }

  getPerson(): Observable<ResponsePerson>{
    return this.http.get<ResponsePerson>(this.url);
  }
}
