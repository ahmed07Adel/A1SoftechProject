import { EmployeeModel } from './../../Model/EmployeeModel';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { EmployeeServiceService } from '../Service/employee-service.service';

@Component({
  selector: 'app-create-new-employee',
  templateUrl: './create-new-employee.component.html',
  styleUrls: ['./create-new-employee.component.scss']
})
export class CreateNewEmployeeComponent implements OnInit {
EmpFormGroup!:FormGroup;
Empl!:EmployeeModel;
  constructor(private service:EmployeeServiceService, private fb:FormBuilder) {
    this.EmpFormGroup = new FormGroup({
      name : new FormControl(),
      mobile: new FormControl(),
      email: new FormControl(),
      salary:new FormControl()
    });
  }
  messageValidate = {
    email:{
      required: 'Email Needed',
      matchE: 'EmailShouldbe End With:@gmail.com(Example@gmail.com)'
    },
  }
  ngOnInit(): void {
    this.Empl ={
         id:0,
         name :'',
         salary:0,
         email:'',
         mobile:0
    };
this.EmpFormGroup =  this.fb.group({
  name: ['', Validators.required],
  mobile: ['', Validators.required],
  email: ['', [Validators.required, Validators.email, Validators.pattern('^.+@gmail.com$')]],
  salary: ['', Validators.required],
});
  }
  ValidateEmployeeModel(){
    debugger;
    this.Empl.name = this.EmpFormGroup.value.name;
    this.Empl.email = this.EmpFormGroup.value.email;
    this.Empl.mobile = this.EmpFormGroup.value.mobile;
    this.Empl.salary = this.EmpFormGroup.value.salary;
  }
  CreateEmployee(){
    debugger;
    if (this.EmpFormGroup.valid) {
      this.ValidateEmployeeModel();
      this.service.CreateEmployee(this.Empl).subscribe(success=>{
        alert('Employee Created Successfully');
      },err => console.log(err));
    }
  }
  isEmailValid(){
    debugger;
    if(this.Empl.email.includes("@gmail.com")){
      return true;
    }
    return false;
  }
}
