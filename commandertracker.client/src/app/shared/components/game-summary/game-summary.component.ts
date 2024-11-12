import { DatePipe } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { RouterLink } from '@angular/router';
import { Game } from 'src/app/core/models/game.model';
import { PlayInstanceSummaryComponent } from './play-instance-summary/play-instance-summary.component';

@Component({
    selector: 'app-game-summary',
    standalone: true,
    imports: [DatePipe, PlayInstanceSummaryComponent, RouterLink],
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
