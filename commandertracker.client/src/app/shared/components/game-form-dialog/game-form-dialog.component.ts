import { CommonModule } from '@angular/common';
import { Component, Inject, OnInit } from '@angular/core';
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
    MAT_DIALOG_DATA,
    MatDialogModule,
    MatDialogRef
} from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { Observable, shareReplay } from 'rxjs';
import { PlayGroupApiService } from 'src/app/core/api/play-group.api.service';
import { Game, GameCreateRequest } from 'src/app/core/models/game.model';
import { Pilot } from 'src/app/core/models/pilot.model';
import { PlayGroupDeck } from 'src/app/core/models/playGroupDeck.model';
import {
    GameForm,
    PlayInstanceForm,
    parseGameCreateRequest
} from './game-form';
import { GameFormPlayInstanceComponent } from './game-form-play-instance/game-form-play-instance.component';

export type GameFormDialogData = {
    playGroupId: string;
};

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

    decks$!: Observable<PlayGroupDeck[]>;
    pilots$!: Observable<Pilot[]>;

    get playGroupId(): string {
        return this.data.playGroupId;
    }

    get playInstances(): FormArray<FormGroup<PlayInstanceForm>> {
        return this.form.controls.playInstances;
    }

    constructor(
        @Inject(MAT_DIALOG_DATA) public data: GameFormDialogData,
        private dialogRef: MatDialogRef<GameFormDialogComponent>,
        private playGroupApiService: PlayGroupApiService
    ) {}

    ngOnInit(): void {
        this.decks$ = this.getDecks(this.playGroupId);
        this.pilots$ = this.getPilots(this.playGroupId);

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
        this.pilots$ = this.getPilots(this.playGroupId);
    }

    submit(): void {
        this.createGame().subscribe(() => {
            this.dialogRef.close(true);
        });
    }

    private createGame(): Observable<Game> {
        const gameCreateRequest: GameCreateRequest = parseGameCreateRequest(
            this.form
        );

        return this.playGroupApiService.createGame(
            this.playGroupId,
            gameCreateRequest
        );
    }

    private getDecks(playGroupId: string): Observable<PlayGroupDeck[]> {
        return this.playGroupApiService.getDecks(playGroupId).pipe(
            // map((decks: PlayGroupDeck[]) =>
            //     decks.map((deck) => deck.deck as Deck)
            // ), // TODO
            shareReplay()
        );
    }

    private getPilots(playGroupId: string): Observable<Pilot[]> {
        return this.playGroupApiService
            .getPilots(playGroupId)
            .pipe(shareReplay());
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
            // deckId: new FormControl<string | null>(null, Validators.required),
            playGroupDeckId: new FormControl<string | null>(
                null,
                Validators.required
            ),
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
