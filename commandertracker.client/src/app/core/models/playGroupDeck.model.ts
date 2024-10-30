import { BaseDeck } from './deck.model';
import { BasePlayGroup } from './playGroup.model';
import { DeckPlayInstance } from './playInstance.model';
import { BaseModel } from './utils';

export type BasePlayGroupDeck = BaseModel & {
    deck: BaseDeck;
    playGroup: BasePlayGroup;
};

export type PlayGroupDeck = BasePlayGroupDeck & {
    playInstances: DeckPlayInstance[];
};
