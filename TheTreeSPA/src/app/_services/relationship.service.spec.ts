import { TestBed } from '@angular/core/testing';

import { RelationshipService } from './relationship.service';

describe('RelationshpService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: RelationshipService = TestBed.get(RelationshipService);
    expect(service).toBeTruthy();
  });
});
