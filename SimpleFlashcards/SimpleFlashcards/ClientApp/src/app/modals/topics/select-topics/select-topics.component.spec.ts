import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SelectTopicsComponent } from './select-topics.component';

describe('SelectTopicsComponent', () => {
  let component: SelectTopicsComponent;
  let fixture: ComponentFixture<SelectTopicsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SelectTopicsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SelectTopicsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
