import { CommonModule } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { GameService } from 'src/app/core/api/game.service';
import { Game } from 'src/app/core/models/game.model';
import { GameCardComponent } from 'src/app/shared/components/game-card/game-card.component';

@Component({
    selector: 'app-game',
    standalone: true,
    imports: [CommonModule, GameCardComponent],
    templateUrl: './game.component.html',
    styleUrl: './game.component.scss'
})
export class GameComponent implements OnInit {
    @Input() id!: string;

    game$!: Observable<Game>;

    constructor(private gameService: GameService) {}

    ngOnInit(): void {
        this.game$ = this.getGame(this.id);
    }

    private getGame(id: string): Observable<Game> {
        return this.gameService.getGame(id);
    }
}
