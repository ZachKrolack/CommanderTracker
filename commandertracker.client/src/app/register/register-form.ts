import {
    AbstractControl,
    FormControl,
    FormGroup,
    FormGroupDirective,
    NgForm,
    ValidationErrors,
    ValidatorFn
} from '@angular/forms';
import { ErrorStateMatcher } from '@angular/material/core';
import { RegisterRequest } from '../core/models/auth.model';

export const PASSWORD_REGEX: Readonly<RegExp> =
    /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,64}$/;

export const PASSWORDS_DO_NOT_MATCH_ERROR_KEY: Readonly<string> =
    'passwordsDoNotMatch';

export type RegisterForm = {
    userName: FormControl<string | null>;
    email: FormControl<string | null>;
    password: FormControl<string | null>;
    confirmPassword: FormControl<string | null>;
};

export function parseRegisterRequest(
    form: FormGroup<RegisterForm>
): RegisterRequest {
    const { userName, email, password, confirmPassword } = form.value;

    const request: RegisterRequest = {
        userName: userName!,
        email: email!,
        password: password!,
        confirmPassword: confirmPassword!
    };

    return request;
}

export class ConfirmPasswordErrorStateMatcher implements ErrorStateMatcher {
    isErrorState(
        control: AbstractControl<any, any> | null,
        form: FormGroupDirective | NgForm | null
    ): boolean {
        return (
            !control?.pristine &&
            form?.errors?.[PASSWORDS_DO_NOT_MATCH_ERROR_KEY]
        );
    }
}

export function confirmPasswordValidator(): ValidatorFn {
    return (control: AbstractControl): ValidationErrors | null => {
        const passwordControl = control.get('password');
        const confirmControl = control.get('confirmPassword');

        if (!passwordControl || !confirmControl) return null;

        if (!passwordControl.valid) return null;

        const password = passwordControl.value;
        const confirm = confirmControl.value;

        return password === confirm
            ? null
            : { [PASSWORDS_DO_NOT_MATCH_ERROR_KEY]: true };
    };
}
