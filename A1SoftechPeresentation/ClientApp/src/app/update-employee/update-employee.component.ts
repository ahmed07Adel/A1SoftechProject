import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { EmployeeModel } from './../../Model/EmployeeModel';
import { EmployeeServiceService } from './../Service/employee-service.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Guid } from 'guid-typescript';
@Component({
  selector: 'app-update-employee',
  templateUrl: './update-employee.component.html',
  styleUrls: ['./update-employee.component.scss']
})
export class UpdateEmployeeComponent implements OnInit {
sal: number = 0;
Employee!:EmployeeModel;
EmpFormGroup!: FormGroup;
NetSalary!:number;
taxPaid!:number;
  constructor(private service: EmployeeServiceService,private activeRoute: ActivatedRoute,private fb:FormBuilder)
   {
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
    debugger;

    this.Employee ={
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
      this.activeRoute.params.subscribe(params => {
          const id = params.id;
          this.service.GetEmployeeById(id).subscribe(c => {
          this.EmpFormGroup.patchValue(c);
          this.Employee = c;
          var x =  this.Employee.salary;
          const PercentTaxValue = 0.1;
          this.taxPaid = x * PercentTaxValue;
          this.NetSalary = x - this.taxPaid;
    }, err => console.log(err));
    }, err => console.log(err));



  }
  ValidateEmployeeModel(){
    debugger;
    this.Employee.name = this.EmpFormGroup.value.name;
    this.Employee.email = this.EmpFormGroup.value.email;
    this.Employee.mobile = this.EmpFormGroup.value.mobile;
    this.Employee.salary = this.EmpFormGroup.value.salary;
  }
  GetNetSalary(salary:number)
  {
    this.service.GetNetSalary(salary).subscribe(s => {
      return s;
    }, err => console.log(err));
  }
  Update(id: string) {
    if (this.EmpFormGroup.valid) {
      this.ValidateEmployeeModel();
      this.service.UpdateEmployee(id, this.Employee).subscribe(success => {
        alert('Product Updated Successfully');
        window.location.reload();
      }, err => console.log(err));
  }
}

}
