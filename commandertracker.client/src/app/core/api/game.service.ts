import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import {
    Game,
    GameCreateRequest,
    GameUpdateRequest
} from '../models/game.model';

@Injectable({
    providedIn: 'root'
})
export class GameService {
    private readonly CONTROLLER_PATH = 'games';
    private readonly URL = `${environment.apiRoot}/${this.CONTROLLER_PATH}`;

    constructor(private http: HttpClient) {}

    getGames(): Observable<Game[]> {
        return this.http.get<Game[]>(`${this.URL}`);
    }

    createGame(game: GameCreateRequest): Observable<Game> {
        return this.http.post<Game>(`${this.URL}`, game);
    }

    getGame(id: string): Observable<Game> {
        return this.http.get<Game>(`${this.URL}/${id}`);
    }

    updateGame(id: string, game: GameUpdateRequest): Observable<void> {
        return this.http.put<void>(`${this.URL}/${id}`, game);
    }

    deleteGame(id: string): Observable<void> {
        return this.http.delete<void>(`${this.URL}/${id}`);
    }
}
