import { Component, OnInit } from '@angular/core';
import { RelationshipService } from '../../_services/relationship.service';
import { Relationship } from '../../_models/relationship';

@Component({
  selector: 'app-relationship',
  templateUrl: './relationship.component.html',
  styleUrls: ['./relationship.component.scss']
})
export class RelationshipComponent implements OnInit 
{

  relationships : Relationship;

  constructor(private service : RelationshipService) 
  { }

  ngOnInit() 
  {
    this.service.ListAll().subscribe(response => this.relationships = response);
  }

}
