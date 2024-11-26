import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog';

@Component({
    selector: 'app-dialog-cancel-button',
    standalone: true,
    imports: [MatDialogModule, MatButtonModule],
    templateUrl: './dialog-cancel-button.component.html',
    styleUrl: './dialog-cancel-button.component.scss'
})
export class DialogCancelButtonComponent {}
