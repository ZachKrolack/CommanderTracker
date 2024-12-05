import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { API_CONSTANTS } from '../constants/api';
import {
    Pilot,
    PilotCreateRequest,
    PilotUpdateRequest
} from '../models/pilot.model';

@Injectable({
    providedIn: 'root'
})
export class PilotApiService {
    private readonly ROOT = `${environment.apiRoot}`;
    private readonly PLAY_GROUPS = API_CONSTANTS.PLAY_GROUPS_URL;
    private readonly PILOTS = API_CONSTANTS.PILOTS_URL;

    constructor(private http: HttpClient) {}

    getPilot(pilotId: string): Observable<Pilot> {
        return this.http.get<Pilot>(`${this.ROOT}/${this.PILOTS}/${pilotId}`);
    }

    getPilots(playGroupId: string): Observable<Pilot[]> {
        return this.http.get<Pilot[]>(
            `${this.ROOT}/${this.PLAY_GROUPS}/${playGroupId}/${this.PILOTS}`
        );
    }

    createPilot(
        playGroupId: string,
        pilot: PilotCreateRequest
    ): Observable<Pilot> {
        return this.http.post<Pilot>(
            `${this.ROOT}/${this.PLAY_GROUPS}/${playGroupId}/${this.PILOTS}`,
            pilot
        );
    }

    updatePilot(
        playGroupId: string,
        pilotId: string,
        pilot: PilotUpdateRequest
    ): Observable<void> {
        return this.http.put<void>(
            `${this.ROOT}/${this.PLAY_GROUPS}/${playGroupId}/${this.PILOTS}/${pilotId}`,
            pilot
        );
    }

    deletePilot(playGroupId: string, pilotId: string): Observable<void> {
        return this.http.delete<void>(
            `${this.ROOT}/${this.PLAY_GROUPS}/${playGroupId}/${this.PILOTS}/${pilotId}`
        );
    }
}
