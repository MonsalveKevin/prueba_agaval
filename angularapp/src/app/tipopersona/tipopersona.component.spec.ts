import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TipopersonaComponent } from './tipopersona.component';

describe('TipopersonaComponent', () => {
  let component: TipopersonaComponent;
  let fixture: ComponentFixture<TipopersonaComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TipopersonaComponent]
    });
    fixture = TestBed.createComponent(TipopersonaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
