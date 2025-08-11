import { TestBed } from '@angular/core/testing';

import { BranchWorkingHourService } from './BranchWorkingHours-Service'

describe('BranchWorkingHourService', () => {
  let service: BranchWorkingHourService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BranchWorkingHourService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
