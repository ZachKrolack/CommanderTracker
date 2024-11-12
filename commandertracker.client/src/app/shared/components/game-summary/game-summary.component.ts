import { DatePipe } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { MatButton } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { RouterLink } from '@angular/router';
import { Game } from 'src/app/core/models/game.model';
import { PlayInstanceSummaryComponent } from './play-instance-summary/play-instance-summary.component';

@Component({
    selector: 'app-game-summary',
    standalone: true,
    imports: [
        MatCardModule,
        DatePipe,
        PlayInstanceSummaryComponent,
        MatButton,
        RouterLink
    ],
    templateUrl: './game-summary.component.html',
    styleUrl: './game-summary.component.scss'
})
export class GameSummaryComponent {
    @Input() game!: Game;

    @Output() deleted: EventEmitter<void> = new EventEmitter<void>();

    delete(): void {
        this.deleted.emit();
    }
}
