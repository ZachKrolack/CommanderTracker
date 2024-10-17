import { CommonModule } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { PlayGroupApiService } from 'src/app/core/api/play-group.api.service';
import { Game } from 'src/app/core/models/game.model';
import { GameCardComponent } from 'src/app/shared/components/game-card/game-card.component';

@Component({
    selector: 'app-play-group-game',
    standalone: true,
    imports: [CommonModule, GameCardComponent],
    templateUrl: './play-group-game.component.html',
    styleUrl: './play-group-game.component.scss'
})
export class PlayGroupGameComponent implements OnInit {
    @Input() playGroupId!: string;
    @Input() gameId!: string;

    game$!: Observable<Game>;

    constructor(private playGroupApiService: PlayGroupApiService) {}

    ngOnInit(): void {
        this.game$ = this.getGame(this.playGroupId, this.gameId);
    }

    private getGame(playGroupId: string, gameId: string): Observable<Game> {
        return this.playGroupApiService.getGame(playGroupId, gameId);
    }
}
