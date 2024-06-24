import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Deck, DeckCreateRequest } from '../models/deck.model';
import { Game } from '../models/game.model';
import { Pilot, PilotCreateRequest } from '../models/pilot.model';
import {
    PlayGroup,
    PlayGroupCreateRequest,
    PlayGroupUpdateRequest
} from '../models/playGroup.model';
import { PlayGroupDeck } from '../models/playGroupDeck.model';

@Injectable({
    providedIn: 'root'
})
export class PlayGroupApiService {
    private readonly CONTROLLER_PATH = 'play-groups';
    private readonly URL = `${environment.apiRoot}/${this.CONTROLLER_PATH}`;

    constructor(private http: HttpClient) {}

    getPlayGroups(): Observable<PlayGroup[]> {
        return this.http.get<PlayGroup[]>(`${this.URL}`);
    }

    createPlayGroup(playGroup: PlayGroupCreateRequest): Observable<PlayGroup> {
        return this.http.post<PlayGroup>(`${this.URL}`, playGroup);
    }

    getPlayGroup(id: string): Observable<PlayGroup> {
        return this.http.get<PlayGroup>(`${this.URL}/${id}`);
    }

    updatePlayGroup(
        id: string,
        playGroup: PlayGroupUpdateRequest
    ): Observable<void> {
        return this.http.put<void>(`${this.URL}/${id}`, playGroup);
    }

    deletePlayGroup(id: string): Observable<void> {
        return this.http.delete<void>(`${this.URL}/${id}`);
    }

    // Decks

    getPlayGroupDecks(id: string): Observable<PlayGroupDeck[]> {
        return this.http.get<PlayGroupDeck[]>(`${this.URL}/${id}/decks`);
    }

    createPlayGroupDeck(id: string, deck: DeckCreateRequest): Observable<Deck> {
        return this.http.post<Deck>(`${this.URL}/${id}/decks`, deck);
    }

    getPlayGroupDeck(id: string, deckId: string): Observable<Deck> {
        return this.http.get<Deck>(`${this.URL}/${id}/decks/${deckId}`);
    }

    // Games

    getPlayGroupGames(id: string): Observable<Game[]> {
        return this.http.get<Game[]>(`${this.URL}/${id}/games`);
    }

    // Pilots

    getPilots(id: string): Observable<Pilot[]> {
        return this.http.get<Pilot[]>(`${this.URL}/${id}/pilots`);
    }

    createPilot(id: string, pilot: PilotCreateRequest): Observable<Pilot> {
        return this.http.post<Pilot>(`${this.URL}/${id}/pilots`, pilot);
    }

    getPilot(id: string, pilotId: string): Observable<Pilot> {
        return this.http.get<Pilot>(`${this.URL}/${id}/pilots/${pilotId}`);
    }
}
