import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { httpType } from '../sharedServices/enums/enums';
import { domainUtills } from '../sharedServices/utills/domainUtills';
import { Observable, throwError,Subject } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
@Injectable()
export class httpCaller {
  uri = "";
  constructor(private http: HttpClient) {
  }
  public apiCaller(type: string, url: string, data?: any): any {
    this.uri = new domainUtills().getEnvirementUrl() + url;
    if (type === httpType.get) {
      return this.get(this.uri)
    }
    else {
      return this.post(this.uri, data)
    }
  }
  // genereic post
  private post(url: string, data: any): any {
    
    return this.http.post(url, data,{ headers: this.getHeaders() })
       }
  // generic get
  private get(url: string): any 
  {
    return this.http.get(url,{ headers: this.getHeaders() })
  }
  // get headers data
  private getHeaders(): HttpHeaders {
    let headers = new HttpHeaders();
    headers.append('Access-Control-Allow-Origin', '*');
    headers.append('Access-Control-Allow-Methods', 'GET,POST,OPTIONS,DELETE,PUT');
    
    return headers;
  }
  handleError(error) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      // client-side error
      errorMessage = `Error: ${error.error.message}`;
    } else {
      // server-side error
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    window.alert(errorMessage);
    return throwError(errorMessage);
  }
}
