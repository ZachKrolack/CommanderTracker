import { Pipe, PipeTransform } from '@angular/core';
import { PlayGroupDeck } from 'src/app/core/models/playGroupDeck.model';
import { DeckPlayInstance } from 'src/app/core/models/playInstance.model';

@Pipe({
    name: 'playInstanceAggregator',
    standalone: true
})
export class PlayInstanceAggregatorPipe implements PipeTransform {
    transform(playGroupDecks: PlayGroupDeck[]): DeckPlayInstance[] {
        return playGroupDecks.flatMap((pgd) => pgd.playInstances);
    }
}
