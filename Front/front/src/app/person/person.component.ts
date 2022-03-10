import { Component, OnInit } from '@angular/core';
import { Person } from './person.model';
import { PersonService } from './person.service';


@Component({
  selector: 'app-person',
  templateUrl: './person.component.html',
  styleUrls: ['./person.component.css']
})
export class PersonComponent implements OnInit {

  //person: Person

  constructor(private personService: PersonService ) { }

  ngOnInit(): void {
    this.personService.getPerson()
    //.subscribe(res => this.person = res )
  }

}
