import { CommonModule } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatDialog } from '@angular/material/dialog';
import { MatDividerModule } from '@angular/material/divider';
import { MatIconModule } from '@angular/material/icon';
import { RouterLink } from '@angular/router';
import { Observable } from 'rxjs';
import { PlayGroupApiService } from 'src/app/core/api/play-group.api.service';
import { Pilot } from 'src/app/core/models/pilot.model';
import { PilotFormDialogComponent } from 'src/app/shared/components/pilot-form-dialog/pilot-form-dialog.component';
import { PlayGroupPilotsTableComponent } from './play-group-pilots-table/play-group-pilots-table.component';

@Component({
    selector: 'app-play-group-pilots',
    standalone: true,
    imports: [
        CommonModule,
        RouterLink,
        MatButtonModule,
        MatIconModule,
        MatDividerModule,
        PlayGroupPilotsTableComponent
    ],
    templateUrl: './play-group-pilots.component.html',
    styleUrl: './play-group-pilots.component.scss'
})
export class PlayGroupPilotsComponent implements OnInit {
    @Input() playGroupId!: string;

    pilots$!: Observable<Pilot[]>;

    constructor(
        private playGroupApiService: PlayGroupApiService,
        private dialog: MatDialog
    ) {}

    ngOnInit(): void {
        this.pilots$ = this.getPilots(this.playGroupId);
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

    temp() {
        // TODO
    }

    private getPilots(id: string): Observable<Pilot[]> {
        return this.playGroupApiService.getPilots(id);
    }
}
