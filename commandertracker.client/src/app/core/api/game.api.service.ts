import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { API_CONSTANTS } from '../constants/api';
import {
    Game,
    GameCreateRequest,
    GameUpdateRequest
} from '../models/game.model';

@Injectable({
    providedIn: 'root'
})
export class GameApiService {
    private readonly ROOT = `${environment.apiRoot}`;
    private readonly PLAY_GROUPS = API_CONSTANTS.PLAY_GROUPS_URL;
    private readonly GAMES = API_CONSTANTS.GAMES_URL;

    constructor(private http: HttpClient) {}

    getUserGames(): Observable<Game[]> {
        return this.http.get<Game[]>(`${this.ROOT}/${this.GAMES}`);
    }

    getGames(playGroupId: string): Observable<Game[]> {
        return this.http.get<Game[]>(
            `${this.ROOT}/${this.PLAY_GROUPS}/${playGroupId}/${this.GAMES}`
        );
    }

    getUserGame(gameId: string): Observable<Game> {
        return this.http.get<Game>(`${this.ROOT}/${this.GAMES}/${gameId}`);
    }

    getGame(playGroupId: string, gameId: string): Observable<Game> {
        return this.http.get<Game>(
            `${this.ROOT}/${this.PLAY_GROUPS}/${playGroupId}/${this.GAMES}`
        );
    }

    createGame(playGroupId: string, game: GameCreateRequest): Observable<Game> {
        return this.http.post<Game>(
            `${this.ROOT}/${this.PLAY_GROUPS}/${playGroupId}/${this.GAMES}`,
            game
        );
    }

    updateGame(
        playGroupId: string,
        gameId: string,
        game: GameUpdateRequest
    ): Observable<void> {
        return this.http.put<void>(
            `${this.ROOT}/${this.PLAY_GROUPS}/${playGroupId}/${this.GAMES}/${gameId}`,
            game
        );
    }

    deleteGame(playGroupId: string, gameId: string): Observable<void> {
        return this.http.delete<void>(
            `${this.ROOT}/${this.PLAY_GROUPS}/${playGroupId}/${this.GAMES}/${gameId}`
        );
    }
}
