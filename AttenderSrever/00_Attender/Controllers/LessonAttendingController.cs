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
    [RoutePrefix("api/lessonAttending")]
    public class LessonAttendingController : ApiController
    {
        private LessonAttendingManager lessonAttendingBll = new LessonAttendingManager();
        [HttpGet]
        [Route("all")]
        public List<LessonAttendingModel> Get()
        {
            return lessonAttendingBll.GetAllLessonAttending();
        }

        [HttpGet]
        [Route("id/{id}")]
        public IHttpActionResult Get([FromUri]int id)
        {
            LessonAttendingModel lessonAttending = lessonAttendingBll.GetLessonAttendingById(id);
            if (lessonAttending != null) return Ok(lessonAttending);
            return NotFound();
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult post([FromBody]LessonAttendingModel value)
        {
            if (ModelState.IsValid)
            {
                bool succsess = lessonAttendingBll.AddLessonAttending(value);
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
        public IHttpActionResult Put([FromUri]int id, [FromBody]LessonAttendingModel value)
        {
            if (ModelState.IsValid)
            {
                bool succsess = lessonAttendingBll.UpdateLessonAttending(id, value);
                if (succsess)
                    return Ok();
            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("id/{id}")]
        public IHttpActionResult Delete([FromUri]int id)
        {
            bool succsess = lessonAttendingBll.DeleteLessonAttending(id);
            if (succsess)
                return Ok();
            return BadRequest();
        }

        [HttpGet]
        [Route("lessonId/{id}")]
        public IHttpActionResult Get1([FromUri]int id)
        {
            List<int> idis = lessonAttendingBll.GetStudentsAttendingpp(id);
            if (idis != null) return Ok(idis);
            return NotFound();
        }

        [HttpDelete]
        [Route("DeleteAttending/{memberId}")]
        public IHttpActionResult DeleteAttending([FromUri]int memberId)
        {
            bool delete = lessonAttendingBll.DeleteStudentFromAttending(memberId);
            if (delete != false) return Ok(delete);
            return NotFound();
        }
    }
}
