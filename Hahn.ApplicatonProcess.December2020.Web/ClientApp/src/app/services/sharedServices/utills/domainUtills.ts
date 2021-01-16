import { urls } from "../enums/enums";

export class domainUtills {
    
    public getEnvirementUrl(): string {
        let host = window.location.hostname;
        if (host.includes('localhost')) {
            return urls.dev;
        }
        return urls.prod;
    }
    public static getApiUrlForResouces(): string {
        let host = window.location.hostname;
        if (host.includes('localhost')) {
            return urls.dev;
        }
        return urls.prod;
    }
}