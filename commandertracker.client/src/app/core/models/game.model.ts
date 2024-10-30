import { BasePlayGroup } from './playGroup.model';
import {
    GamePlayInstance,
    PlayInstanceCreateRequest
} from './playInstance.model';
import { BaseModel, ModelId } from './utils';

type CoreGame = {
    turns: number;
    notes: string;
};

export type BaseGame = BaseModel & CoreGame;

export type Game = BaseGame & {
    playGroup: BasePlayGroup;
    playInstances: GamePlayInstance[];
};

export type GameCreateRequest = CoreGame & {
    playInstances: PlayInstanceCreateRequest[];
};

export type GameUpdateRequest = Partial<GameCreateRequest> & ModelId;
