import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: 'isColorActive',
    standalone: true
})
export class IsColorActivePipe implements PipeTransform {
    transform(colorToCheck: string, colorIdentityString: string): boolean {
        return colorIdentityString
            .toLowerCase()
            .includes(colorToCheck.toLowerCase());
    }
}
