import { Component, OnInit } from '@angular/core';
import { PersonComponent } from '../person/person.component';
import { Person } from 'src/app/_models/person';
import { PersonService } from 'src/app/_services/person.service';

@Component({
  selector: 'app-person-insert',
  templateUrl: './person-insert.component.html',
  styleUrls: ['./person-insert.component.scss']
})
export class PersonInsertComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

  onSubmit(name : string, surname : string)
  {
    console.log("dupa");
    let person = new Person();
    person.Name = name;
    person.Surname = surname;
    alert("duppa");
  }

}
