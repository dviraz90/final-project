using _00_Attender.Filters;
using _03_BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;

namespace _00_Attender.Controllers
{
    [RoutePrefix("api/register")]
    public class RegisterController : ApiController
    {
        private MemberManager memberBll = new MemberManager();     

        public class person
        {
            public string passport { get; set; }
            public string password { get; set; }
            public string mac { get; set; }
        }

        // Submit: api/Register/submit
        [HttpPost]
        [Route("submit")]
        public bool Submit([FromBody] person data)
        {
            string macAddress = data.mac;
            string pattern = @"^([0-9A-Fa-f]{2}[:-]){5}([0-9A-Fa-f]{2})$";
            Match match = Regex.Match(macAddress, pattern);
            if (match.Success)
            {
                bool success = memberBll.CheckRegistration(data.passport, data.password, data.mac);
                return success;
            }
            return false;
                
        }

        [HttpGet]
        [Route("token")]
        public IHttpActionResult Get1()
        {
            Startup strtup = new Startup();
            int ExpireToken = strtup.LifeToken;
            if (ExpireToken != null) return Ok(ExpireToken);
            return NotFound();
        }
    }
}