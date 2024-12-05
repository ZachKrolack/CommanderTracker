import { NgModule } from '@angular/core';
import { DialogCancelButtonComponent } from './dialog-cancel-button/dialog-cancel-button.component';
import { DialogFooterComponent } from './dialog-footer/dialog-footer.component';
import { DialogHeaderComponent } from './dialog-header/dialog-header.component';

@NgModule({
    imports: [
        DialogCancelButtonComponent,
        DialogHeaderComponent,
        DialogFooterComponent
    ],
    exports: [
        DialogCancelButtonComponent,
        DialogHeaderComponent,
        DialogFooterComponent
    ]
})
export class DialogModule {}
