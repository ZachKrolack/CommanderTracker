import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatDialog } from '@angular/material/dialog';
import { MatDividerModule } from '@angular/material/divider';
import { MatIconModule } from '@angular/material/icon';
import { Observable } from 'rxjs';
import { DeckApiService } from '../core/api/deck.api.service';
import { Deck } from '../core/models/deck.model';
import { ConfirmationDialogComponent } from '../shared/components/confirmation-dialog/confirmation-dialog.component';
import {
    DeckFormDialogComponent,
    DeckFormDialogData
} from '../shared/components/deck-form-dialog/deck-form-dialog.component';
import { DecksTableComponent } from '../shared/components/decks-table/decks-table.component';
import { PageContainerComponent } from '../shared/components/page-container/page-container.component';
import { PageHeaderComponent } from '../shared/components/page-header/page-header.component';

@Component({
    selector: 'app-decks',
    standalone: true,
    imports: [
        CommonModule,
        MatButtonModule,
        MatIconModule,
        MatDividerModule,
        PageContainerComponent,
        PageHeaderComponent,
        DecksTableComponent
    ],
    templateUrl: './decks.component.html',
    styleUrl: './decks.component.scss'
})
export class DecksComponent implements OnInit {
    decks$!: Observable<Deck[]>;

    constructor(
        private deckApiService: DeckApiService,
        private dialog: MatDialog
    ) {}

    ngOnInit(): void {
        this.decks$ = this.getDecks();
    }

    openDeckFormDialog(deck?: Deck): void {
        const dialogRef = this.dialog.open<
            DeckFormDialogComponent,
            DeckFormDialogData,
            boolean
        >(DeckFormDialogComponent, {
            data: { deck },
            width: 'auto',
            height: 'auto',
            maxWidth: '60vw',
            maxHeight: '80vh'
        });

        dialogRef.afterClosed().subscribe((shouldUpdate: boolean = false) => {
            if (shouldUpdate) {
                this.decks$ = this.getDecks();
            }
        });
    }

    openDeleteDeckDialog(id: string): void {
        const dialogRef = this.dialog.open<
            ConfirmationDialogComponent,
            any,
            boolean
        >(ConfirmationDialogComponent, {});

        dialogRef.afterClosed().subscribe((shouldDelete: boolean = false) => {
            if (shouldDelete) {
                this.deckApiService.deleteDeck(id).subscribe(() => {
                    this.decks$ = this.getDecks();
                });
            }
        });
    }

    private getDecks(): Observable<Deck[]> {
        return this.deckApiService.getDecks();
    }
}
