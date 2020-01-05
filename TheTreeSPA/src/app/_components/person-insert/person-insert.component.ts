import { Component, OnInit } from '@angular/core';
import { PersonComponent } from '../person/person.component';
import { Person } from 'src/app/_models/person';
import { PersonService } from 'src/app/_services/person.service';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-person-insert',
  templateUrl: './person-insert.component.html',
  styleUrls: ['./person-insert.component.scss']
})

export class PersonInsertComponent implements OnInit 
{
  nameControl : FormControl;

  constructor(private service : PersonService) 
  {
  }

  ngOnInit() {}

  onSubmit(name : string, surname : string)
  {
    alert('chuj');
    let p = new Person();
    p.ParenthoodId = 1;
    p.Name = name;
    p.Surname = surname;
    p.Id = 2;
    this.Add(p);
  }

  public Add(person : Person)
  {
    this.service.Add(person).subscribe();
  }

}
