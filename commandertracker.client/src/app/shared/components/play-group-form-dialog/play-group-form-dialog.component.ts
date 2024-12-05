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
import { PlayGroupApiService } from 'src/app/core/api/play-group.api.service';
import {
    PlayGroup,
    PlayGroupCreateRequest,
    PlayGroupUpdateRequest
} from 'src/app/core/models/playGroup.model';
import { FormErrorPipe } from '../../pipes/form-error.pipe';
import { DialogModule } from '../dialog/dialog.module';

export type PlayGroupFormDialogData = {
    playGroup: PlayGroup;
};

type PlayGroupForm = {
    name: FormControl<string | null>;
};

@Component({
    selector: 'app-play-group-form-dialog',
    standalone: true,
    imports: [
        MatDialogModule,
        FormsModule,
        ReactiveFormsModule,
        MatFormFieldModule,
        MatInputModule,
        MatButtonModule,
        DialogModule,
        FormErrorPipe
    ],
    templateUrl: './play-group-form-dialog.component.html',
    styleUrl: './play-group-form-dialog.component.scss'
})
export class PlayGroupFormDialogComponent implements OnInit {
    form!: FormGroup<PlayGroupForm>;

    get playGroup(): PlayGroup | null {
        return this.data?.playGroup;
    }

    get playGroupId(): string | null {
        return this.playGroup?.id ?? null;
    }

    get isNew(): boolean {
        return !this.data?.playGroup;
    }

    get title(): string {
        return this.isNew ? 'Add Play Group' : 'Edit Play Group';
    }

    constructor(
        @Inject(MAT_DIALOG_DATA) public data: PlayGroupFormDialogData,
        private dialogRef: MatDialogRef<PlayGroupFormDialogComponent>,
        private playGroupApiService: PlayGroupApiService
    ) {}

    ngOnInit(): void {
        this.form = this.initForm(this.playGroup);
    }

    submit(): void {
        const submissionObservable: Observable<PlayGroup | void> = this.isNew
            ? this.createPlayGroup()
            : this.updatePlayGroup();

        submissionObservable.subscribe(() => {
            this.dialogRef.close(true);
        });
    }

    private createPlayGroup(): Observable<PlayGroup> {
        const { name } = this.form.value;

        const request: PlayGroupCreateRequest = {
            name: name!
        };

        return this.playGroupApiService.createPlayGroup(request);
    }

    private updatePlayGroup(): Observable<void> {
        const id = this.playGroupId!;
        const { name } = this.form.value;

        const request: PlayGroupUpdateRequest = {
            id,
            name: name!
        };

        return this.playGroupApiService.updatePlayGroup(id, request);
    }

    private initForm(
        playGroup: PlayGroup | null = null
    ): FormGroup<PlayGroupForm> {
        return new FormGroup<PlayGroupForm>({
            name: new FormControl<string | null>(playGroup?.name ?? null, [
                Validators.required
            ])
        });
    }
}
