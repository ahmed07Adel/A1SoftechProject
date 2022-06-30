using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class EmployeeTax : BaseEntity
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public float Tax { get; set; }
        public float NetSalary { get; set; }
    }
}
