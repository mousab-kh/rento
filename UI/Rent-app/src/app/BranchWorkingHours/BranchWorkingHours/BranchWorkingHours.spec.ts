import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BranchWorkingHours } from './BranchWorkingHours';

describe('BranchWorkingHours', () => {
  let component: BranchWorkingHours;
  let fixture: ComponentFixture<BranchWorkingHours>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BranchWorkingHours]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BranchWorkingHours);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
