import { Deck } from './deck.model';
import { Game } from './game.model';
import { Pilot } from './pilot.model';
import { PlayGroup } from './playGroup.model';
import { BaseModel } from './utils';

type CorePlayInstance = {
    turnOrder: number;
    endPosition: number;
    notes: string;
};

type BasePlayInstance = BaseModel & CorePlayInstance;

type PlayInstance = BasePlayInstance & {
    deck: Deck;
    game: Game;
    pilot: Pilot;
    playGroup: PlayGroup;
};

export type DeckPlayInstance = Omit<PlayInstance, 'deck'>;
export type GamePlayInstance = Omit<PlayInstance, 'game'>;
export type PilotPlayInstance = Omit<PlayInstance, 'pilot'>;

export type PlayInstanceCreateRequest = CorePlayInstance & {
    deckId: string;
    pilotId: string;
    playGroupDeckId: string;
};
