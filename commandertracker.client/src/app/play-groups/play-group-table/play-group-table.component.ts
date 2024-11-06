import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';
import { RouterLink } from '@angular/router';
import { PlayGroup } from 'src/app/core/models/playGroup.model';

@Component({
    selector: 'app-play-group-table',
    standalone: true,
    imports: [CommonModule, MatTableModule, MatButtonModule, RouterLink],
    templateUrl: './play-group-table.component.html',
    styleUrl: './play-group-table.component.scss'
})
export class PlayGroupTableComponent {
    @Input() playGroups!: PlayGroup[];

    displayedColumns: string[] = ['name'];

    constructor() {}
}
