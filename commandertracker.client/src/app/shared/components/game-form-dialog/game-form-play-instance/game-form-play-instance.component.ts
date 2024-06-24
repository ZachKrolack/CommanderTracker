import { CommonModule } from '@angular/common';
import {
    ChangeDetectionStrategy,
    Component,
    EventEmitter,
    Input,
    Output
} from '@angular/core';
import {
    FormControl,
    FormGroup,
    FormsModule,
    ReactiveFormsModule
} from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { Observable } from 'rxjs';
import { Deck } from 'src/app/core/models/deck.model';
import { Pilot } from 'src/app/core/models/pilot.model';
import { DeckFormDialogComponent } from '../../deck-form-dialog/deck-form-dialog.component';
import {
    PilotFormDialogComponent,
    PilotFormDialogData
} from '../../pilot-form-dialog/pilot-form-dialog.component';
import { PlayInstanceForm } from '../game-form';

@Component({
    selector: 'app-game-form-play-instance',
    standalone: true,
    imports: [
        CommonModule,
        MatFormFieldModule,
        MatInputModule,
        MatDialogModule,
        MatButtonModule,
        FormsModule,
        ReactiveFormsModule,
        MatSelectModule,
        MatIconModule
    ],
    templateUrl: './game-form-play-instance.component.html',
    styleUrl: './game-form-play-instance.component.scss',
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class GameFormPlayInstanceComponent {
    @Input() form!: FormGroup<PlayInstanceForm>;
    @Input() index = 0;
    @Input() decks$!: Observable<Deck[]>;
    @Input() pilots$!: Observable<Pilot[]>;
    @Input() decks!: Deck[];
    @Input() pilots!: Pilot[];

    @Output() removed: EventEmitter<void> = new EventEmitter<void>();
    @Output() pilotCreated: EventEmitter<Pilot> = new EventEmitter<Pilot>();

    get pilotId(): FormControl<string | null> {
        return this.form.controls.pilotId;
    }

    constructor(private dialog: MatDialog) {}

    openDeckFormDialog(): void {
        const dialogRef = this.dialog.open(DeckFormDialogComponent);
    }

    openPilotFormDialog(): void {
        const dialogRef = this.dialog.open<
            PilotFormDialogComponent,
            PilotFormDialogData,
            Pilot
        >(PilotFormDialogComponent);

        dialogRef.afterClosed().subscribe((pilot?: Pilot) => {
            if (pilot) {
                this.pilotCreated.emit(pilot);
            }
        });
    }

    remove(): void {
        this.removed.emit();
    }
}
