import { BaseDeck } from './deck.model';
import { BasePilot } from './pilot.model';
import { DeckPlayInstance } from './playInstance.model';
import { BaseModel } from './utils';

export type PlayGroupDeck = BaseModel & {
    deck: BaseDeck;
    pilot: BasePilot;
    playInstances: DeckPlayInstance[];
};
