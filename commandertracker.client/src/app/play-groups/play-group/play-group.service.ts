import { Injectable } from '@angular/core';
import { PlayGroup } from 'src/app/core/models/playGroup.model';

@Injectable()
export class PlayGroupService {
    playGroup!: PlayGroup;
}
