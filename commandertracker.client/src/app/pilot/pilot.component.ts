import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable, switchMap } from 'rxjs';
import { PilotService } from 'src/app/core/api/pilot.service';
import { Pilot } from 'src/app/core/models/pilot.model';
import { GameSummaryComponent } from 'src/app/shared/components/game-summary/game-summary.component';
import { PageContainerComponent } from '../shared/components/page-container/page-container.component';
import { PageHeaderComponent } from '../shared/components/page-header/page-header.component';

@Component({
    selector: 'app-pilot',
    standalone: true,
    imports: [
        CommonModule,
        PageContainerComponent,
        PageHeaderComponent,
        GameSummaryComponent
    ],
    templateUrl: './pilot.component.html',
    styleUrl: './pilot.component.scss'
})
export class PilotComponent implements OnInit {
    pilot$!: Observable<Pilot>;

    constructor(
        private pilotService: PilotService,
        private route: ActivatedRoute
    ) {}

    ngOnInit(): void {
        this.pilot$ = this.route.params.pipe(
            switchMap(({ id }) => this.getPilot(id))
        );
    }

    private getPilot(id: string): Observable<Pilot> {
        return this.pilotService.getPilot(id);
    }
}
