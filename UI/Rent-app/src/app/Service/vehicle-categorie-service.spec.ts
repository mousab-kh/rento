import { TestBed } from '@angular/core/testing';

import { VehicleCategorieService } from './vehicle-categorie-service';

describe('VehicleCategorieService', () => {
  let service: VehicleCategorieService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(VehicleCategorieService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
