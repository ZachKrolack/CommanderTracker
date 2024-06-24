import { Deck } from './deck.model';
import { Game } from './game.model';
import { Pilot } from './pilot.model';
import { BaseModel } from './utils';

type BasePlayInstance = {
    turnOrder: number;
    endPosition: number;
    notes: string;
};

type PlayInstance = BaseModel &
    BasePlayInstance & {
        deck: Deck;
        game: Game;
        pilot: Pilot;
    };

export type DeckPlayInstance = Omit<PlayInstance, 'deck'>;
export type GamePlayInstance = Omit<PlayInstance, 'game'>;
export type PilotPlayInstance = Omit<PlayInstance, 'pilot'>;

export type PlayInstanceCreateRequest = BasePlayInstance & {
    deckId: string;
    pilotId: string;
};
