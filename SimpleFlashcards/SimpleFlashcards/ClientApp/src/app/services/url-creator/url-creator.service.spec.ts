import { TestBed } from '@angular/core/testing';

import { UrlCreatorService } from './url-creator.service';

describe('UrlCreatorService', () => {
  let service: UrlCreatorService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(UrlCreatorService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
