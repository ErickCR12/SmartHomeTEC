import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeviceTypesUsageComponent } from './device-types-usage.component';

describe('DeviceTypesUsageComponent', () => {
  let component: DeviceTypesUsageComponent;
  let fixture: ComponentFixture<DeviceTypesUsageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DeviceTypesUsageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DeviceTypesUsageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
