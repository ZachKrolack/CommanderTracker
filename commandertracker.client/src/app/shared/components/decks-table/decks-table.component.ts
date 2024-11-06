import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatTableModule } from '@angular/material/table';
import { RouterLink } from '@angular/router';
import { Deck } from 'src/app/core/models/deck.model';
import { ToColorIdentityStringPipe } from '../../pipes/to-color-identity-string.pipe';
import { ColorIdentityDisplayComponent } from '../color-identity-display/color-identity-display.component';

@Component({
    selector: 'app-decks-table',
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
    templateUrl: './decks-table.component.html',
    styleUrl: './decks-table.component.scss'
})
export class DecksTableComponent {
    @Input() decks!: Deck[];

    @Output() handleEditDeck: EventEmitter<Deck> = new EventEmitter<Deck>();
    @Output() handleDeleteDeck: EventEmitter<string> =
        new EventEmitter<string>();

    displayedColumns: string[] = ['name', 'colorIdentity', 'actions'];

    constructor() {}

    editDeck(deck: Deck): void {
        this.handleEditDeck.emit(deck);
    }

    deleteDeck(id: string): void {
        this.handleDeleteDeck.emit(id);
    }
}
