using Core.Entities;
using Core.Interfaces;
using Core.ViewModel;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDBContext context;
        public EmployeeRepository(EmployeeDBContext context)
        {
            this.context=context;
        }
       
        public async Task<EmployeeTax> CalculateEmployeeTax(EmployeeTax CalcEmployeeTax)
        {
            var res = await context.EmployeeTaxes.AddAsync(CalcEmployeeTax);
            await context.SaveChangesAsync();
            return res.Entity;
        }
        public async Task<Employee> CreateEmployee(Employee newemployee)
        {
            var res = await context.Employees.AddAsync(newemployee);
            await context.SaveChangesAsync();
            return res.Entity;
        }


        public async Task<Employee> DeleteEmployee(int EmployeeID)
        {
            var res = await context.Employees.FirstOrDefaultAsync(e => e.Id == EmployeeID);
            if (res != null)
            {
                context.Employees.Remove(res);
                await context.SaveChangesAsync();
                return res;
            }
            return null;
        }

        public async Task<IEnumerable> GetAllEmployees()
        {
            var res = await context.Employees.ToListAsync();
            return res;
        }

        public async Task<Employee> GetEmployeeByID(int EmployeeID)
        {
            var res = await context.Employees
                .FirstOrDefaultAsync(x => x.Id == EmployeeID);         
            return res;
        }     
        public async Task<EmployeeTax> UpdateCalculateEmployeeTax(EmployeeTax CalcEmployeeTax)
        {
            var res = await context.EmployeeTaxes.FirstOrDefaultAsync(x => x.EmployeeId == CalcEmployeeTax.EmployeeId);
            if (res != null)
            {
                res.NetSalary = CalcEmployeeTax.NetSalary;
                await context.SaveChangesAsync();
                return res;
            }
            return null;
        }

        public async Task<float?> GetEmployeeNetSalary(int employeeId)
        {
            var employeeTax = await context.EmployeeTaxes.FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
            return employeeTax?.NetSalary;
        }
        public async Task<Employee> UpdateEmployee(EmployeeViewModel employee)
        {
            var res = await context.Employees.FirstOrDefaultAsync(x => x.Id == employee.Id);
            if (res != null)
            {
                res.Name = employee.Name;
                res.Salary = employee.Salary;
                res.Mobile = employee.Mobile;
                res.Email = employee.Email;
                await context.SaveChangesAsync();
                return res;
            }
            return null;
        } 
    }
}
