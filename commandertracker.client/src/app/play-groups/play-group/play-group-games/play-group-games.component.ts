import { CommonModule } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { PlayGroupApiService } from 'src/app/core/api/play-group.api.service';
import { Game } from 'src/app/core/models/game.model';

@Component({
    selector: 'app-play-group-games',
    standalone: true,
    imports: [CommonModule],
    templateUrl: './play-group-games.component.html',
    styleUrl: './play-group-games.component.scss'
})
export class PlayGroupGamesComponent implements OnInit {
    @Input() id!: string;

    games$!: Observable<Game[]>;

    constructor(private playGroupApiService: PlayGroupApiService) {}

    ngOnInit(): void {
        this.games$ = this.getGames(this.id);
    }

    private getGames(id: string): Observable<Game[]> {
        return this.playGroupApiService.getPlayGroupGames(id);
    }
}
