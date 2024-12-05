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
import { PilotApiService } from 'src/app/core/api/pilot.api.service';
import {
    Pilot,
    PilotCreateRequest,
    PilotUpdateRequest
} from 'src/app/core/models/pilot.model';
import { FormErrorPipe } from '../../pipes/form-error.pipe';
import { DialogModule } from '../dialog/dialog.module';

export type PilotFormDialogData = {
    pilot?: Pilot;
    playGroupId: string;
};

export type PilotForm = {
    name: FormControl<string | null>;
};

@Component({
    selector: 'app-pilot-form-dialog',
    standalone: true,
    imports: [
        MatFormFieldModule,
        MatInputModule,
        MatDialogModule,
        MatButtonModule,
        FormsModule,
        ReactiveFormsModule,
        DialogModule,
        FormErrorPipe
    ],
    templateUrl: './pilot-form-dialog.component.html',
    styleUrl: './pilot-form-dialog.component.scss'
})
export class PilotFormDialogComponent implements OnInit {
    form!: FormGroup<PilotForm>;

    get pilot(): Pilot | null {
        return this.data?.pilot ?? null;
    }

    get pilotId(): string | null {
        return this.pilot?.id ?? null;
    }

    get playGroupId(): string | null {
        return this.data?.playGroupId ?? null;
    }

    get isNew(): boolean {
        return !this.data?.pilot;
    }

    get title(): string {
        return this.isNew ? 'Add Player' : 'Edit Player';
    }

    constructor(
        @Inject(MAT_DIALOG_DATA) public data: PilotFormDialogData,
        private dialogRef: MatDialogRef<PilotFormDialogComponent>,
        private pilotApiService: PilotApiService
    ) {}

    ngOnInit(): void {
        this.form = this.initForm(this.pilot);
    }

    submit(): void {
        this.isNew ? this.createPilot() : this.updatePilot();
    }

    private createPilot(): void {
        const { name } = this.form.value;

        if (!this.playGroupId) {
            return;
        }

        const pilot: PilotCreateRequest = {
            name: name!
        };

        this.pilotApiService
            .createPilot(this.playGroupId, pilot)
            .subscribe((pilot: Pilot) => {
                this.dialogRef.close(pilot);
            });
    }

    private updatePilot(): void {
        const id = this.pilotId!;
        const { name } = this.form.value;

        if (!this.playGroupId) {
            return;
        }

        const deck: PilotUpdateRequest = {
            id,
            name: name!
        };

        this.pilotApiService
            .updatePilot(this.playGroupId, id, deck)
            .subscribe(() => {
                this.dialogRef.close(true);
            });
    }

    private initForm(pilot: Pilot | null = null): FormGroup<PilotForm> {
        return new FormGroup({
            name: new FormControl<string | null>(
                pilot?.name ?? null,
                Validators.required
            )
        });
    }
}
