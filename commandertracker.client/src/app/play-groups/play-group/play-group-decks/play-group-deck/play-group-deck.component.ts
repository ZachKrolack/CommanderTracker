import { CommonModule } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { PlayGroupApiService } from 'src/app/core/api/play-group.api.service';
import { PlayGroupDeck } from 'src/app/core/models/playGroupDeck.model';
import { GameCardComponent } from 'src/app/shared/components/game-card/game-card.component';

@Component({
    selector: 'app-play-group-deck',
    standalone: true,
    imports: [CommonModule, GameCardComponent],
    templateUrl: './play-group-deck.component.html',
    styleUrl: './play-group-deck.component.scss'
})
export class PlayGroupDeckComponent implements OnInit {
    @Input() playGroupId!: string;
    @Input() deckId!: string;

    playGroupDeck$!: Observable<PlayGroupDeck>;

    constructor(private playGroupApiService: PlayGroupApiService) {}

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
        return this.playGroupApiService.getDeck(playGroupId, deckId);
    }
}
