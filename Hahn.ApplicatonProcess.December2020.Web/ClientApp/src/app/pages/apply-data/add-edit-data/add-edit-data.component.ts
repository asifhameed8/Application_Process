import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ApplyData } from 'src/app/model/apply-data';
import { ApplyDataService } from 'src/app/services/apply-data-service/apply-data-service';

@Component({
  selector: 'app-add-edit-data',
  templateUrl: './add-edit-data.component.html',
  styleUrls: ['./add-edit-data.component.scss']
})
export class AddEditDataComponent implements OnInit {
  displayedColumns = ['name', 'familyName', 'address', 'countryOfOrigin', 'emailAddress','age', 'hired' , 'actions'];
  formData:ApplyData[];
  applyData:ApplyData;
  addEdit = '' ;
  isValidateName = false;
  dataForm: FormGroup;
  submitted = false;
  constructor(private router: Router, private dataService:ApplyDataService, private formBuilder: FormBuilder) 
  {
  this.applyData = new ApplyData(); 
  }
  ngOnInit() {
    let Id = localStorage.getItem("id");
    this.addEdit = (Id) ? "Update" : "Create";
    this.getDataById(Id);
    
    this.dataForm = this.formBuilder.group({
      name: ['', [Validators.required]],
      familyName: ['', [Validators.required]],
      Address: ['', [Validators.required]],
      countryOfOrigin: ['', [Validators.required]],
      emailAddress: ['', [Validators.required, Validators.email]],
      age: ['Please enter valid age', [Validators.required, Validators.min(20), Validators.max(60)]],
			hired: [''],
		});
  }
  getDataById(Id:any)
  {
    if (Id!= null){
    this.dataService.getDataById(Id)

    .subscribe(
      data => {
        debugger
        this.applyData=data;
        
      },
      error => {
      console.log('Some Error');
      }
    );
  }
  }
  // After submission, component emits event signaling the parent app to add the new TodoItem.
  onSubmit(): void { 
    
      this.submitted = true;
  
      // stop here if form is invalid
      if (this.dataForm.invalid) {
        return;
      }
      this.dataService.saveData(this.applyData)
      .subscribe(
        data => {
          debugger
          this.router.navigate(['/applydata']);
        },
        error => {
        console.log('Some Error');
        }
      );
    this.applyData = new ApplyData();
    
  }

  //Reset
  onReset(): void {
    this.dataForm.reset();
  }
}
