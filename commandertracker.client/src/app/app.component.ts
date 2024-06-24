import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatToolbarModule } from '@angular/material/toolbar';
import { Router, RouterLink, RouterOutlet } from '@angular/router';
import { AuthService } from './core/api/auth.service';

@Component({
    selector: 'app-root',
    standalone: true,
    imports: [
        RouterLink,
        RouterOutlet,
        MatToolbarModule,
        MatIconModule,
        MatButtonModule
    ],
    templateUrl: './app.component.html',
    styleUrl: './app.component.scss'
})
export class AppComponent {
    constructor(private authService: AuthService, private router: Router) {}

    logout(): void {
        this.authService.logout();
        this.router.navigate(['/login']);
    }
}
