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
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { MatSort, MatSortModule } from '@angular/material/sort';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { RouterLink } from '@angular/router';
import { AuthService } from 'src/app/core/api/auth.service';
import { PlayGroup } from 'src/app/core/models/playGroup.model';
import { IsCreatedByPipe } from 'src/app/shared/pipes/is-created-by.pipe';

@Component({
    selector: 'app-play-groups-table',
    standalone: true,
    imports: [
        CommonModule,
        MatTableModule,
        MatSortModule,
        MatMenuModule,
        MatButtonModule,
        MatIconModule,
        RouterLink,
        IsCreatedByPipe
    ],
    templateUrl: './play-groups-table.component.html',
    styleUrl: './play-groups-table.component.scss'
})
export class PlayGroupsTableComponent implements OnInit, AfterViewInit {
    @Input() playGroups!: PlayGroup[];
    dataSource!: MatTableDataSource<PlayGroup>;

    @Output() handleEditPlayGroup: EventEmitter<PlayGroup> =
        new EventEmitter<PlayGroup>();
    @Output() handleDeletePlayGroup: EventEmitter<string> =
        new EventEmitter<string>();

    userId: string | null = null;

    displayedColumns: string[] = ['name', 'actions'];

    @ViewChild(MatSort) sort!: MatSort;

    constructor(private authService: AuthService) {}

    ngOnInit(): void {
        this.userId = this.authService.userId;
        this.dataSource = new MatTableDataSource<PlayGroup>(this.playGroups);
    }

    ngAfterViewInit(): void {
        this.dataSource.sort = this.sort;
    }

    editPlayGroup(playGroup: PlayGroup): void {
        this.handleEditPlayGroup.emit(playGroup);
    }

    deletePlayGroup(id: string): void {
        this.handleDeletePlayGroup.emit(id);
    }
}
