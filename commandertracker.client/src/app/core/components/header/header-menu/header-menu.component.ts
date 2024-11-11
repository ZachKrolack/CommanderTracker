import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { RouterLink, RouterLinkActive } from '@angular/router';

@Component({
    selector: 'app-header-menu',
    standalone: true,
    imports: [
        MatIconModule,
        MatButtonModule,
        MatMenuModule,
        RouterLink,
        RouterLinkActive
    ],
    templateUrl: './header-menu.component.html',
    styleUrl: './header-menu.component.scss'
})
export class HeaderMenuComponent {}
