import { Component, OnInit } from '@angular/core';
import { PersonService } from '../../_services/person.service';
import { Person } from '../../_models/person';

@Component({
  selector: 'app-person',
  templateUrl: './person.component.html',
  styleUrls: ['./person.component.scss']
})

export class PersonComponent implements OnInit {

  persons : Person;

  constructor(private service : PersonService)
  {
  }

  ngOnInit() 
  {
    //this.service.ListAll().subscribe(response => this.persons = response)
  }

}
