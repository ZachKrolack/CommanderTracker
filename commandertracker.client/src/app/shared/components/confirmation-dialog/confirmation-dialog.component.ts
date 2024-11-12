import { Component, Inject } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import {
    MAT_DIALOG_DATA,
    MatDialogModule,
    MatDialogRef
} from '@angular/material/dialog';

@Component({
    selector: 'app-confirmation-dialog',
    standalone: true,
    imports: [MatDialogModule, MatButtonModule],
    templateUrl: './confirmation-dialog.component.html',
    styleUrl: './confirmation-dialog.component.scss'
})
export class ConfirmationDialogComponent {
    constructor(
        @Inject(MAT_DIALOG_DATA) public data: any,
        private dialogRef: MatDialogRef<ConfirmationDialogComponent>
    ) {}

    confirm(): void {
        this.dialogRef.close(true);
    }
}
