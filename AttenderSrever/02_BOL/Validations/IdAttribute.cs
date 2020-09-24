using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_BOL.Validations
{
    public  class IdAttribute: ValidationAttribute
    {
        
        public IdAttribute(): base("value is not valide")
        {
        }
        public IdAttribute(string msg):base(msg)
        {
        }
        public override bool IsValid(object value)
        {
           string Id = value.ToString();
            int[] arr = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] sec = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] third = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int i, index = 8, sum = 0;

            for (i = 0; i < 9; i++)
                arr[i] = 0;
            for (i = 0; i < 9; i++)
            {
                if (i % 2 == 0)
                    sec[i] = 1;
                else
                    sec[i] = 2;
            }
            for (i = Id.Length - 1; i >= 0; i--)
                arr[index--] = Id[i] - '0';

            for (i = 0; i < 9; i++)
                third[i] = arr[i] * sec[i];

            for (i = 0; i < 9; i++)
                if (third[i] > 9)
                    third[i] = third[i] % 10 + third[i] / 10;

            for (i = 0; i < 9; i++)
                sum += third[i];

            if (sum % 10 != 0)
                return false;

            return true;
        }
    }

}

    

