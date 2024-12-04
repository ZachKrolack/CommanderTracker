import { CommonModule } from '@angular/common';
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
import { MatSelectModule } from '@angular/material/select';
import { Observable } from 'rxjs';
import { DeckApiService } from 'src/app/core/api/deck.api.service';
import { BaseDeck } from 'src/app/core/models/deck.model';
import { PlayGroupDeck } from 'src/app/core/models/playGroupDeck.model';
import { DialogCancelButtonComponent } from '../dialog/dialog-cancel-button/dialog-cancel-button.component';
import { DialogFooterComponent } from '../dialog/dialog-footer/dialog-footer.component';
import { DialogHeaderComponent } from '../dialog/dialog-header/dialog-header.component';
import { AddableDecksPipe } from './addable-decks.pipe';

export type AddDeckToPlayGroupFromDialogData = {
    playGroupId: string;
    playGroupDecks: PlayGroupDeck[];
};

export type AddDeckToPlayGroupForm = {
    deckId: FormControl<string | null>;
};

@Component({
    selector: 'app-add-deck-to-playgroup-form-dialog',
    standalone: true,
    imports: [
        CommonModule,
        MatFormFieldModule,
        MatDialogModule,
        MatSelectModule,
        MatButtonModule,
        FormsModule,
        ReactiveFormsModule,
        DialogHeaderComponent,
        DialogFooterComponent,
        DialogCancelButtonComponent,
        AddableDecksPipe
    ],
    templateUrl: './add-deck-to-playgroup-form-dialog.component.html',
    styleUrl: './add-deck-to-playgroup-form-dialog.component.scss'
})
export class AddDeckToPlaygroupFormDialogComponent implements OnInit {
    form!: FormGroup<AddDeckToPlayGroupForm>;

    decks$!: Observable<BaseDeck[]>;

    get playGroupId(): string {
        return this.data.playGroupId;
    }

    get playGroupDecks(): PlayGroupDeck[] {
        return this.data.playGroupDecks;
    }

    constructor(
        @Inject(MAT_DIALOG_DATA) public data: AddDeckToPlayGroupFromDialogData,
        private dialogRef: MatDialogRef<AddDeckToPlaygroupFormDialogComponent>,
        private deckApiService: DeckApiService
    ) {}

    ngOnInit(): void {
        this.decks$ = this.getDecks();
        this.form = this.initForm();
    }

    submit(): void {
        const { deckId } = this.form.value;

        this.deckApiService
            .addDeckToPlayGroup(this.playGroupId, deckId!)
            .subscribe(() => {
                this.dialogRef.close(true);
            });
    }

    private getDecks(): Observable<BaseDeck[]> {
        return this.deckApiService.getDecks();
    }

    private initForm(): FormGroup<AddDeckToPlayGroupForm> {
        return new FormGroup<AddDeckToPlayGroupForm>({
            deckId: new FormControl<string | null>(null, Validators.required)
        });
    }
}
