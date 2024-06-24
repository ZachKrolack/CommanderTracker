import { ModelId } from './utils';

type BaseAppUser = {
    userName: string;
};

export type AppUser = BaseAppUser & ModelId;
