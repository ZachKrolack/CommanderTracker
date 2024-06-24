import { BasePlayGroup } from './playGroup.model';
import { PilotPlayInstance } from './playInstance.model';
import { BaseModel, ModelId } from './utils';

export type BasePilot = {
    name: string;
};

export type Pilot = BaseModel &
    BasePilot & {
        playGroup: BasePlayGroup;
        playInstances: PilotPlayInstance[];
    };

export type PilotCreateRequest = BasePilot;

export type PilotUpdateRequest = Partial<PilotCreateRequest> & ModelId;
