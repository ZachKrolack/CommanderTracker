import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable, switchMap } from 'rxjs';
import { PilotApiService } from 'src/app/core/api/pilot.api.service';
import { Pilot } from 'src/app/core/models/pilot.model';
import { GameSummaryComponent } from 'src/app/shared/components/game-summary/game-summary.component';
import { PageModule } from '../shared/components/page/page.module';

@Component({
    selector: 'app-pilot',
    standalone: true,
    imports: [CommonModule, PageModule, GameSummaryComponent],
    templateUrl: './pilot.component.html',
    styleUrl: './pilot.component.scss'
})
export class PilotComponent implements OnInit {
    pilot$!: Observable<Pilot>;

    constructor(
        private pilotApiService: PilotApiService,
        private route: ActivatedRoute
    ) {}

    ngOnInit(): void {
        this.pilot$ = this.route.params.pipe(
            switchMap(({ id }) => this.getPilot(id))
        );
    }

    private getPilot(id: string): Observable<Pilot> {
        return this.pilotApiService.getPilot(id);
    }
}
