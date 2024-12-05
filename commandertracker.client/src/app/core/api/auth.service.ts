import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { jwtDecode } from 'jwt-decode';
import { Observable, tap } from 'rxjs';
import { environment } from 'src/environments/environment';
import { API_CONSTANTS } from '../constants/api';
import {
    EXPIRES_LOCAL_STORAGE_KEY,
    TOKEN_LOCAL_STORAGE_KEY
} from '../constants/localStorageKeys';
import {
    AppUserClaims,
    LoginRequest,
    RegisterRequest,
    TokenResponse
} from '../models/auth.model';

@Injectable({
    providedIn: 'root'
})
export class AuthService {
    private readonly ROOT = `${environment.apiRoot}`;
    private readonly REGISTER = API_CONSTANTS.REGISTER_URL;
    private readonly LOGIN = API_CONSTANTS.LOGIN_URL;

    private get appUserClaims(): AppUserClaims | null {
        return this.getAppUserClaims();
    }

    get userId(): string | null {
        return this.appUserClaims?.sub ?? null;
    }

    constructor(private http: HttpClient) {}

    register(request: RegisterRequest): Observable<TokenResponse> {
        return this.http
            .post<TokenResponse>(`${this.ROOT}/${this.REGISTER}`, request)
            .pipe(tap((res) => this.setSession(res)));
    }

    login(request: LoginRequest): Observable<TokenResponse> {
        return this.http
            .post<TokenResponse>(`${this.ROOT}/${this.LOGIN}`, request)
            .pipe(tap((res) => this.setSession(res)));
    }

    logout(): void {
        this.clearSession();
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

    private clearSession(): void {
        localStorage.removeItem(TOKEN_LOCAL_STORAGE_KEY);
        localStorage.removeItem(EXPIRES_LOCAL_STORAGE_KEY);
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

    private parseToken(token: string): AppUserClaims {
        return jwtDecode<AppUserClaims>(token);
    }

    private getAppUserClaims(): AppUserClaims | null {
        const token = this.getToken();

        if (!token) return null;

        return this.parseToken(token);
    }
}
