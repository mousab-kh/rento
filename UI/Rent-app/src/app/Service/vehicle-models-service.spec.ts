import { TestBed } from '@angular/core/testing';

import { VehicleModels } from './vehicle-models-service';

describe('VehicleModels', () => {
  let service: VehicleModels;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(VehicleModels);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
