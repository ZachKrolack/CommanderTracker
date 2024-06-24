import {
    HttpEvent,
    HttpHandlerFn,
    HttpInterceptorFn,
    HttpRequest
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { TOKEN_LOCAL_STORAGE_KEY } from '../constants/localStorageKeys';

export const authInterceptor: HttpInterceptorFn = (
    req: HttpRequest<any>,
    next: HttpHandlerFn
): Observable<HttpEvent<any>> => {
    const token = localStorage.getItem(TOKEN_LOCAL_STORAGE_KEY);

    if (token) {
        const authReq = req.clone({
            setHeaders: {
                Authorization: `Bearer ${token}`
            }
        });

        return next(authReq);
    } else {
        return next(req);
    }
};
