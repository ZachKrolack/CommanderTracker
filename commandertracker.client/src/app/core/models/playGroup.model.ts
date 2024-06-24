import { Game } from './game.model';
import { Pilot } from './pilot.model';
import { PlayGroupDeck } from './playGroupDeck.model';
import { BaseModel, ModelCreatedBy, ModelId } from './utils';

export type BasePlayGroup = {
    name: string;
};

export type PlayGroup = BaseModel &
    BasePlayGroup &
    ModelCreatedBy & {
        decks: PlayGroupDeck[];
        games: Game[];
        pilots: Pilot[];
    };

export type PlayGroupCreateRequest = BasePlayGroup;

export type PlayGroupUpdateRequest = Partial<PlayGroupCreateRequest> & ModelId;
