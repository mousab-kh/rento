import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VehicleManufacturer } from './vehicle-manufacturer';

describe('VehicleManufacturer', () => {
  let component: VehicleManufacturer;
  let fixture: ComponentFixture<VehicleManufacturer>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [VehicleManufacturer]
    })
    .compileComponents();

    fixture = TestBed.createComponent(VehicleManufacturer);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
