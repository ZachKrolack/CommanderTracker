import { BasePlayGroup } from './playGroup.model';
import {
    GamePlayInstance,
    PlayInstanceCreateRequest
} from './playInstance.model';
import { BaseModel, ModelId } from './utils';

type BaseGame = {
    turns: number;
    notes: string;
};

export type Game = BaseModel &
    BaseGame & {
        playGroup: BasePlayGroup;
        playInstances: GamePlayInstance[];
    };

export type GameCreateRequest = BaseGame & {
    playInstances: PlayInstanceCreateRequest[];
};

export type GameUpdateRequest = Partial<GameCreateRequest> & ModelId;
