import { TestBed } from '@angular/core/testing';

import { CloseModalsService } from './close-modals.service';

describe('CloseModalsService', () => {
  let service: CloseModalsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CloseModalsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
