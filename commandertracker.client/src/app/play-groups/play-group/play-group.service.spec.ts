import { TestBed } from '@angular/core/testing';

import { PlayGroupService } from './play-group.service';

describe('PlayGroupService', () => {
  let service: PlayGroupService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PlayGroupService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
