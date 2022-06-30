using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Employee : BaseEntity
    {
        public string Name { get; set; }
        public int Mobile { get; set; }
        public string Email { get; set; }
        public float Salary { get; set; }

    }
}
