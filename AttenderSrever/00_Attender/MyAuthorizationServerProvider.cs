using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using _03_BLL;

namespace _00_Attender
{
    public class MyAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private MemberManager memberBll = new MemberManager();
        public string str;
        public string Password;
        public string Email;
        public string Role;
        public string Name;

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            try
            {
                str = memberBll.getPassAndMail(context.UserName, context.Password);
                Password = str.Substring(0, 64);
                Email = str.Substring(64);
                Role = memberBll.CheckValidation(Email, Password);
                Name = memberBll.getName(Email, Password);

                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                if (context.UserName == Email && context.Password == Password)
                {
                    identity.AddClaim(new Claim(ClaimTypes.Role, Role));
                    identity.AddClaim(new Claim("Email", Email));
                    identity.AddClaim(new Claim(ClaimTypes.Name, Name));
                    context.Validated(identity);

                }
            }
            catch
            {
                context.SetError("Invalid Grant", "Provided username amd password is incorrect");
                return;
            }
        }
    }
}