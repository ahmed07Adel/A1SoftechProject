import { EmployeeModel } from './../../Model/EmployeeModel';
import { EmployeeServiceService } from './../Service/employee-service.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.scss']
})
export class EmployeeListComponent implements OnInit {
Employee!: EmployeeModel[];

  constructor(private service:EmployeeServiceService) { }

  ngOnInit(): void {
    this.service.GetEmployees().subscribe(a=>{
      this.Employee = a;
    }, err => console.log(err));
  }
  DeleteEmployee(id: number) {
    this.service.DeleteEmployee(id).subscribe(success => {
      alert('Employee Deleted');
      window.location.reload();
    }, err => console.log(err));
  }

}
