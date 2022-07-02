import { EmployeeModel } from './../../Model/EmployeeModel';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EmployeeServiceService } from '../Service/employee-service.service';
import { FormControl, FormGroup, Validators, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-view-employee',
  templateUrl: './view-employee.component.html',
  styleUrls: ['./view-employee.component.scss']
})
export class ViewEmployeeComponent implements OnInit {
  Emp!:EmployeeModel;
  id!: string;
  EmpFormGroup!: FormGroup;
  NetSalary!:number;
taxPaid!:number;
  constructor(private service: EmployeeServiceService,private activeRoute: ActivatedRoute,private fb: FormBuilder) {
    this.EmpFormGroup = new FormGroup({
      name : new FormControl(),
      mobile: new FormControl(),
      email: new FormControl(),
      salary:new FormControl()
    });
  }
  ngOnInit(): void {
    this.EmpFormGroup =  this.fb.group({
      id:['',Validators.required],
      name: ['', Validators.required],
      mobile: ['', Validators.required],
      email: ['', [Validators.required, Validators.email, Validators.pattern('^.+@gmail.com$')]],
      salary: ['', Validators.required],
    });
    this.activeRoute.params.subscribe(params => {
      this.id = params.id;
      this.service.GetEmployeeById(this.id).subscribe(c => {
      this.EmpFormGroup.patchValue(c);
      this.Emp = c;
      var x =  this.Emp.salary;
      const PercentTaxValue = 0.1;
      this.taxPaid = x * PercentTaxValue;
      this.NetSalary = x - this.taxPaid;
}, err => console.log(err));
}, err => console.log(err));
  }
}
