using Core.Entities;
using Core.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<Employee> CreateEmployee(Employee newemployee);
        Task<IEnumerable> GetAllEmployees();
        Task<Employee> GetEmployeeByID(int EmployeeID);
        Task<Employee> UpdateEmployee(EmployeeViewModel employee);
        Task<Employee> DeleteEmployee(int EmployeeID);
        Task<EmployeeTax> CalculateEmployeeTax(EmployeeTax CalcEmployeeTax);
        Task<EmployeeTax> UpdateCalculateEmployeeTax(EmployeeTax CalcEmployeeTax);
        Task<float?> GetEmployeeNetSalary(int employeeId);
    }
}
