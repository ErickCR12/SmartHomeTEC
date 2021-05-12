import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeviceListTableComponent } from './device-list-table.component';

describe('UsageTableComponent', () => {
  let component: DeviceListTableComponent;
  let fixture: ComponentFixture<DeviceListTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DeviceListTableComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DeviceListTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
