import { PilotRole } from '../enums/pilotRole.enum';
import { BasePlayGroup } from './playGroup.model';
import { PilotPlayInstance } from './playInstance.model';
import { BaseModel, ModelId } from './utils';

type CorePilot = {
    name: string;
    role: PilotRole;
};

export type BasePilot = BaseModel & CorePilot;

export type Pilot = BasePilot & {
    playGroup: BasePlayGroup;
    playInstances: PilotPlayInstance[];
};

export type PilotCreateRequest = Omit<CorePilot, 'role'>; // TODO

export type PilotUpdateRequest = Partial<PilotCreateRequest> & ModelId;
