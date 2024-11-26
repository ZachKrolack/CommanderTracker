import { Component } from '@angular/core';
import { MatDialogModule } from '@angular/material/dialog';

@Component({
    selector: 'app-dialog-footer',
    standalone: true,
    imports: [MatDialogModule],
    templateUrl: './dialog-footer.component.html',
    styleUrl: './dialog-footer.component.scss'
})
export class DialogFooterComponent {}
