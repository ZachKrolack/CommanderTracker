import { Deck } from './deck.model';
import { BasePilot } from './pilot.model';
import { PlayGroup } from './playGroup.model';
import { DeckPlayInstance } from './playInstance.model';
import { BaseModel } from './utils';

export type PlayGroupDeck = BaseModel & {
    deck: Deck;
    playGroup: PlayGroup;
    pilot?: BasePilot;
    playInstances: DeckPlayInstance[];
};
