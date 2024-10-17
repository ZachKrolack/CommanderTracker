import { CommonModule } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { PlayGroupApiService } from 'src/app/core/api/play-group.api.service';
import { Pilot } from 'src/app/core/models/pilot.model';
import { GameCardComponent } from 'src/app/shared/components/game-card/game-card.component';

@Component({
    selector: 'app-play-group-pilot',
    standalone: true,
    imports: [CommonModule, GameCardComponent],
    templateUrl: './play-group-pilot.component.html',
    styleUrl: './play-group-pilot.component.scss'
})
export class PlayGroupPilotComponent implements OnInit {
    @Input() playGroupId!: string;
    @Input() pilotId!: string;

    pilot$!: Observable<Pilot>;

    constructor(private playGroupApiService: PlayGroupApiService) {}

    ngOnInit(): void {
        this.pilot$ = this.getPilot(this.playGroupId, this.pilotId);
    }

    private getPilot(playGroupId: string, pilotId: string): Observable<Pilot> {
        return this.playGroupApiService.getPilot(playGroupId, pilotId);
    }
}
