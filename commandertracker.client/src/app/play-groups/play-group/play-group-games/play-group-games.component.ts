import { CommonModule } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { RouterLink } from '@angular/router';
import { Observable } from 'rxjs';
import { PlayGroupApiService } from 'src/app/core/api/play-group.api.service';
import { Game } from 'src/app/core/models/game.model';
import { GameFormDialogComponent } from 'src/app/shared/components/game-form-dialog/game-form-dialog.component';

@Component({
    selector: 'app-play-group-games',
    standalone: true,
    imports: [CommonModule, RouterLink],
    templateUrl: './play-group-games.component.html',
    styleUrl: './play-group-games.component.scss'
})
export class PlayGroupGamesComponent implements OnInit {
    @Input() playGroupId!: string;

    games$!: Observable<Game[]>;

    constructor(
        private playGroupApiService: PlayGroupApiService,
        private dialog: MatDialog
    ) {}

    ngOnInit(): void {
        this.games$ = this.getGames(this.playGroupId);
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
        return this.playGroupApiService.getGames(id);
    }
}
