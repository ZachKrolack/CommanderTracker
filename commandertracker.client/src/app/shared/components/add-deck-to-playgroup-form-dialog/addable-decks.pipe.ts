import { Pipe, PipeTransform } from '@angular/core';
import { BaseDeck } from 'src/app/core/models/deck.model';
import { PlayGroupDeck } from 'src/app/core/models/playGroupDeck.model';

@Pipe({
    name: 'addableDecks',
    standalone: true
})
export class AddableDecksPipe implements PipeTransform {
    transform(decks: BaseDeck[], playGroupDecks: PlayGroupDeck[]): BaseDeck[] {
        const existingDeckIds: Set<string> = new Set<string>(
            playGroupDecks.map((pgd) => pgd.deck.id)
        );

        return decks.filter((deck) => !existingDeckIds.has(deck.id));
    }
}
