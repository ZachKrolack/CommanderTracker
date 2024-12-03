import { Pipe, PipeTransform } from '@angular/core';
import { GamePlayInstance } from 'src/app/core/models/playInstance.model';

@Pipe({
    name: 'sortPlayInstances',
    standalone: true
})
export class SortPlayInstancesPipe implements PipeTransform {
    transform(playInstances: GamePlayInstance[]): GamePlayInstance[] {
        // TODO: handle ties
        return playInstances.sort((a, b) => a.endPosition - b.endPosition);
    }
}
