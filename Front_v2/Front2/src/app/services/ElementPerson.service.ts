import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ElementPerson } from '../models/ElementPerson';

@Injectable()
export class ElementPersonService {
  elementApiUrl = "http://localhost:5000/api/Person"
  constructor(private http: HttpClient) { }

  getElements(): Observable<ElementPerson[]>{
      return this.http.get<ElementPerson[]>(this.elementApiUrl)
  }

  createElements(element: ElementPerson): Observable<ElementPerson>{
      return this.http.post<ElementPerson>(this.elementApiUrl, element)
  }

  editElement(element: ElementPerson): Observable<ElementPerson>{
      return this.http.put<ElementPerson>(this.elementApiUrl, element)
  }

  deleteElement(businessEntityID: number, phoneNumber: string, phoneNumberTypeID: number): Observable<any>{
      return this.http.delete<any>(`${this.elementApiUrl}, businessEntityID, phoneNumber, phoneNumberTypeID`)
  }
}