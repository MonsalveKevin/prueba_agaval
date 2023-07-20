import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TiposPersonaComponent } from './tipospersona.component';

describe('TipospersonaComponent', () => {
  let component: TiposPersonaComponent;
  let fixture: ComponentFixture<TiposPersonaComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TiposPersonaComponent]
    });
    fixture = TestBed.createComponent(TiposPersonaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
