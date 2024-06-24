import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import {
    COLOR_INDENTITY_ORDER,
    ColorIdentityMap
} from 'src/app/core/constants/colorIdentity';
import {
    ColorIdentity,
    ColorIdentityStringWubrgOrder
} from 'src/app/core/enums/colorIdentity.enum';
import { ColorIdentityDisplayComponent } from '../color-identity-display/color-identity-display.component';

@Component({
    selector: 'app-color-identity-selector',
    standalone: true,
    imports: [MatButtonModule, CommonModule, ColorIdentityDisplayComponent],
    templateUrl: './color-identity-selector.component.html',
    styleUrl: './color-identity-selector.component.scss',
    providers: [
        {
            provide: NG_VALUE_ACCESSOR,
            multi: true,
            useExisting: ColorIdentitySelectorComponent
        }
    ]
})
export class ColorIdentitySelectorComponent implements ControlValueAccessor {
    colorIdentityString: string = '';

    onChange = (colorIdentity: ColorIdentity) => {};
    onTouched = () => {};

    touched: boolean = false;
    disabled: boolean = false;

    toggleColor(color: string): void {
        if (this.colorIdentityString.includes(color)) {
            this.colorIdentityString = this.colorIdentityString.replace(
                color,
                ''
            );
        } else {
            this.colorIdentityString = this.colorIdentityString.concat(color);
            this.colorIdentityString = this.sortColorIdentityString(
                this.colorIdentityString
            );
        }

        this.onChange(
            ColorIdentityMap.getKey(
                this.colorIdentityString as ColorIdentityStringWubrgOrder
            ) ?? ColorIdentity.Colorless
        );
    }

    writeValue(colorIdentity: ColorIdentity): void {
        this.colorIdentityString =
            ColorIdentityMap.getValue(colorIdentity) ??
            ColorIdentityStringWubrgOrder.Colorless;
    }

    registerOnChange(fn: (colorIdentity: ColorIdentity) => {}): void {
        this.onChange = fn;
    }

    registerOnTouched(fn: () => {}): void {
        this.onTouched = fn;
    }

    markAsTouched() {
        if (!this.touched) {
            this.onTouched();
            this.touched = true;
        }
    }

    setDisabledState?(isDisabled: boolean): void {
        this.disabled = isDisabled;
    }

    private sortColorIdentityString(colorIdentityString: string): string {
        return colorIdentityString
            .split('')
            .sort(
                (a, b) =>
                    COLOR_INDENTITY_ORDER.indexOf(a) -
                    COLOR_INDENTITY_ORDER.indexOf(b)
            )
            .join('');
    }
}
