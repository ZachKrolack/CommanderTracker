import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/core/api/auth.service';

@Component({
    selector: 'app-account-menu',
    standalone: true,
    imports: [MatIconModule, MatButtonModule, MatMenuModule],
    templateUrl: './account-menu.component.html',
    styleUrl: './account-menu.component.scss'
})
export class AccountMenuComponent {
    constructor(private router: Router, private authService: AuthService) {}

    logout(): void {
        this.authService.logout();
        this.router.navigate(['/login']);
    }
}
