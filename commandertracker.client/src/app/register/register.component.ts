import { JsonPipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import {
    FormControl,
    FormGroup,
    FormsModule,
    ReactiveFormsModule,
    Validators
} from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { ErrorStateMatcher } from '@angular/material/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { Router } from '@angular/router';
import { AuthService } from '../core/api/auth.service';
import { RegisterRequest } from '../core/models/auth.model';
import {
    ConfirmPasswordErrorStateMatcher,
    PASSWORDS_DO_NOT_MATCH_ERROR_KEY,
    PASSWORD_REGEX,
    RegisterForm,
    confirmPasswordValidator,
    parseRegisterRequest
} from './register-form';

@Component({
    selector: 'app-register',
    standalone: true,
    imports: [
        FormsModule,
        ReactiveFormsModule,
        MatFormFieldModule,
        MatInputModule,
        MatButtonModule,
        JsonPipe
    ],
    templateUrl: './register.component.html',
    styleUrl: './register.component.scss'
})
export class RegisterComponent implements OnInit {
    form!: FormGroup<RegisterForm>;
    confirmPasswordErrorStateMatcher: ErrorStateMatcher =
        new ConfirmPasswordErrorStateMatcher();

    get passwordsDoNotMatchErrorKey(): string {
        return PASSWORDS_DO_NOT_MATCH_ERROR_KEY;
    }

    constructor(private authService: AuthService, private router: Router) {}

    ngOnInit(): void {
        this.form = this.initForm();
    }

    register(): void {
        const request: RegisterRequest = parseRegisterRequest(this.form);
        this.authService.register(request).subscribe(() => {
            this.router.navigate(['/']);
        });
    }

    private initForm(): FormGroup<RegisterForm> {
        return new FormGroup<RegisterForm>(
            {
                userName: new FormControl<string | null>(null, [
                    Validators.required
                ]),
                email: new FormControl<string | null>(null, [
                    Validators.required,
                    Validators.email
                ]),
                password: new FormControl<string | null>(null, [
                    Validators.required,
                    Validators.minLength(8),
                    Validators.maxLength(64),
                    Validators.pattern(PASSWORD_REGEX)
                ]),
                confirmPassword: new FormControl<string | null>(null)
            },
            [confirmPasswordValidator()]
        );
    }
}
