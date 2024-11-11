import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatDialog } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { Observable } from 'rxjs';
import { GameService } from '../core/api/game.service';
import { Game } from '../core/models/game.model';
import {
    GameFormDialogComponent,
    GameFormDialogData
} from '../shared/components/game-form-dialog/game-form-dialog.component';
import { GameSummaryComponent } from '../shared/components/game-summary/game-summary.component';
import { PageContainerComponent } from '../shared/components/page-container/page-container.component';
import { PageHeaderComponent } from '../shared/components/page-header/page-header.component';

@Component({
    selector: 'app-games',
    standalone: true,
    imports: [
        CommonModule,
        MatButtonModule,
        MatIconModule,
        PageContainerComponent,
        PageHeaderComponent,
        GameSummaryComponent
    ],
    templateUrl: './games.component.html',
    styleUrl: './games.component.scss'
})
export class GamesComponent implements OnInit {
    games$!: Observable<Game[]>;

    displayedColumns: string[] = ['game'];

    constructor(private gameService: GameService, private dialog: MatDialog) {}

    ngOnInit(): void {
        this.games$ = this.getGames();
    }

    openGameFormDialog(): void {
        const dialogRef = this.dialog.open<
            GameFormDialogComponent,
            GameFormDialogData,
            boolean
        >(GameFormDialogComponent);

        dialogRef.afterClosed().subscribe((shouldUpdate: boolean = false) => {
            if (shouldUpdate) {
                this.games$ = this.getGames();
            }
        });
    }

    deleteGame(id: string): void {
        this.gameService.deleteGame(id).subscribe(() => {
            this.games$ = this.getGames();
        });
    }

    private getGames(): Observable<Game[]> {
        return this.gameService.getGames();
    }
}
