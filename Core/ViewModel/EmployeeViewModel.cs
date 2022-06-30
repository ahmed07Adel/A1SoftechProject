using Core.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ViewModel
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Mobile { get; set; }
        [Required]
        [EmailAddress]
        [ValidEmailDomain(AllowDomain: "Gmail.com", ErrorMessage = "Email Must Be Gmail.com")]
        public string Email { get; set; }
        public float Salary { get; set; }
    }
}
