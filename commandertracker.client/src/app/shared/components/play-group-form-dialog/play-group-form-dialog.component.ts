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
import { PlayGroupApiService } from 'src/app/core/api/play-group.api.service';
import { PlayGroupCreateRequest } from 'src/app/core/models/playGroup.model';
import { FormErrorPipe } from '../../pipes/form-error.pipe';
import { DialogModule } from '../dialog/dialog.module';

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

    constructor(
        @Inject(MAT_DIALOG_DATA) public data: any,
        private dialogRef: MatDialogRef<PlayGroupFormDialogComponent>,
        private playGroupApiService: PlayGroupApiService
    ) {}

    ngOnInit(): void {
        this.form = this.initForm();
    }

    submit(): void {
        const { name } = this.form.value;

        const request: PlayGroupCreateRequest = {
            name: name!
        };

        this.playGroupApiService.createPlayGroup(request).subscribe(() => {
            this.dialogRef.close(true);
        });
    }

    private initForm(): FormGroup<PlayGroupForm> {
        return new FormGroup<PlayGroupForm>({
            name: new FormControl<string | null>(null, [Validators.required])
        });
    }
}
