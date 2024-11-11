import { CommonModule } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatDialog } from '@angular/material/dialog';
import { MatDividerModule } from '@angular/material/divider';
import { MatIconModule } from '@angular/material/icon';
import { RouterLink } from '@angular/router';
import { Observable } from 'rxjs';
import { PlayGroupApiService } from 'src/app/core/api/play-group.api.service';
import { BaseDeck } from 'src/app/core/models/deck.model';
import { PlayGroupDeck } from 'src/app/core/models/playGroupDeck.model';
import { DeckFormDialogComponent } from 'src/app/shared/components/deck-form-dialog/deck-form-dialog.component';
import { PageContainerComponent } from 'src/app/shared/components/page-container/page-container.component';
import { PageHeaderComponent } from 'src/app/shared/components/page-header/page-header.component';
import { PlayGroupDecksTableComponent } from './play-group-decks-table/play-group-decks-table.component';

@Component({
    selector: 'app-play-group-decks',
    standalone: true,
    imports: [
        CommonModule,
        RouterLink,
        MatButtonModule,
        MatIconModule,
        MatDividerModule,
        PageContainerComponent,
        PageHeaderComponent,
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

    temp() {
        // TODO
    }

    private getDecks(id: string): Observable<PlayGroupDeck[]> {
        return this.playGroupApiService.getDecks(id);
    }
}
