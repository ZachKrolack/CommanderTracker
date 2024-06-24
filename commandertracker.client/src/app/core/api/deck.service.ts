import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import {
    Deck,
    DeckCreateRequest,
    DeckUpdateRequest
} from '../models/deck.model';

@Injectable({
    providedIn: 'root'
})
export class DeckService {
    private readonly CONTROLLER_PATH = 'decks';
    private readonly URL = `${environment.apiRoot}/${this.CONTROLLER_PATH}`;

    constructor(private http: HttpClient) {}

    getDecks(): Observable<Deck[]> {
        return this.http.get<Deck[]>(`${this.URL}`);
    }

    createDeck(deck: DeckCreateRequest): Observable<Deck> {
        return this.http.post<Deck>(`${this.URL}`, deck);
    }

    getDeck(id: string): Observable<Deck> {
        return this.http.get<Deck>(`${this.URL}/${id}`);
    }

    updateDeck(id: string, deck: DeckUpdateRequest): Observable<void> {
        return this.http.put<void>(`${this.URL}/${id}`, deck);
    }

    deleteDeck(id: string): Observable<void> {
        return this.http.delete<void>(`${this.URL}/${id}`);
    }
}
