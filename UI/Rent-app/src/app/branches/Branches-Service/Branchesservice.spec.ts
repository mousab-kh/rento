import { TestBed } from '@angular/core/testing';

import { BranchesService } from '../../branches/Branches-Service/Branchesservice';

describe('BranchesService', () => {
  let service: BranchesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BranchesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
