import { Pipe, PipeTransform } from '@angular/core';
import { BaseModel } from 'src/app/core/models/utils';

@Pipe({
    name: 'isCreatedBy',
    standalone: true
})
export class IsCreatedByPipe implements PipeTransform {
    transform(model: BaseModel | null, userId: string | null): boolean {
        if (!model || !userId) return false;

        const createdById: string | null =
            model?.createdById ?? model?.createdBy?.id ?? null;

        if (!createdById) return false;

        return createdById === userId;
    }
}
