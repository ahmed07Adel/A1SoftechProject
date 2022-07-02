using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class EmployeeDBContext : DbContext
    {
        public EmployeeDBContext(DbContextOptions<EmployeeDBContext> options) : base(options)   
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeTax> EmployeeTaxes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
    
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id=1, Email = "Ahmed@Gmail.Com", Mobile=012334, Name="Ahmed", Salary=2000 },
                new Employee { Id=2, Email = "Ali@Gmail.Com", Mobile=3435454, Name="ali", Salary=3000 }
                );
        }
    }
}
