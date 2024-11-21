import { CommonModule } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatDialog } from '@angular/material/dialog';
import { MatDividerModule } from '@angular/material/divider';
import { MatIconModule } from '@angular/material/icon';
import { Observable } from 'rxjs';
import { AuthService } from 'src/app/core/api/auth.service';
import { PilotApiService } from 'src/app/core/api/pilot.api.service';
import { Pilot } from 'src/app/core/models/pilot.model';
import { PlayGroup } from 'src/app/core/models/playGroup.model';
import { ConfirmationDialogComponent } from 'src/app/shared/components/confirmation-dialog/confirmation-dialog.component';
import { PilotFormDialogComponent } from 'src/app/shared/components/pilot-form-dialog/pilot-form-dialog.component';
import { IsCreatedByPipe } from 'src/app/shared/pipes/is-created-by.pipe';
import { PlayGroupService } from '../play-group.service';
import { PlayGroupPilotsTableComponent } from './play-group-pilots-table/play-group-pilots-table.component';

@Component({
    selector: 'app-play-group-pilots',
    standalone: true,
    imports: [
        CommonModule,
        MatButtonModule,
        MatIconModule,
        MatDividerModule,
        PlayGroupPilotsTableComponent,
        IsCreatedByPipe
    ],
    templateUrl: './play-group-pilots.component.html',
    styleUrl: './play-group-pilots.component.scss'
})
export class PlayGroupPilotsComponent implements OnInit {
    @Input() playGroupId!: string;

    userId: string | null = null;
    pilots$!: Observable<Pilot[]>;
    playGroup$!: Observable<PlayGroup>;

    constructor(
        private playGroupService: PlayGroupService,
        private pilotApiService: PilotApiService,
        private authService: AuthService,
        private dialog: MatDialog
    ) {}

    ngOnInit(): void {
        this.userId = this.authService.userId;
        this.pilots$ = this.getPilots(this.playGroupId);
        this.playGroup$ = this.playGroupService.playGroup$;
    }

    openPilotFormDialog(pilot?: Pilot): void {
        const dialogRef = this.dialog.open(PilotFormDialogComponent, {
            data: { playGroupId: this.playGroupId, pilot }
        });

        dialogRef.afterClosed().subscribe((shouldUpdate: boolean) => {
            if (shouldUpdate) {
                this.pilots$ = this.getPilots(this.playGroupId);
            }
        });
    }

    openDeletePilotDialog(id: string): void {
        const dialogRef = this.dialog.open<
            ConfirmationDialogComponent,
            any, // TODO
            boolean
        >(ConfirmationDialogComponent, {});

        dialogRef.afterClosed().subscribe((shouldDelete: boolean = false) => {
            if (shouldDelete) {
                this.pilotApiService
                    .deletePilot(this.playGroupId, id)
                    .subscribe(() => {
                        this.pilots$ = this.getPilots(this.playGroupId);
                    });
            }
        });
    }

    private getPilots(id: string): Observable<Pilot[]> {
        return this.pilotApiService.getPilots(id);
    }
}
