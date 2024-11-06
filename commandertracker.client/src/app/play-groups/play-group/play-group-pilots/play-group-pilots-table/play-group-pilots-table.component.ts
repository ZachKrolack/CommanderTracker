import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';
import { RouterLink } from '@angular/router';
import { Pilot } from 'src/app/core/models/pilot.model';

@Component({
    selector: 'app-play-group-pilots-table',
    standalone: true,
    imports: [CommonModule, MatButtonModule, MatTableModule, RouterLink],
    templateUrl: './play-group-pilots-table.component.html',
    styleUrl: './play-group-pilots-table.component.scss'
})
export class PlayGroupPilotsTableComponent {
    @Input() pilots!: Pilot[];

    @Output() handleEditPilot: EventEmitter<Pilot> = new EventEmitter<Pilot>();
    @Output() handleDeletePilot: EventEmitter<string> =
        new EventEmitter<string>();

    displayedColumns: string[] = ['name', 'actions'];

    editPilot(pilot: Pilot): void {
        this.handleEditPilot.emit(pilot);
    }

    deletePilot(id: string): void {
        this.handleDeletePilot.emit(id);
    }
}
