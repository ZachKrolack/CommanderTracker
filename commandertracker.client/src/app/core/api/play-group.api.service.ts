import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { API_CONSTANTS } from '../constants/api';
import {
    PlayGroup,
    PlayGroupCreateRequest,
    PlayGroupUpdateRequest
} from '../models/playGroup.model';

@Injectable({
    providedIn: 'root'
})
export class PlayGroupApiService {
    private readonly ROOT = `${environment.apiRoot}`;
    private readonly PLAY_GROUPS = API_CONSTANTS.PLAY_GROUPS_URL;

    constructor(private http: HttpClient) {}

    getPlayGroups(): Observable<PlayGroup[]> {
        return this.http.get<PlayGroup[]>(`${this.ROOT}/${this.PLAY_GROUPS}`);
    }

    createPlayGroup(playGroup: PlayGroupCreateRequest): Observable<PlayGroup> {
        return this.http.post<PlayGroup>(
            `${this.ROOT}/${this.PLAY_GROUPS}`,
            playGroup
        );
    }

    getPlayGroup(playGroupId: string): Observable<PlayGroup> {
        return this.http.get<PlayGroup>(
            `${this.ROOT}/${this.PLAY_GROUPS}/${playGroupId}`
        );
    }

    updatePlayGroup(
        playGroupId: string,
        playGroup: PlayGroupUpdateRequest
    ): Observable<void> {
        return this.http.put<void>(
            `${this.ROOT}/${this.PLAY_GROUPS}/${playGroupId}`,
            playGroup
        );
    }

    deletePlayGroup(playGroupId: string): Observable<void> {
        return this.http.delete<void>(
            `${this.ROOT}/${this.PLAY_GROUPS}/${playGroupId}`
        );
    }
}
