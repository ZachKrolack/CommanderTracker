import { Game } from './game.model';
import { Pilot } from './pilot.model';
import { PlayGroupDeck } from './playGroupDeck.model';
import { BaseModel, ModelCreatedBy, ModelId } from './utils';

type CorePlayGroup = {
    name: string;
};

export type BasePlayGroup = BaseModel & CorePlayGroup;

export type PlayGroup = BasePlayGroup &
    ModelCreatedBy & {
        decks: PlayGroupDeck[];
        games: Game[];
        pilots: Pilot[];
    };

export type PlayGroupCreateRequest = CorePlayGroup;

export type PlayGroupUpdateRequest = Partial<PlayGroupCreateRequest> & ModelId;
