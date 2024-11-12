import { Component, Input } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { RouterLink } from '@angular/router';
import { GamePlayInstance } from 'src/app/core/models/playInstance.model';
import { ToColorIdentityStringPipe } from 'src/app/shared/pipes/to-color-identity-string.pipe';
import { ColorIdentityDisplayComponent } from '../../color-identity-display/color-identity-display.component';

@Component({
    selector: 'app-play-instance-summary',
    standalone: true,
    imports: [
        MatCardModule,
        RouterLink,
        ColorIdentityDisplayComponent,
        ToColorIdentityStringPipe
    ],
    templateUrl: './play-instance-summary.component.html',
    styleUrl: './play-instance-summary.component.scss'
})
export class PlayInstanceSummaryComponent {
    @Input() playInstance!: GamePlayInstance;
}
