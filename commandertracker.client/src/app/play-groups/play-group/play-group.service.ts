import { Injectable } from '@angular/core';
import { Observable, shareReplay } from 'rxjs';
import { PlayGroup } from 'src/app/core/models/playGroup.model';

@Injectable()
export class PlayGroupService {
    private _playGroup$!: Observable<PlayGroup>;

    set playGroup$(playGroup$: Observable<PlayGroup>) {
        this._playGroup$ = playGroup$.pipe(shareReplay(1));
    }

    get playGroup$(): Observable<PlayGroup> {
        return this._playGroup$;
    }

    constructor() {}
}
