import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DevicesPerUserComponent } from './devices-per-user.component';

describe('DeviceTableComponent', () => {
  let component: DevicesPerUserComponent;
  let fixture: ComponentFixture<DevicesPerUserComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DevicesPerUserComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DevicesPerUserComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
