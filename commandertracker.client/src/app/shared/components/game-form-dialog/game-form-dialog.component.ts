import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import {
    FormArray,
    FormControl,
    FormGroup,
    FormsModule,
    ReactiveFormsModule,
    Validators
} from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import {
    MatDialog,
    MatDialogModule,
    MatDialogRef
} from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { Observable, shareReplay } from 'rxjs';
import { DeckService } from 'src/app/core/api/deck.service';
import { GameService } from 'src/app/core/api/game.service';
import { PilotService } from 'src/app/core/api/pilot.service';
import { Deck } from 'src/app/core/models/deck.model';
import { Game, GameCreateRequest } from 'src/app/core/models/game.model';
import { Pilot } from 'src/app/core/models/pilot.model';
import {
    GameForm,
    PlayInstanceForm,
    parseGameCreateRequest
} from './game-form';
import { GameFormPlayInstanceComponent } from './game-form-play-instance/game-form-play-instance.component';

export type GameFormDialogData = {};

@Component({
    selector: 'app-game-form-dialog',
    standalone: true,
    imports: [
        CommonModule,
        MatFormFieldModule,
        MatInputModule,
        MatDialogModule,
        MatButtonModule,
        FormsModule,
        ReactiveFormsModule,
        MatIconModule,
        GameFormPlayInstanceComponent
    ],
    templateUrl: './game-form-dialog.component.html',
    styleUrl: './game-form-dialog.component.scss'
})
export class GameFormDialogComponent implements OnInit {
    form!: FormGroup<GameForm>;

    decks$!: Observable<Deck[]>;
    pilots$!: Observable<Pilot[]>;

    get playInstances(): FormArray<FormGroup<PlayInstanceForm>> {
        return this.form.controls.playInstances;
    }

    constructor(
        private dialogRef: MatDialogRef<GameFormDialogComponent>,
        private dialog: MatDialog,
        private deckService: DeckService,
        private gameService: GameService,
        private pilotService: PilotService
    ) {}

    ngOnInit(): void {
        this.decks$ = this.getDecks();
        this.pilots$ = this.getPilots();

        this.form = this.initForm();
    }

    addPlayInstance(): void {
        const playInstanceForm = this.initPlayInstanceForm(
            this.playInstances.length + 1
        );
        this.playInstances.push(playInstanceForm);
    }

    removePlayInstance(index: number): void {
        this.playInstances.removeAt(index);
    }

    pilotCreated(): void {
        this.pilots$ = this.getPilots();
    }

    submit(): void {
        this.createGame().subscribe(() => {
            this.dialogRef.close(true);
        });
    }

    private createGame(): Observable<Game> {
        const GameCreateRequest: GameCreateRequest = parseGameCreateRequest(
            this.form
        );

        return this.gameService.createGame(GameCreateRequest);
    }

    private getDecks(): Observable<Deck[]> {
        return this.deckService.getDecks().pipe(shareReplay());
    }

    private getPilots(): Observable<Pilot[]> {
        return this.pilotService.getPilots().pipe(shareReplay());
    }

    private initForm(): FormGroup<GameForm> {
        return new FormGroup<GameForm>({
            turns: new FormControl<number | null>(null, Validators.required),
            notes: new FormControl<string>('', { nonNullable: true }),
            playInstances: new FormArray<FormGroup<PlayInstanceForm>>(
                [],
                [Validators.minLength(2), Validators.maxLength(8)]
            )
        });
    }

    private initPlayInstanceForm(
        playInstanceIndex: number | null = null
    ): FormGroup<PlayInstanceForm> {
        return new FormGroup<PlayInstanceForm>({
            deckId: new FormControl<string | null>(null, Validators.required),
            pilotId: new FormControl<string | null>(null, Validators.required),
            turnOrder: new FormControl<number | null>(playInstanceIndex, [
                Validators.required,
                Validators.min(1)
            ]),
            endPosition: new FormControl<number | null>(playInstanceIndex, [
                Validators.required,
                Validators.min(1)
            ]),
            notes: new FormControl<string>('', { nonNullable: true })
        });
    }
}
