import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import {
    Pilot,
    PilotCreateRequest,
    PilotUpdateRequest
} from '../models/pilot.model';

@Injectable({
    providedIn: 'root'
})
export class PilotService {
    private readonly CONTROLLER_PATH = 'pilots';
    private readonly URL = `${environment.apiRoot}/${this.CONTROLLER_PATH}`;

    constructor(private http: HttpClient) {}

    getPilots(): Observable<Pilot[]> {
        return this.http.get<Pilot[]>(`${this.URL}`);
    }

    createPilot(pilot: PilotCreateRequest): Observable<Pilot> {
        return this.http.post<Pilot>(`${this.URL}`, pilot);
    }

    getPilot(id: string): Observable<Pilot> {
        return this.http.get<Pilot>(`${this.URL}/${id}`);
    }

    updatePilot(id: string, pilot: PilotUpdateRequest): Observable<void> {
        return this.http.put<void>(`${this.URL}/${id}`, pilot);
    }

    deletePilot(id: string): Observable<void> {
        return this.http.delete<void>(`${this.URL}/${id}`);
    }
}
