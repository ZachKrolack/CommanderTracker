import { AppUser } from '../appUser.model';

export type ModelId = {
    id: string;
};

export type ModelDate = {
    createdDate: string;
    updatedDate: string;
};

export type BaseModel = ModelId & ModelDate & ModelCreatedBy;

export type ModelCreatedBy = {
    createdBy: AppUser;
};
