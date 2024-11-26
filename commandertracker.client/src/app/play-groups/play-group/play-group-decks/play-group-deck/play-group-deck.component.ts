import { CommonModule } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { MatDividerModule } from '@angular/material/divider';
import { Observable } from 'rxjs';
import { DeckApiService } from 'src/app/core/api/deck.api.service';
import { PlayGroupDeck } from 'src/app/core/models/playGroupDeck.model';
import { GameSummaryComponent } from 'src/app/shared/components/game-summary/game-summary.component';
import { PageHeaderComponent } from 'src/app/shared/components/page/page-header/page-header.component';

@Component({
    selector: 'app-play-group-deck',
    standalone: true,
    imports: [
        CommonModule,
        MatDividerModule,
        PageHeaderComponent,
        GameSummaryComponent
    ],
    templateUrl: './play-group-deck.component.html',
    styleUrl: './play-group-deck.component.scss'
})
export class PlayGroupDeckComponent implements OnInit {
    @Input() playGroupId!: string;
    @Input() deckId!: string;

    playGroupDeck$!: Observable<PlayGroupDeck>;

    constructor(private deckApiService: DeckApiService) {}

    ngOnInit(): void {
        this.playGroupDeck$ = this.getPlayGroupDeck(
            this.playGroupId,
            this.deckId
        );
    }

    private getPlayGroupDeck(
        playGroupId: string,
        deckId: string
    ): Observable<PlayGroupDeck> {
        return this.deckApiService.getPlayGroupDeck(playGroupId, deckId);
    }
}
