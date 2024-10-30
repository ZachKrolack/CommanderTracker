import { Game } from './game.model';
import { Pilot } from './pilot.model';
import { PlayGroupDeck } from './playGroupDeck.model';
import { BaseModel } from './utils';

type CorePlayInstance = {
    turnOrder: number;
    endPosition: number;
    notes: string;
};

type BasePlayInstance = BaseModel & CorePlayInstance;

type PlayInstance = BasePlayInstance & {
    playGroupDeck: PlayGroupDeck;
    game: Game;
    pilot: Pilot;
};

export type DeckPlayInstance = Omit<PlayInstance, 'playGroupDeck'>;
export type GamePlayInstance = Omit<PlayInstance, 'game'>;
export type PilotPlayInstance = Omit<PlayInstance, 'pilot'>;

export type PlayInstanceCreateRequest = CorePlayInstance & {
    playGroupDeckId: string;
    pilotId: string;
};
