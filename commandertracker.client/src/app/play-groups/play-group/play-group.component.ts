import { CommonModule } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { MatDividerModule } from '@angular/material/divider';
import { RouterOutlet } from '@angular/router';
import { Observable } from 'rxjs';
import { PlayGroupApiService } from 'src/app/core/api/play-group.api.service';
import { PlayGroup } from 'src/app/core/models/playGroup.model';
import { PageContainerComponent } from 'src/app/shared/components/page/page-container/page-container.component';
import { PageHeaderComponent } from 'src/app/shared/components/page/page-header/page-header.component';
import { PlayGroupNavComponent } from './play-group-nav/play-group-nav.component';
import { PlayGroupService } from './play-group.service';

@Component({
    selector: 'app-play-group',
    standalone: true,
    imports: [
        CommonModule,
        RouterOutlet,
        PlayGroupNavComponent,
        PageContainerComponent,
        PageHeaderComponent,
        MatDividerModule
    ],
    providers: [PlayGroupService],
    templateUrl: './play-group.component.html',
    styleUrl: './play-group.component.scss'
})
export class PlayGroupComponent implements OnInit {
    @Input() playGroupId!: string;

    playGroup$!: Observable<PlayGroup>;

    constructor(
        private playGroupApiService: PlayGroupApiService,
        private playGroupService: PlayGroupService
    ) {}

    ngOnInit(): void {
        this.playGroup$ = this.getPlayGroup(this.playGroupId);
        this.playGroupService.playGroup$ = this.playGroup$;
    }

    private getPlayGroup(id: string): Observable<PlayGroup> {
        return this.playGroupApiService.getPlayGroup(id);
    }
}
