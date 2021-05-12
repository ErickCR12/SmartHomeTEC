import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DevicesPerRegionComponent } from './devices-per-region.component';

describe('DevicesPerRegionComponent', () => {
  let component: DevicesPerRegionComponent;
  let fixture: ComponentFixture<DevicesPerRegionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DevicesPerRegionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DevicesPerRegionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
