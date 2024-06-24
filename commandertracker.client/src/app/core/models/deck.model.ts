import { ColorIdentity } from '../enums/colorIdentity.enum';
import { BasePlayGroup } from './playGroup.model';
import { DeckPlayInstance } from './playInstance.model';
import { BaseModel, ModelId } from './utils';

export type BaseDeck = {
    name: string;
    colorIdentity: ColorIdentity;
};

export type Deck = BaseModel &
    BaseDeck & {
        playInstances: DeckPlayInstance[];
        playGroups: BasePlayGroup[];
    };

export type DeckCreateRequest = BaseDeck;

export type DeckUpdateRequest = Partial<DeckCreateRequest> & ModelId;
