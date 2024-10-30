import { HttpRequest, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
})
export class LoggingService {
    constructor() {}

    logHttpResponse(req: HttpRequest<any>, res: HttpResponse<any>): void {
        console.log(req.method, req.url, res.body);
    }
}
