import { EmployeeModel } from './../../Model/EmployeeModel';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EmployeeServiceService {

  constructor(private http: HttpClient) { }
  headers = {
    headers : new HttpHeaders({
      'Content-Type': 'application/json;charset=utf-8'
    }),
    withCredentials: true
  };
  GetEmployees(): Observable<EmployeeModel[]>{
    debugger;
    return this.http.get<EmployeeModel[]>("https://localhost:7145/api/Employee/GetAllEmployees").pipe();
  }
  DeleteEmployee(id: number) {
    return this.http.delete('https://localhost:7145/api/Employee/' + id);
  }
  CreateEmployee(Emp: EmployeeModel ): Observable<EmployeeModel>{
    return this.http.post<EmployeeModel>('https://localhost:7145/api/Employee/CreateEmployee', Emp).pipe();
  }
  GetEmployeeById(id: string): Observable<EmployeeModel>{
    return this.http.get<EmployeeModel>('https://localhost:7145/api/Employee/GetEmployeeById/' + id).pipe();
  }
  UpdateEmployee(id: string, prod: EmployeeModel): Observable<EmployeeModel>{
    return this.http.post<EmployeeModel>('https://localhost:7145/api/Employee/UpdateEmployee/' + id, prod).pipe();
}
GetNetSalary(Salary: number) {
  return this.http.delete('https://localhost:7145/api/Employee/' + Salary);
}

}
