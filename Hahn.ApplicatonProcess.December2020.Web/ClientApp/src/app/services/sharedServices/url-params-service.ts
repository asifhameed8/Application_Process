import { Injectable } from '@angular/core';

@Injectable()
export class UrlParamService {
    constructor() { }

    getCurrentPath(): string {
        return window.location.pathname;
    }
    getlastParameter(): string {
        let path = window.location.pathname.split('/');
        let lastParameter: string = path[path.length - 1];
        if (lastParameter && lastParameter.trim()) {
            lastParameter = lastParameter.trim();
            return lastParameter;
        }
        return "";
    }

}
