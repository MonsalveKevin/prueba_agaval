import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TiposPersonaComponent } from './tiposPersona.component';

describe('TiposPersonaComponent', () => {
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
