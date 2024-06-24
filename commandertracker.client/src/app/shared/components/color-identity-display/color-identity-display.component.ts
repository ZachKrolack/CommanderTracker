import { CommonModule } from '@angular/common';
import {
    ChangeDetectionStrategy,
    Component,
    EventEmitter,
    Input,
    Output
} from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { COLOR_INDENTITY_ORDER } from 'src/app/core/constants/colorIdentity';
import { IsColorActivePipe } from './is-color-active.pipe';

@Component({
    selector: 'app-color-identity-display',
    standalone: true,
    imports: [IsColorActivePipe, CommonModule, MatButtonModule],
    templateUrl: './color-identity-display.component.html',
    styleUrl: './color-identity-display.component.scss',
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class ColorIdentityDisplayComponent {
    @Input() isReadOnly: boolean = false;
    @Input() colorIdentityString = '';

    @Output() colorSelected: EventEmitter<string> = new EventEmitter<string>();

    colors: ReadonlyArray<string> = COLOR_INDENTITY_ORDER;

    selectColor(color: string): void {
        this.colorSelected.emit(color);
    }
}
