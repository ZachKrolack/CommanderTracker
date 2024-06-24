import { TestBed } from '@angular/core/testing';

import { PlayGroupApiService } from './play-group.api.service';

describe('PlayGroupApiService', () => {
    let service: PlayGroupApiService;

    beforeEach(() => {
        TestBed.configureTestingModule({});
        service = TestBed.inject(PlayGroupApiService);
    });

    it('should be created', () => {
        expect(service).toBeTruthy();
    });
});
