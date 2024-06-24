import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatDialog } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { MatTableModule } from '@angular/material/table';
import { RouterLink } from '@angular/router';
import { Observable } from 'rxjs';
import { PilotService } from '../core/api/pilot.service';
import { Pilot } from '../core/models/pilot.model';
import { StopPropagationDirective } from '../shared/directives/stop-propagation.directive';

@Component({
    selector: 'app-pilots',
    standalone: true,
    imports: [
        CommonModule,
        MatTableModule,
        MatButtonModule,
        MatIconModule,
        RouterLink,
        StopPropagationDirective
    ],
    templateUrl: './pilots.component.html',
    styleUrl: './pilots.component.scss'
})
export class PilotsComponent {
    pilots$!: Observable<Pilot[]>;

    displayedColumns: string[] = ['name', 'actions'];

    constructor(
        private pilotService: PilotService,
        private dialog: MatDialog
    ) {}

    ngOnInit(): void {
        this.pilots$ = this.getPilots();
    }

    openPilotFormDialog(pilot?: Pilot): void {
        // const dialogRef = this.dialog.open<
        //     PilotFormDialogComponent,
        //     PilotFormDialogData,
        //     Pilot | boolean
        // >(PilotFormDialogComponent, { data: { pilot } });
        // dialogRef.afterClosed().subscribe((pilotOrSucess?: Pilot | boolean) => {
        //     if (pilotOrSucess) {
        //         this.pilots$ = this.getPilots();
        //     }
        // });
    }

    openDeletePilotDialog(id: string): void {
        this.pilotService.deletePilot(id).subscribe(() => {
            this.pilots$ = this.getPilots();
        });
    }

    private getPilots(): Observable<Pilot[]> {
        return this.pilotService.getPilots();
    }
}
