import { CommonModule } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { GameApiService } from 'src/app/core/api/game.api.service';
import { Game } from 'src/app/core/models/game.model';
import { GameSummaryComponent } from 'src/app/shared/components/game-summary/game-summary.component';
import { PageModule } from 'src/app/shared/components/page/page.module';

@Component({
    selector: 'app-game',
    standalone: true,
    imports: [CommonModule, PageModule, GameSummaryComponent],
    templateUrl: './game.component.html',
    styleUrl: './game.component.scss'
})
export class GameComponent implements OnInit {
    @Input() id!: string;

    game$!: Observable<Game>;

    constructor(private gameApiService: GameApiService) {}

    ngOnInit(): void {
        this.game$ = this.getGame(this.id);
    }

    private getGame(id: string): Observable<Game> {
        return this.gameApiService.getUserGame(id);
    }
}
