import { DatePipe } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { MatButton } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { RouterLink } from '@angular/router';
import { Game } from 'src/app/core/models/game.model';
import { GamePlayInstanceCardComponent } from '../game-play-instance-card/game-play-instance-card.component';

@Component({
    selector: 'app-game-card',
    standalone: true,
    imports: [
        MatCardModule,
        DatePipe,
        GamePlayInstanceCardComponent,
        MatButton,
        RouterLink
    ],
    templateUrl: './game-card.component.html',
    styleUrl: './game-card.component.scss'
})
export class GameCardComponent {
    @Input() game!: Game;

    @Output() deleted: EventEmitter<void> = new EventEmitter<void>();

    delete(): void {
        this.deleted.emit();
    }
}
