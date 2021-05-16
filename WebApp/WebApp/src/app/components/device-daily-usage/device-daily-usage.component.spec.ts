import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeviceDailyUsageComponent } from './device-daily-usage.component';

describe('DeviceDailyUsageComponent', () => {
  let component: DeviceDailyUsageComponent;
  let fixture: ComponentFixture<DeviceDailyUsageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DeviceDailyUsageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DeviceDailyUsageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
