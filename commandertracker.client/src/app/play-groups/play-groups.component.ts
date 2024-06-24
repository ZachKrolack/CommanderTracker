import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatDialog } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { RouterLink } from '@angular/router';
import { Observable } from 'rxjs';
import { PlayGroupApiService } from '../core/api/play-group.api.service';
import { PlayGroup } from '../core/models/playGroup.model';
import { PlayGroupFormDialogComponent } from '../shared/components/play-group-form-dialog/play-group-form-dialog.component';

@Component({
    selector: 'app-play-groups',
    standalone: true,
    imports: [CommonModule, MatButtonModule, MatIconModule, RouterLink],
    templateUrl: './play-groups.component.html',
    styleUrl: './play-groups.component.scss'
})
export class PlayGroupsComponent implements OnInit {
    playGroups$!: Observable<PlayGroup[]>;

    constructor(
        private playGroupApiService: PlayGroupApiService,
        private dialog: MatDialog
    ) {}

    ngOnInit(): void {
        this.playGroups$ = this.getPlayGroups();
    }

    openPlayGroupFormDialog(): void {
        const dialogRef = this.dialog.open<PlayGroupFormDialogComponent>(
            PlayGroupFormDialogComponent
        );

        dialogRef.afterClosed().subscribe((shouldUpdate: boolean = false) => {
            if (shouldUpdate) {
                this.playGroups$ = this.getPlayGroups();
            }
        });
    }

    private getPlayGroups(): Observable<PlayGroup[]> {
        return this.playGroupApiService.getPlayGroups();
    }
}
