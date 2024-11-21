import { AppUser } from '../appUser.model';

export type ModelId = {
    id: string;
};

export type ModelDate = {
    createdDate: string;
    updatedDate: string;
};

export type ModelCreatedBy = {
    createdById: string;
    createdBy: AppUser;
};

export type ModelUpdatedBy = {
    updatedById: string;
    updatedBy: AppUser;
};

export type BaseModel = ModelId & ModelDate & ModelCreatedBy & ModelUpdatedBy;
