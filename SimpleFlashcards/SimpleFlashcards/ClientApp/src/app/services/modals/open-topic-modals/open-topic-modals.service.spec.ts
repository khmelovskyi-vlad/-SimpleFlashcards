import { TestBed } from '@angular/core/testing';

import { OpenTopicModalsService } from './open-topic-modals.service';

describe('OpenTopicModalsService', () => {
  let service: OpenTopicModalsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(OpenTopicModalsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
