using _02_BOL;
using _03_BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Attender.Controllers
{
    [RoutePrefix("api/university")]
    public class UniversityController : ApiController
    {
        private UniversityManager universityBll = new UniversityManager();
        [HttpGet]
        [Route("all")]
        public List<UniversityModel> Get()
        {
            return universityBll.GetAllUniversities();
        }

        [HttpGet]
        [Route("id/{id}")]
        public IHttpActionResult Get([FromUri]int id)
        {
            UniversityModel university = universityBll.GetUniversityById(id);
            if (university != null) return Ok(university);
            return NotFound();
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult post([FromBody]UniversityModel value)
        {
            if (ModelState.IsValid)
            {
                bool succsess = universityBll.AddUniversity(value);
                if (succsess)
                    return Ok();
                return BadRequest();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpPut]
        [Route("id/{id}")]
        public IHttpActionResult Put([FromUri]int id, [FromBody]UniversityModel value)
        {
            if (ModelState.IsValid)
            {
                bool succsess = universityBll.UpdateUniversity(id, value);
                if (succsess)
                    return Ok();
            }
            return BadRequest();
        }
        [HttpDelete]
        [Route("id/{id}")]
        public IHttpActionResult Delete([FromUri]int id)
        {
            
                bool succsess = universityBll.DeleteUniversity(id);
                if (succsess)
                    return Ok();
               
            return BadRequest();
        }
    }
}


