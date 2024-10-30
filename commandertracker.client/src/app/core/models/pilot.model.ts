import { BasePlayGroup } from './playGroup.model';
import { PilotPlayInstance } from './playInstance.model';
import { BaseModel, ModelId } from './utils';

type CorePilot = {
    name: string;
};

export type BasePilot = BaseModel & CorePilot;

export type Pilot = BasePilot & {
    playGroup: BasePlayGroup;
    playInstances: PilotPlayInstance[];
};

export type PilotCreateRequest = CorePilot;

export type PilotUpdateRequest = Partial<PilotCreateRequest> & ModelId;
