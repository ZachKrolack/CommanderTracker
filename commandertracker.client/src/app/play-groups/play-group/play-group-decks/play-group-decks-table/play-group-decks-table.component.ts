import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatTableModule } from '@angular/material/table';
import { RouterLink } from '@angular/router';
import { BaseDeck } from 'src/app/core/models/deck.model';
import { PlayGroupDeck } from 'src/app/core/models/playGroupDeck.model';
import { ColorIdentityDisplayComponent } from 'src/app/shared/components/color-identity-display/color-identity-display.component';
import { ToColorIdentityStringPipe } from 'src/app/shared/pipes/to-color-identity-string.pipe';

@Component({
    selector: 'app-play-group-decks-table',
    standalone: true,
    imports: [
        CommonModule,
        MatTableModule,
        MatButtonModule,
        MatIconModule,
        RouterLink,
        ColorIdentityDisplayComponent,
        ToColorIdentityStringPipe
    ],
    templateUrl: './play-group-decks-table.component.html',
    styleUrl: './play-group-decks-table.component.scss'
})
export class PlayGroupDecksTableComponent {
    @Input() playGroupDecks!: PlayGroupDeck[];

    @Output() handleEditDeck: EventEmitter<BaseDeck> =
        new EventEmitter<BaseDeck>();
    @Output() handleRemoveDeckFromPlayGroup: EventEmitter<string> =
        new EventEmitter<string>();

    displayedColumns: string[] = ['name', 'colorIdentity', 'owner', 'actions'];

    constructor() {}

    editDeck(deck: BaseDeck): void {
        this.handleEditDeck.emit(deck);
    }

    removeDeckFromPlayGroup(deckId: string): void {
        this.handleRemoveDeckFromPlayGroup.emit(deckId);
    }
}
