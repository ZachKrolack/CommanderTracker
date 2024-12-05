import {
    HttpErrorResponse,
    HttpEvent,
    HttpHandlerFn,
    HttpInterceptorFn,
    HttpRequest,
    HttpResponse
} from '@angular/common/http';
import { inject } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { catchError, Observable, tap, throwError } from 'rxjs';
import { environment } from 'src/environments/environment';
import { API_CONSTANTS } from '../constants/api';

const MODEL_URLS: Set<string> = new Set<string>([
    API_CONSTANTS.DECKS_URL,
    API_CONSTANTS.GAMES_URL,
    API_CONSTANTS.PILOTS_URL,
    API_CONSTANTS.PLAY_GROUPS_URL
]);

function parseModelFromUrl(url: string): string {
    const splitUrl: string[] = url.split('/');

    if (!splitUrl.length) return '';

    const model = splitUrl
        .reverse()
        .find((segment) => MODEL_URLS.has(segment.toLowerCase()));

    return model ?? '';
}

function normalizeModelName(model: string): string {
    return model.slice(0, -1).replace('-', ' ');
}

export const snackBarInterceptor: HttpInterceptorFn = (
    req: HttpRequest<any>,
    next: HttpHandlerFn
): Observable<HttpEvent<any>> => {
    const snackBar = inject(MatSnackBar);

    /**
     * Only show success snack bar for these request methods and response status codes.
     */
    const ACCEPTED_STATUS_CODES: Set<number> = new Set<number>([200, 201, 204]);
    const ACCEPTED_METHODS: Set<string> = new Set<string>([
        'POST',
        'PUT',
        'PATCH',
        'DELETE'
    ]);

    /**
     * Do not show success snack bar for requests made to these URLs.
     */
    const URL_BLACKLIST: Set<string> = new Set<string>([
        `${environment.apiRoot}/${API_CONSTANTS.LOGIN_URL}`,
        `${environment.apiRoot}/${API_CONSTANTS.REGISTER_URL}`
    ]);

    return next(req).pipe(
        tap((res) => {
            if (
                res instanceof HttpResponse &&
                ACCEPTED_STATUS_CODES.has(res.status) &&
                ACCEPTED_METHODS.has(req.method) &&
                !URL_BLACKLIST.has(req.url)
            ) {
                let model = parseModelFromUrl(req.url);
                model = normalizeModelName(model);

                switch (req.method) {
                    case 'POST':
                        snackBar.open(`Successfully created ${model}`, 'close');
                        break;
                    case 'PUT':
                        snackBar.open(`Successfully updated ${model}`, 'close');
                        break;
                    case 'PATCH':
                        snackBar.open(`Successfully updated ${model}`, 'close');
                        break;
                    case 'DELETE':
                        snackBar.open(`Successfully deleted ${model}`, 'close');
                        break;
                    default:
                    // TODO
                }
            }
        }),
        catchError((err: HttpErrorResponse) => {
            // TODO
            snackBar.open('Error', 'close');

            return throwError(() => err);
        })
    );
};
