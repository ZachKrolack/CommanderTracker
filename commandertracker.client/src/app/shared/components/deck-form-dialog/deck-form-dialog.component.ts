import { Component, Inject, OnInit } from '@angular/core';
import {
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
import { MatInputModule } from '@angular/material/input';
import { Observable } from 'rxjs';
import { DeckService } from 'src/app/core/api/deck.service';
import { PlayGroupApiService } from 'src/app/core/api/play-group.api.service';
import { ColorIdentity } from 'src/app/core/enums/colorIdentity.enum';
import {
    Deck,
    DeckCreateRequest,
    DeckUpdateRequest
} from 'src/app/core/models/deck.model';
import { ColorIdentitySelectorComponent } from '../color-identity-selector/color-identity-selector.component';

export type DeckFormDialogData = {
    playGroupId?: string;
    deck?: Deck;
};

export type DeckForm = {
    name: FormControl<string | null>;
    colorIdentity: FormControl<ColorIdentity | null>;
};

@Component({
    selector: 'app-deck-form-dialog',
    standalone: true,
    imports: [
        MatFormFieldModule,
        MatInputModule,
        MatDialogModule,
        MatButtonModule,
        FormsModule,
        ReactiveFormsModule,
        ColorIdentitySelectorComponent
    ],
    templateUrl: './deck-form-dialog.component.html',
    styleUrl: './deck-form-dialog.component.scss'
})
export class DeckFormDialogComponent implements OnInit {
    form!: FormGroup<DeckForm>;

    get deck(): Deck | null {
        return this.data?.deck ?? null;
    }

    get deckId(): string | null {
        return this.deck?.id ?? null;
    }

    get playGroupId(): string | null {
        return this.data?.playGroupId ?? null;
    }

    get isNew(): boolean {
        return !this.data?.deck;
    }

    get title(): string {
        return this.isNew ? 'Add Deck' : 'Edit Deck';
    }

    constructor(
        @Inject(MAT_DIALOG_DATA) public data: DeckFormDialogData,
        private dialogRef: MatDialogRef<DeckFormDialogComponent>,
        private playGroupApiService: PlayGroupApiService,
        private deckService: DeckService
    ) {}

    ngOnInit(): void {
        this.form = this.initForm(this.deck);
    }

    submit() {
        const submissionObservable: Observable<Deck | void> = this.isNew
            ? this.createDeck()
            : this.updateDeck();

        submissionObservable.subscribe(() => {
            this.dialogRef.close(true);
        });
    }

    private createDeck(): Observable<Deck> {
        const { name, colorIdentity } = this.form.value;

        const deck: DeckCreateRequest = {
            name: name!,
            colorIdentity: colorIdentity!
        };

        return this.playGroupId
            ? this.playGroupApiService.createPlayGroupDeck(
                  this.playGroupId,
                  deck
              )
            : this.deckService.createDeck(deck);
    }

    private updateDeck(): Observable<void> {
        const id = this.deckId!;
        const { name, colorIdentity } = this.form.value;

        const deck: DeckUpdateRequest = {
            id,
            name: name!,
            colorIdentity: colorIdentity!
        };

        return this.deckService.updateDeck(id, deck);
    }

    private initForm(deck: Deck | null = null): FormGroup<DeckForm> {
        return new FormGroup<DeckForm>({
            name: new FormControl<string | null>(
                deck?.name ?? null,
                Validators.required
            ),
            colorIdentity: new FormControl<ColorIdentity | null>(
                deck?.colorIdentity ?? null,
                Validators.required
            )
        });
    }
}