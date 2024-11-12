import { CommonModule } from '@angular/common';
import {
    AfterViewInit,
    Component,
    Input,
    OnInit,
    ViewChild
} from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatSort, MatSortModule } from '@angular/material/sort';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { RouterLink } from '@angular/router';
import { PlayGroup } from 'src/app/core/models/playGroup.model';

@Component({
    selector: 'app-play-group-table',
    standalone: true,
    imports: [
        CommonModule,
        MatTableModule,
        MatSortModule,
        MatButtonModule,
        RouterLink
    ],
    templateUrl: './play-group-table.component.html',
    styleUrl: './play-group-table.component.scss'
})
export class PlayGroupTableComponent implements OnInit, AfterViewInit {
    @Input() playGroups!: PlayGroup[];
    dataSource!: MatTableDataSource<PlayGroup>;

    displayedColumns: string[] = ['name'];

    @ViewChild(MatSort) sort!: MatSort;

    constructor() {}

    ngOnInit(): void {
        this.dataSource = new MatTableDataSource<PlayGroup>(this.playGroups);
    }

    ngAfterViewInit(): void {
        this.dataSource.sort = this.sort;
    }
}
