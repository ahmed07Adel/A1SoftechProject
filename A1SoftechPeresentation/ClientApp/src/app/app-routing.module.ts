import { ViewEmployeeComponent } from './view-employee/view-employee.component';
import { UpdateEmployeeComponent } from './update-employee/update-employee.component';
import { CreateNewEmployeeComponent } from './create-new-employee/create-new-employee.component';
import { EmployeeListComponent } from './employee-list/employee-list.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {path: '', component:EmployeeListComponent },
  {path: 'home', component:EmployeeListComponent },
  {path: 'CreateEmployee', component:CreateNewEmployeeComponent },
  {path: 'UpdateEmployee/:id', component:UpdateEmployeeComponent },
  {path: 'EmployeeDetails/:id', component:ViewEmployeeComponent },
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
