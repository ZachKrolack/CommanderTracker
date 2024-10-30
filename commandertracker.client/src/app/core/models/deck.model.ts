import { ColorIdentity } from '../enums/colorIdentity.enum';
import { PlayGroupDeck } from './playGroupDeck.model';
import { BaseModel, ModelId } from './utils';

type CoreDeck = {
    name: string;
    colorIdentity: ColorIdentity;
};

export type BaseDeck = BaseModel & CoreDeck;

export type Deck = BaseDeck & {
    playGroupDecks: PlayGroupDeck[];
};

export type DeckCreateRequest = CoreDeck;

export type DeckUpdateRequest = Partial<DeckCreateRequest> & ModelId;
