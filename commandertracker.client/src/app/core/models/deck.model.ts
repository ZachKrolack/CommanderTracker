import { ColorIdentity } from '../enums/colorIdentity.enum';
import { BasePlayGroup } from './playGroup.model';
import { DeckPlayInstance } from './playInstance.model';
import { BaseModel, ModelId } from './utils';

type CoreDeck = {
    name: string;
    colorIdentity: ColorIdentity;
};

export type BaseDeck = BaseModel & CoreDeck;

export type Deck = BaseDeck & {
    playGroups: BasePlayGroup[];
    playInstances: DeckPlayInstance[];
};

export type DeckCreateRequest = CoreDeck;

export type DeckUpdateRequest = Partial<DeckCreateRequest> & ModelId;
