import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {Person} from './person.model'
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class PersonService {

  private url = "http://localhost:5000/api/Person"
  constructor(private http: HttpClient) { }

  getPerson(): Observable<Person>{
    return this.http.get<Person>(this.url);
  }
}
