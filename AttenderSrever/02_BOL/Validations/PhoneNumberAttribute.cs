using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _02_BOL
{
   public class PhoneNumber:ValidationAttribute
    {
        public PhoneNumber(): base("value is not valide")
        {
        }
        public PhoneNumber(string msg):base(msg)
        {
        }
        public override bool IsValid(object value)
        {
            string input = value.ToString();
            string pattern = @"^(05[0-9])[0-9]{7}|(0[1-9])[0-9]{7}|1800[0-9]{6}$";
            Match match = Regex.Match(input, pattern);
            if (match.Success) return true;
            return false;
            
        }

    }
}
