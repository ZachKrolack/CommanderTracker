import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatDialog } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { MatTableModule } from '@angular/material/table';
import { RouterLink } from '@angular/router';
import { Observable } from 'rxjs';
import { DeckService } from '../core/api/deck.service';
import { Deck } from '../core/models/deck.model';
import { ColorIdentityDisplayComponent } from '../shared/components/color-identity-display/color-identity-display.component';
import {
    DeckFormDialogComponent,
    DeckFormDialogData
} from '../shared/components/deck-form-dialog/deck-form-dialog.component';
import { StopPropagationDirective } from '../shared/directives/stop-propagation.directive';
import { ToColorIdentityStringPipe } from '../shared/pipes/to-color-identity-string.pipe';

@Component({
    selector: 'app-decks',
    standalone: true,
    imports: [
        CommonModule,
        MatTableModule,
        MatButtonModule,
        MatIconModule,
        RouterLink,
        StopPropagationDirective,
        ColorIdentityDisplayComponent,
        ToColorIdentityStringPipe
    ],
    templateUrl: './decks.component.html',
    styleUrl: './decks.component.scss'
})
export class DecksComponent implements OnInit {
    decks$!: Observable<Deck[]>;

    displayedColumns: string[] = ['name', 'colorIdentity', 'actions'];

    constructor(private deckService: DeckService, private dialog: MatDialog) {}

    ngOnInit(): void {
        this.decks$ = this.getDecks();
    }

    openDeckFormDialog(deck?: Deck): void {
        const dialogRef = this.dialog.open<
            DeckFormDialogComponent,
            DeckFormDialogData,
            boolean
        >(DeckFormDialogComponent, { data: { deck } });

        dialogRef.afterClosed().subscribe((shouldUpdate: boolean = false) => {
            if (shouldUpdate) {
                this.decks$ = this.getDecks();
            }
        });
    }

    openDeleteDeckDialog(id: string): void {
        this.deckService.deleteDeck(id).subscribe(() => {
            this.decks$ = this.getDecks();
        });
    }

    private getDecks(): Observable<Deck[]> {
        return this.deckService.getDecks();
    }
}