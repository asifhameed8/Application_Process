import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { retry } from 'rxjs/operators';
import { ApplyData } from 'src/app/model/apply-data';
import { ApplyDataService } from 'src/app/services/apply-data-service/apply-data-service';

@Component({
  selector: 'app-apply-data',
  templateUrl: './apply-data.component.html',
  styleUrls: ['./apply-data.component.scss']
})
export class ApplyDataComponent implements OnInit {
  headElements = ['Name', 'Family Name', 'Address', 'Country Of Origin', 'Email Address','Age', 'Hired' , 'actions'];
  formData:ApplyData[];
  startDate:Date;
  actionButton: string;
  sDate:string;
  eDate:string;
  filterButton: string;
  isMobile : boolean;
  endDate:Date; search:string;
  constructor(private router: Router, private dataService:ApplyDataService) 
  {
    this.getFormData();
  }
  ngOnInit() {
    
  }
  getFormData()
  {
    this.dataService.getData()
    .subscribe(
      data => {
        this.formData=data;
        
      },
      error => {
      console.log('Some Error');
      }
    );
  }
  //add data
  addData($myParam: string = ''): void {
    localStorage.clear();
    const navigationDetails: string[] = ['/adddata'];
    if($myParam.length) {
      navigationDetails.push($myParam);
    }
    this.router.navigate(navigationDetails);
  }
  edit(id:any,$myParam: string = ''){
    localStorage.setItem("id",id);
    const navigationDetails: string[] = ['/adddata'];
    if($myParam.length) {
      navigationDetails.push($myParam);
    }
    this.router.navigate(navigationDetails);
  }
    // Delete an item off the list.
    deleteFormData(applicant: ApplyData): void {
      debugger
      this.dataService.deleteData(applicant)
      .subscribe(
        res => {
         this.formData = res;
         this.getFormData();
  
        },
        err => {
            console.log(err);
        }
    );
      this.getFormData();
    }
}
