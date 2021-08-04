import { TestBed } from '@angular/core/testing';

import { SubtopicsApiService } from './subtopics-api.service';

describe('SubtopicsApiService', () => {
  let service: SubtopicsApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SubtopicsApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
