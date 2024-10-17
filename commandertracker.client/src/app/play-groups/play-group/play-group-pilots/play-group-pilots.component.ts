import { CommonModule } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { RouterLink } from '@angular/router';
import { Observable } from 'rxjs';
import { PlayGroupApiService } from 'src/app/core/api/play-group.api.service';
import { Pilot } from 'src/app/core/models/pilot.model';
import { PilotFormDialogComponent } from 'src/app/shared/components/pilot-form-dialog/pilot-form-dialog.component';

@Component({
    selector: 'app-play-group-pilots',
    standalone: true,
    imports: [CommonModule, RouterLink],
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

    openPilotFormDialog(): void {
        const dialogRef = this.dialog.open(PilotFormDialogComponent, {
            data: { playGroupId: this.playGroupId }
        });

        dialogRef.afterClosed().subscribe((shouldUpdate: boolean) => {
            if (shouldUpdate) {
                this.pilots$ = this.getPilots(this.playGroupId);
            }
        });
    }

    private getPilots(id: string): Observable<Pilot[]> {
        return this.playGroupApiService.getPilots(id);
    }
}
