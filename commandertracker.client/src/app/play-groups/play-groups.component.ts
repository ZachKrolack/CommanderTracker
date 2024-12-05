import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatDialog } from '@angular/material/dialog';
import { MatDividerModule } from '@angular/material/divider';
import { MatIconModule } from '@angular/material/icon';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { Observable } from 'rxjs';
import { PlayGroupApiService } from '../core/api/play-group.api.service';
import { PlayGroup } from '../core/models/playGroup.model';
import { ConfirmationDialogComponent } from '../shared/components/confirmation-dialog/confirmation-dialog.component';
import { PageModule } from '../shared/components/page/page.module';
import { PlayGroupFormDialogComponent } from '../shared/components/play-group-form-dialog/play-group-form-dialog.component';
import { PlayGroupsTableComponent } from './play-groups-table/play-groups-table.component';

@Component({
    selector: 'app-play-groups',
    standalone: true,
    imports: [
        CommonModule,
        MatButtonModule,
        MatIconModule,
        MatDividerModule,
        MatProgressSpinnerModule,
        PageModule,
        PlayGroupsTableComponent
    ],
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

    openPlayGroupFormDialog(playGroup?: PlayGroup): void {
        const dialogRef = this.dialog.open<PlayGroupFormDialogComponent>(
            PlayGroupFormDialogComponent,
            { data: { playGroup } }
        );

        dialogRef.afterClosed().subscribe((shouldUpdate: boolean = false) => {
            if (shouldUpdate) {
                this.playGroups$ = this.getPlayGroups();
            }
        });
    }

    openDeletePlayGroupDialog(id: string): void {
        const dialogRef = this.dialog.open<
            ConfirmationDialogComponent,
            any, // TODO
            boolean
        >(ConfirmationDialogComponent, {});

        dialogRef.afterClosed().subscribe((shouldDelete: boolean = false) => {
            if (shouldDelete) {
                this.playGroupApiService.deletePlayGroup(id).subscribe(() => {
                    this.playGroups$ = this.getPlayGroups();
                });
            }
        });
    }

    private getPlayGroups(): Observable<PlayGroup[]> {
        return this.playGroupApiService.getPlayGroups();
    }
}
