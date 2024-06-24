import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../api/auth.service';

@Injectable({
    providedIn: 'root'
})
export class NoAuthGuard {
    constructor(private authService: AuthService, private router: Router) {}

    canActivate(): boolean {
        if (!this.authService.isAuthenticated()) {
            return true;
        } else {
            this.router.navigate(['/']);
            return false;
        }
    }
}
