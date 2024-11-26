import { Component } from '@angular/core';
import { MatDialogModule } from '@angular/material/dialog';

@Component({
    selector: 'app-dialog-header',
    standalone: true,
    imports: [MatDialogModule],
    templateUrl: './dialog-header.component.html',
    styleUrl: './dialog-header.component.scss'
})
export class DialogHeaderComponent {}
