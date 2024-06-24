import { Component, Input } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { RouterLink } from '@angular/router';
import { GamePlayInstance } from 'src/app/core/models/playInstance.model';
import { ToColorIdentityStringPipe } from '../../pipes/to-color-identity-string.pipe';
import { ColorIdentityDisplayComponent } from '../color-identity-display/color-identity-display.component';

@Component({
    selector: 'app-game-play-instance-card',
    standalone: true,
    imports: [
        MatCardModule,
        RouterLink,
        ColorIdentityDisplayComponent,
        ToColorIdentityStringPipe
    ],
    templateUrl: './game-play-instance-card.component.html',
    styleUrl: './game-play-instance-card.component.scss'
})
export class GamePlayInstanceCardComponent {
    @Input() playInstance!: GamePlayInstance;
}
