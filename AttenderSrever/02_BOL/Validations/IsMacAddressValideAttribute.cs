using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _02_BOL.Validations
{
   public class IsMacAddressValideAttribute: ValidationAttribute
    {
        public IsMacAddressValideAttribute() : base("value is not valide")
        {
        }
        public IsMacAddressValideAttribute(string msg) : base(msg)
        {
        }
        public override bool IsValid(object value)
        {
            string macAddress = value.ToString();
            string pattern = @"^[0-9a-fA-F]{2}(((:[0-9a-fA-F]{2}){5})|((-[0-9a-fA-F]{2}){5}))$";
            Match match = Regex.Match(macAddress, pattern);
            if (match.Success) return true;
            return false;

        }
    }
}
