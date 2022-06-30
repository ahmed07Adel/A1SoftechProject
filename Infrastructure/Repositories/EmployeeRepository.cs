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

        public Task<EmployeeTax> CalculateEmployeeTax(EmployeeTax CalcEmployeeTax)
        {
            
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
            var res = await context.Employees.FirstOrDefaultAsync(x => x.Id == EmployeeID);
            return res;
        }

        public async Task<Employee> UpdateEmployee(EmployeeViewModel employee)
        {
            var res = await context.Employees.FirstOrDefaultAsync(x => x.Id == employee.Id);
            if (res != null)
            {
                res.Name = employee.Name;
                await context.SaveChangesAsync();
                return res;
            }
            return null;
        }
    }
}
