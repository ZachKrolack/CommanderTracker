import { Component } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';

@Component({
    selector: 'app-play-group-nav',
    standalone: true,
    imports: [RouterLink, RouterLinkActive],
    templateUrl: './play-group-nav.component.html',
    styleUrl: './play-group-nav.component.scss'
})
export class PlayGroupNavComponent {}
