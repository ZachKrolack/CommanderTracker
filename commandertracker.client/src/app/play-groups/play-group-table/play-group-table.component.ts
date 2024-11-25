import { CommonModule } from '@angular/common';
import {
    AfterViewInit,
    Component,
    Input,
    OnInit,
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
    selector: 'app-play-group-table',
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
    templateUrl: './play-group-table.component.html',
    styleUrl: './play-group-table.component.scss'
})
export class PlayGroupTableComponent implements OnInit, AfterViewInit {
    @Input() playGroups!: PlayGroup[];
    dataSource!: MatTableDataSource<PlayGroup>;

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
}
