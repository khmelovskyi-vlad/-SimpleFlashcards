import { TestBed } from '@angular/core/testing';

import { SmallFlashcardsApiService } from './small-flashcards-api.service';

describe('SmallFlashcardsApiService', () => {
  let service: SmallFlashcardsApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SmallFlashcardsApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
