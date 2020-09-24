using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace _02_BOL.Validations
{
    public class IsMailValideAttribute : ValidationAttribute
    {

        public IsMailValideAttribute() : base("value is not valide")
        {
        }
        public IsMailValideAttribute(string msg) : base(msg)
        {
        }
        public override bool IsValid(object value)
        {
            string emailaddress = value.ToString();
            string pattern = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Match match = Regex.Match(emailaddress, pattern);
            if(match.Success)
                return true;
            return false;
        }
    }
}