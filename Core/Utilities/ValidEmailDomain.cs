using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities
{
    public class ValidEmailDomain : ValidationAttribute
    {
        private readonly string AllowDomain;
        public ValidEmailDomain(string AllowDomain)
        {
            this.AllowDomain = AllowDomain;
        }
        public override bool IsValid(object Value)
        {
            string[] strings = Value.ToString().Split('@');
            return strings[1].ToUpper() == AllowDomain.ToUpper();

        }
    }
}
