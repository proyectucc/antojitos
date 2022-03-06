import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OpenVentaComponent } from './open-venta.component';

describe('OpenVentaComponent', () => {
  let component: OpenVentaComponent;
  let fixture: ComponentFixture<OpenVentaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OpenVentaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OpenVentaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
