import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { DECKS_URL, PLAY_GROUPS_URL } from '../constants/api';
import {
    Deck,
    DeckCreateRequest,
    DeckUpdateRequest
} from '../models/deck.model';
import { PlayGroupDeck } from '../models/playGroupDeck.model';

@Injectable({
    providedIn: 'root'
})
export class DeckApiService {
    private readonly ROOT = `${environment.apiRoot}`;
    private readonly PLAY_GROUPS = PLAY_GROUPS_URL;
    private readonly DECKS = DECKS_URL;

    constructor(private http: HttpClient) {}

    getDecks(): Observable<Deck[]> {
        return this.http.get<Deck[]>(`${this.ROOT}/${this.DECKS}`);
    }

    getPlayGroupDecks(playGroupId: string): Observable<PlayGroupDeck[]> {
        return this.http.get<PlayGroupDeck[]>(
            `${this.ROOT}/${this.PLAY_GROUPS}/${playGroupId}/${this.DECKS}`
        );
    }

    createDeck(deck: DeckCreateRequest): Observable<Deck> {
        return this.http.post<Deck>(`${this.ROOT}/${this.DECKS}`, deck);
    }

    createPlayGroupDeck(
        playGroupId: string,
        deck: DeckCreateRequest
    ): Observable<Deck> {
        return this.http.post<Deck>(
            `${this.ROOT}/${this.PLAY_GROUPS}/${playGroupId}/${this.DECKS}`,
            deck
        );
    }

    addDeckToPlayGroup(playGroupId: string, deckId: string): Observable<Deck> {
        return this.http.post<Deck>(
            `${this.ROOT}/${this.PLAY_GROUPS}/${playGroupId}/${this.DECKS}/${deckId}`,
            null
        );
    }

    getDeck(deckId: string): Observable<Deck> {
        return this.http.get<Deck>(`${this.ROOT}/${this.DECKS}/${deckId}`);
    }

    getPlayGroupDeck(
        playGroupId: string,
        deckId: string
    ): Observable<PlayGroupDeck> {
        return this.http.get<PlayGroupDeck>(
            `${this.ROOT}/${this.PLAY_GROUPS}/${playGroupId}/${this.DECKS}/${deckId}`
        );
    }

    updateDeck(deckId: string, deck: DeckUpdateRequest): Observable<void> {
        return this.http.put<void>(
            `${this.ROOT}/${this.DECKS}/${deckId}`,
            deck
        );
    }

    deleteDeck(deckId: string): Observable<void> {
        return this.http.delete<void>(`${this.ROOT}/${this.DECKS}/${deckId}`);
    }

    removeDeckFromPlayGroup(
        playGroupId: string,
        deckId: string
    ): Observable<void> {
        return this.http.delete<void>(
            `${this.ROOT}/${this.PLAY_GROUPS}/${playGroupId}/${this.DECKS}/${deckId}`
        );
    }
}
