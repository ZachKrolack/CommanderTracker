import { CommonModule } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { MatDividerModule } from '@angular/material/divider';
import { RouterOutlet } from '@angular/router';
import { Observable } from 'rxjs';
import { PlayGroupApiService } from 'src/app/core/api/play-group.api.service';
import { PlayGroup } from 'src/app/core/models/playGroup.model';
import { PageModule } from 'src/app/shared/components/page/page.module';
import { PlayGroupNavComponent } from './play-group-nav/play-group-nav.component';
import { PlayGroupService } from './play-group.service';

@Component({
    selector: 'app-play-group',
    standalone: true,
    imports: [
        CommonModule,
        RouterOutlet,
        PlayGroupNavComponent,
        PageModule,
        MatDividerModule
    ],
    providers: [PlayGroupService],
    templateUrl: './play-group.component.html',
    styleUrl: './play-group.component.scss'
})
export class PlayGroupComponent implements OnInit {
    @Input() playGroupId!: string;

    playGroup!: PlayGroup;

    constructor(
        private playGroupApiService: PlayGroupApiService,
        private playGroupService: PlayGroupService
    ) {}

    ngOnInit(): void {
        this.getPlayGroup(this.playGroupId).subscribe((playGroup) => {
            /**
             * Set PlayGroup in local service so play group child routes
             * can access play group data without re-fetching.
             */
            this.playGroupService.playGroup = playGroup;
            this.playGroup = playGroup;
        });
    }

    private getPlayGroup(playGroupId: string): Observable<PlayGroup> {
        return this.playGroupApiService.getPlayGroup(playGroupId);
    }
}
