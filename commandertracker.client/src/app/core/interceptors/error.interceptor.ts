import {
    HttpErrorResponse,
    HttpEvent,
    HttpHandlerFn,
    HttpInterceptorFn,
    HttpRequest,
    HttpStatusCode
} from '@angular/common/http';
import { Observable, catchError, throwError } from 'rxjs';

export const errorInterceptor: HttpInterceptorFn = (
    req: HttpRequest<any>,
    next: HttpHandlerFn
): Observable<HttpEvent<any>> => {
    return next(req).pipe(
        catchError((err: HttpErrorResponse) => {
            if (err instanceof HttpErrorResponse) {
                // TODO
                switch (err.status) {
                    case HttpStatusCode.Unauthorized:
                        console.error(`Unauthorized`);
                        break;
                    default:
                        console.error(`Error: ${err.message}`);
                }
            }

            return throwError(() => err);
        })
    );
};
