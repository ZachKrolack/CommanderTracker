import { CommonModule } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';
import { Observable } from 'rxjs';
import { PlayGroupApiService } from 'src/app/core/api/play-group.api.service';
import { PlayGroup } from 'src/app/core/models/playGroup.model';

@Component({
    selector: 'app-play-group',
    standalone: true,
    imports: [RouterOutlet, CommonModule, RouterLink],
    templateUrl: './play-group.component.html',
    styleUrl: './play-group.component.scss'
})
export class PlayGroupComponent implements OnInit {
    @Input() id!: string;

    playGroup$!: Observable<PlayGroup>;

    constructor(private playGroupApiService: PlayGroupApiService) {}

    ngOnInit(): void {
        this.playGroup$ = this.getPlayGroup(this.id);
    }

    private getPlayGroup(id: string): Observable<PlayGroup> {
        return this.playGroupApiService.getPlayGroup(id);
    }
}
