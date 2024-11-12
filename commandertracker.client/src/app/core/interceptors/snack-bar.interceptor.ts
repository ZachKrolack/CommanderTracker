import {
    HttpEvent,
    HttpHandlerFn,
    HttpInterceptorFn,
    HttpRequest,
    HttpResponse
} from '@angular/common/http';
import { inject } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { catchError, Observable, tap, throwError } from 'rxjs';

export const snackBarInterceptor: HttpInterceptorFn = (
    req: HttpRequest<any>,
    next: HttpHandlerFn
): Observable<HttpEvent<any>> => {
    const snackBar = inject(MatSnackBar);

    const ACCEPTED_STATUS_CODES: Set<number> = new Set<number>([200, 201, 204]);
    const ACCEPTED_METHODS: Set<string> = new Set<string>([
        'POST',
        'PUT',
        'PATCH',
        'DELETE'
    ]);

    return next(req).pipe(
        tap((res) => {
            if (
                res instanceof HttpResponse &&
                ACCEPTED_STATUS_CODES.has(res.status) &&
                ACCEPTED_METHODS.has(req.method)
            ) {
                switch (req.method) {
                    case 'POST':
                        snackBar.open('Created', 'close');
                        break;
                    case 'PUT':
                        snackBar.open('Updated', 'close');
                        break;
                    case 'PATCH':
                        snackBar.open('Updated', 'close');
                        break;
                    case 'DELETE':
                        snackBar.open('Deleted', 'close');
                        break;
                    default:
                }
            }
        }),
        catchError((err: any) => {
            snackBar.open('Error', 'close');

            return throwError(() => err);
        })
    );
};
