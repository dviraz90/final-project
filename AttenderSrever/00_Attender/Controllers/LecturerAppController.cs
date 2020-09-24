using _00_Attender.Filters;
using _02_BOL;
using _03_BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _00_Attender.Controllers
{
    [RoutePrefix("api/App")]
    public class LecturerAppController : ApiController
    {
        private CourseManager courseBll = new CourseManager();

        [HttpGet]
        [MemberAuthFilter]
        [Authorize(Roles = "a,s,l,h")]
        [Route("id/{id}")]
        public IHttpActionResult Get([FromUri]int id)
        {
            List<string> Course = courseBll.GetAllCourses(id);

            if (Course != null) return Ok(Course);
            return NotFound();
        }
    }
}
