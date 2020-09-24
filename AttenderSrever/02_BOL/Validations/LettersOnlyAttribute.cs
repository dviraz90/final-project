using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_BOL.Validations
{
    public  class LettersOnlyAttribute: ValidationAttribute
    {
        public LettersOnlyAttribute(): base("value is not valide")
        {
        }
        public LettersOnlyAttribute(string msg):base(msg)
        {
        }
        public override bool IsValid(object value)
        {
            string str = value.ToString();

            for (int i = str.Length - 1; i >= 0; i--)
                if (!((str[i] >= 'a' && str[i] <= 'z') || (str[i] >= 'A' && str[i] <= 'Z')))
                    return false;
            return true;
        }
    }
 }

