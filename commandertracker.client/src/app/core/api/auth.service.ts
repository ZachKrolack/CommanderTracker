import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, tap } from 'rxjs';
import { environment } from 'src/environments/environment';
import {
    EXPIRES_LOCAL_STORAGE_KEY,
    TOKEN_LOCAL_STORAGE_KEY
} from '../constants/localStorageKeys';
import {
    LoginRequest,
    RegisterRequest,
    TokenResponse
} from '../models/auth.model';

@Injectable({
    providedIn: 'root'
})
export class AuthService {
    private readonly URL = `${environment.apiRoot}`;

    constructor(private http: HttpClient) {}

    register(request: RegisterRequest): Observable<TokenResponse> {
        return this.http
            .post<TokenResponse>(`${this.URL}/register`, request)
            .pipe(tap((res) => this.setSession(res)));
    }

    login(request: LoginRequest): Observable<TokenResponse> {
        return this.http
            .post<TokenResponse>(`${this.URL}/login`, request)
            .pipe(tap((res) => this.setSession(res)));
    }

    logout(): void {
        localStorage.removeItem(TOKEN_LOCAL_STORAGE_KEY);
        localStorage.removeItem(EXPIRES_LOCAL_STORAGE_KEY);
    }

    isAuthenticated(): boolean {
        const token = this.getToken();
        const expires = this.getExpires();

        if (!(token && expires)) return false;

        if (this.isExpired(expires)) return false;

        return true;
    }

    private setSession(tokenRes: TokenResponse): void {
        try {
            localStorage.setItem(TOKEN_LOCAL_STORAGE_KEY, tokenRes.token);
            localStorage.setItem(
                EXPIRES_LOCAL_STORAGE_KEY,
                JSON.stringify(new Date(tokenRes.expires).getTime())
            );
        } catch (error: any) {
            // TODO
        }
    }

    private getToken(): string | null {
        return localStorage.getItem(TOKEN_LOCAL_STORAGE_KEY);
    }

    private getExpires(): number | null {
        const expires = localStorage.getItem(EXPIRES_LOCAL_STORAGE_KEY);

        if (!expires) return null;

        return parseInt(expires, 10) ?? null;
    }

    private isExpired(expires: number): boolean {
        return expires < Date.now();
    }
}
