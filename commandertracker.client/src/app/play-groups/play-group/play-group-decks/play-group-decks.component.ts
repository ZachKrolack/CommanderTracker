import { CommonModule } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatDialog } from '@angular/material/dialog';
import { MatDividerModule } from '@angular/material/divider';
import { MatIconModule } from '@angular/material/icon';
import { Observable } from 'rxjs';
import { PlayGroupApiService } from 'src/app/core/api/play-group.api.service';
import { BaseDeck } from 'src/app/core/models/deck.model';
import { PlayGroupDeck } from 'src/app/core/models/playGroupDeck.model';
import { ConfirmationDialogComponent } from 'src/app/shared/components/confirmation-dialog/confirmation-dialog.component';
import { DeckFormDialogComponent } from 'src/app/shared/components/deck-form-dialog/deck-form-dialog.component';
import { PlayGroupDecksTableComponent } from './play-group-decks-table/play-group-decks-table.component';

@Component({
    selector: 'app-play-group-decks',
    standalone: true,
    imports: [
        CommonModule,
        MatButtonModule,
        MatIconModule,
        MatDividerModule,
        PlayGroupDecksTableComponent
    ],
    templateUrl: './play-group-decks.component.html',
    styleUrl: './play-group-decks.component.scss'
})
export class PlayGroupDecksComponent implements OnInit {
    @Input() playGroupId!: string;

    playGroupDecks$!: Observable<PlayGroupDeck[]>;

    constructor(
        private playGroupApiService: PlayGroupApiService,
        private dialog: MatDialog
    ) {}

    ngOnInit(): void {
        this.playGroupDecks$ = this.getDecks(this.playGroupId);
    }

    openDeckFormDialog(deck?: BaseDeck): void {
        const dialogRef = this.dialog.open<DeckFormDialogComponent>(
            DeckFormDialogComponent,
            { data: { playGroupId: this.playGroupId, deck } }
        );

        dialogRef.afterClosed().subscribe((shouldUpdate: boolean) => {
            if (shouldUpdate) {
                this.playGroupDecks$ = this.getDecks(this.playGroupId);
            }
        });
    }

    openRemoveDeckFromPlayGroupDialog(id: string): void {
        const dialogRef = this.dialog.open<
            ConfirmationDialogComponent,
            any,
            boolean
        >(ConfirmationDialogComponent, {});

        dialogRef.afterClosed().subscribe((shouldRemove: boolean = false) => {
            if (shouldRemove) {
                // TODO
            }
        });
    }

    private getDecks(id: string): Observable<PlayGroupDeck[]> {
        return this.playGroupApiService.getDecks(id);
    }
}
