import { TestBed } from '@angular/core/testing';

import { OpenMainTopicModalService } from './open-main-topic-modal.service';

describe('OpenMainTopicModalService', () => {
  let service: OpenMainTopicModalService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(OpenMainTopicModalService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
