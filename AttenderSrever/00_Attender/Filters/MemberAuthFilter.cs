using _03_BLL;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using System.Web.Http.Results;

namespace _00_Attender.Filters
{
    public class MemberAuthFilter : Attribute, IAuthenticationFilter
    {
        public string Password;
        public string Email;
        public string Role;
        private MemberManager memberBll = new MemberManager();


        public bool AllowMultiple { get { return false; } }
        public Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            var authHead = context.Request.Headers.Authorization;
            if (authHead != null && authHead.Scheme == "Basic")
            {
                Password = authHead.Parameter.Substring(0, 64);
                Email = authHead.Parameter.Substring(64);
                Role = memberBll.CheckValidation(Email, Password);

                if (Role != null)
                {
                    var claims = new List<Claim>() {new Claim(ClaimTypes.Role, Role) };
                    var id = new ClaimsIdentity(claims, "Token");
                    context.Principal = new ClaimsPrincipal(new[] { id });
                }
                else
                {
                    context.ErrorResult = new UnauthorizedResult(new AuthenticationHeaderValue[0], context.Request);
                }
            }
            return Task.FromResult(0);
        }
        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            return Task.FromResult(0);
        }
    }
}