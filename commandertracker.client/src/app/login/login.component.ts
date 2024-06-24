import { Component, OnInit } from '@angular/core';
import {
    FormControl,
    FormGroup,
    FormsModule,
    ReactiveFormsModule,
    Validators
} from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { Router, RouterLink } from '@angular/router';
import { AuthService } from '../core/api/auth.service';
import { LoginRequest } from '../core/models/auth.model';

type LoginForm = {
    userName: FormControl<string | null>;
    password: FormControl<string | null>;
};

@Component({
    selector: 'app-login',
    standalone: true,
    imports: [
        FormsModule,
        ReactiveFormsModule,
        MatFormFieldModule,
        MatInputModule,
        MatButtonModule,
        RouterLink
    ],
    templateUrl: './login.component.html',
    styleUrl: './login.component.scss'
})
export class LoginComponent implements OnInit {
    form!: FormGroup<LoginForm>;

    constructor(private authService: AuthService, private router: Router) {}

    ngOnInit(): void {
        this.form = this.initForm();
    }

    login(): void {
        const { userName, password } = this.form.value;

        const request: LoginRequest = {
            userName: userName!,
            password: password!
        };

        this.authService.login(request).subscribe(() => {
            this.router.navigate(['/']);
        });
    }

    private initForm(): FormGroup<LoginForm> {
        return new FormGroup<LoginForm>({
            userName: new FormControl<string | null>(null, [
                Validators.required
            ]),
            password: new FormControl<string | null>(null, [
                Validators.required
            ])
        });
    }
}
