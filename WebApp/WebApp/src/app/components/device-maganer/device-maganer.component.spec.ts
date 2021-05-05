import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeviceMaganerComponent } from './device-maganer.component';

describe('DeviceMaganerComponent', () => {
  let component: DeviceMaganerComponent;
  let fixture: ComponentFixture<DeviceMaganerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DeviceMaganerComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DeviceMaganerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
