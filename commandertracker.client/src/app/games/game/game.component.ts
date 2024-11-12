import { CommonModule } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { GameService } from 'src/app/core/api/game.service';
import { Game } from 'src/app/core/models/game.model';
import { GameSummaryComponent } from 'src/app/shared/components/game-summary/game-summary.component';
import { PageContainerComponent } from 'src/app/shared/components/page-container/page-container.component';
import { PageHeaderComponent } from 'src/app/shared/components/page-header/page-header.component';

@Component({
    selector: 'app-game',
    standalone: true,
    imports: [
        CommonModule,
        PageContainerComponent,
        PageHeaderComponent,
        GameSummaryComponent
    ],
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
