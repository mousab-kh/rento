import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VehicleCategorie } from './vehicle-categorie';

describe('VehicleCategorie', () => {
  let component: VehicleCategorie;
  let fixture: ComponentFixture<VehicleCategorie>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [VehicleCategorie]
    })
    .compileComponents();

    fixture = TestBed.createComponent(VehicleCategorie);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
