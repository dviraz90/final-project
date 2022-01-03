using System.ComponentModel.DataAnnotations;

namespace _02_BOL.Validations
{
    public class DigitsOnlyAttribute: ValidationAttribute
    {
        public DigitsOnlyAttribute(): base("value is not valide")
        {
        }
        public DigitsOnlyAttribute(string msg):base(msg)
        {
        }
        public override bool IsValid(object value)
        {
            string str = value.ToString();
            for(int i = str.Length - 1; i >= 0; i--)
			if (str[i] > '9' || str[i] < '0')
                return false;
            return true;
        }
    }
}

