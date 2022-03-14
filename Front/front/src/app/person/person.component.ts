import { Component, OnInit } from '@angular/core';
import { ResponsePerson } from './person.model';
import { PersonService } from './person.service';


@Component({
  selector: 'app-person',
  templateUrl: './person.component.html',
  styleUrls: ['./person.component.css']
})
export class PersonComponent implements OnInit {

  //responsePerson: ResponsePerson

  constructor(private personService: PersonService ) { }

  ngOnInit() {
    this.personService.getPerson()
    //.subscribe(res => this.responsePerson = res )
  }

}
