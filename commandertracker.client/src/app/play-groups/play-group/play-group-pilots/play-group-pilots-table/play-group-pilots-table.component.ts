import { CommonModule } from '@angular/common';
import {
    AfterViewInit,
    Component,
    EventEmitter,
    Input,
    OnInit,
    Output,
    ViewChild
} from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatSort, MatSortModule } from '@angular/material/sort';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { RouterLink } from '@angular/router';
import { Pilot } from 'src/app/core/models/pilot.model';

@Component({
    selector: 'app-play-group-pilots-table',
    standalone: true,
    imports: [
        CommonModule,
        MatButtonModule,
        MatTableModule,
        MatSortModule,
        RouterLink
    ],
    templateUrl: './play-group-pilots-table.component.html',
    styleUrl: './play-group-pilots-table.component.scss'
})
export class PlayGroupPilotsTableComponent implements OnInit, AfterViewInit {
    @Input() pilots!: Pilot[];
    dataSource!: MatTableDataSource<Pilot>;

    @Output() handleEditPilot: EventEmitter<Pilot> = new EventEmitter<Pilot>();
    @Output() handleDeletePilot: EventEmitter<string> =
        new EventEmitter<string>();

    displayedColumns: string[] = ['name', 'actions'];

    @ViewChild(MatSort) sort!: MatSort;

    constructor() {}

    ngOnInit(): void {
        this.dataSource = new MatTableDataSource<Pilot>(this.pilots);
    }

    ngAfterViewInit(): void {
        this.dataSource.sort = this.sort;
    }

    editPilot(pilot: Pilot): void {
        this.handleEditPilot.emit(pilot);
    }

    deletePilot(id: string): void {
        this.handleDeletePilot.emit(id);
    }
}
