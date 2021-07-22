import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FlashcardsHeaderComponent } from './flashcards-header.component';

describe('FlashcardsHeaderComponent', () => {
  let component: FlashcardsHeaderComponent;
  let fixture: ComponentFixture<FlashcardsHeaderComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FlashcardsHeaderComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FlashcardsHeaderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
