import { Pipe, PipeTransform } from '@angular/core';
import { ColorIdentityMap } from 'src/app/core/constants/colorIdentity';
import {
    ColorIdentity,
    ColorIdentityStringWubrgOrder
} from 'src/app/core/enums/colorIdentity.enum';

@Pipe({
    name: 'toColorIdentityString',
    standalone: true
})
export class ToColorIdentityStringPipe implements PipeTransform {
    transform(colorIdentity: ColorIdentity): ColorIdentityStringWubrgOrder {
        return (
            ColorIdentityMap.getValue(colorIdentity) ??
            ColorIdentityStringWubrgOrder.Colorless
        );
    }
}
