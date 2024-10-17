import { CommonModule } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { RouterLink } from '@angular/router';
import { Observable } from 'rxjs';
import { PlayGroupApiService } from 'src/app/core/api/play-group.api.service';
import { PlayGroupDeck } from 'src/app/core/models/playGroupDeck.model';
import { DeckFormDialogComponent } from 'src/app/shared/components/deck-form-dialog/deck-form-dialog.component';

@Component({
    selector: 'app-play-group-decks',
    standalone: true,
    imports: [CommonModule, RouterLink],
    templateUrl: './play-group-decks.component.html',
    styleUrl: './play-group-decks.component.scss'
})
export class PlayGroupDecksComponent implements OnInit {
    @Input() playGroupId!: string;

    decks$!: Observable<PlayGroupDeck[]>;

    constructor(
        private playGroupApiService: PlayGroupApiService,
        private dialog: MatDialog
    ) {}

    ngOnInit(): void {
        this.decks$ = this.getDecks(this.playGroupId);
    }

    openDeckFormDialog(): void {
        const dialogRef = this.dialog.open<DeckFormDialogComponent>(
            DeckFormDialogComponent,
            { data: { playGroupId: this.playGroupId } }
        );

        dialogRef.afterClosed().subscribe((shouldUpdate: boolean) => {
            if (shouldUpdate) {
                this.decks$ = this.getDecks(this.playGroupId);
            }
        });
    }

    private getDecks(id: string): Observable<PlayGroupDeck[]> {
        return this.playGroupApiService.getDecks(id);
    }
}
