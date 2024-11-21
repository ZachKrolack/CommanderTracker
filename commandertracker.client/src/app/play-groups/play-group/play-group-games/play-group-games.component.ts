import { CommonModule } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatDialog } from '@angular/material/dialog';
import { MatDividerModule } from '@angular/material/divider';
import { MatIconModule } from '@angular/material/icon';
import { Observable } from 'rxjs';
import { AuthService } from 'src/app/core/api/auth.service';
import { GameApiService } from 'src/app/core/api/game.api.service';
import { Game } from 'src/app/core/models/game.model';
import { PlayGroup } from 'src/app/core/models/playGroup.model';
import { GameFormDialogComponent } from 'src/app/shared/components/game-form-dialog/game-form-dialog.component';
import { GameSummaryComponent } from 'src/app/shared/components/game-summary/game-summary.component';
import { IsCreatedByPipe } from 'src/app/shared/pipes/is-created-by.pipe';
import { PlayGroupService } from '../play-group.service';

@Component({
    selector: 'app-play-group-games',
    standalone: true,
    imports: [
        CommonModule,
        MatButtonModule,
        MatIconModule,
        MatDividerModule,
        GameSummaryComponent,
        IsCreatedByPipe
    ],
    templateUrl: './play-group-games.component.html',
    styleUrl: './play-group-games.component.scss'
})
export class PlayGroupGamesComponent implements OnInit {
    @Input() playGroupId!: string;

    userId: string | null = null;
    games$!: Observable<Game[]>;
    playGroup$!: Observable<PlayGroup>;

    constructor(
        private playGroupService: PlayGroupService,
        private gameApiService: GameApiService,
        private authService: AuthService,
        private dialog: MatDialog
    ) {}

    ngOnInit(): void {
        this.userId = this.authService.userId;
        this.games$ = this.getGames(this.playGroupId);
        this.playGroup$ = this.playGroupService.playGroup$;
    }

    openGameFormDialog(): void {
        const dialogRef = this.dialog.open<GameFormDialogComponent>(
            GameFormDialogComponent,
            { data: { playGroupId: this.playGroupId } }
        );

        dialogRef.afterClosed().subscribe((shouldUpdate) => {
            if (shouldUpdate) {
                this.games$ = this.getGames(this.playGroupId);
            }
        });
    }

    private getGames(id: string): Observable<Game[]> {
        return this.gameApiService.getGames(id);
    }
}
