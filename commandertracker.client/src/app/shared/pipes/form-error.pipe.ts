import { Pipe, PipeTransform } from '@angular/core';
import { FormControl } from '@angular/forms';
import {
    FORM_ERROR_CONSTANTS,
    FORM_ERROR_REPLACEMENT_KEYS
} from 'src/app/core/constants/formError';

@Pipe({
    name: 'formError',
    standalone: true
})
export class FormErrorPipe implements PipeTransform {
    transform(errorKey: string, formControl?: FormControl): string {
        switch (errorKey) {
            case 'required':
                return FORM_ERROR_CONSTANTS.REQUIRED;
            case 'min':
                const min = formControl?.errors?.['min']?.min;
                return FORM_ERROR_CONSTANTS.MIN.replace(
                    FORM_ERROR_REPLACEMENT_KEYS.MIN,
                    min
                );
            case 'max':
                const max = formControl?.errors?.['max']?.max;
                return FORM_ERROR_CONSTANTS.MAX.replace(
                    FORM_ERROR_REPLACEMENT_KEYS.MAX,
                    max
                );
            default:
                return 'default error'; // TODO
        }
    }
}
