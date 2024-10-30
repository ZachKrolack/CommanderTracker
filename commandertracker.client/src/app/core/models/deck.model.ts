import { ColorIdentity } from '../enums/colorIdentity.enum';
import { PlayGroupDeck } from './playGroupDeck.model';
import { BaseModel, ModelId } from './utils';

export type BaseDeck = {
    name: string;
    colorIdentity: ColorIdentity;
};

export type Deck = BaseModel &
    BaseDeck & {
        playGroupDecks: PlayGroupDeck[];
    };

export type DeckCreateRequest = BaseDeck;

export type DeckUpdateRequest = Partial<DeckCreateRequest> & ModelId;
