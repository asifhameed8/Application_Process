import { ApplyData } from '../../model/apply-data';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { httpCaller } from '../sharedServices/httpCaller.service';
import { httpType } from '../sharedServices/enums/enums';
import { HttpClient } from '@angular/common/http';
import { retry } from 'rxjs/operators';

@Injectable()
export class ApplyDataService {
  data: ApplyData[];
  private accessPointUrl: string = 'https://localhost:44373/';
 constructor(private httpCaller: httpCaller, private http: HttpClient) { }
 
  getData(): Observable<any> {
     return this.http.get(this.accessPointUrl+'ApplyData/GetData');
    }
    getDataById(Id:any): Observable<any> {
      return this.http.get(this.accessPointUrl+'ApplyData/GetDataById?ID='+Id);
      }
   saveData(data: ApplyData): Observable<any> {
     return this.http.post(this.accessPointUrl+'ApplyData/SaveData',data);
  }
  
deleteData(data: any): Observable<any> {
  return this.http.delete(this.accessPointUrl+'ApplyData/DeleteData?ID='+data.id);

}
}
