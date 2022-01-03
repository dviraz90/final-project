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
    [RoutePrefix("api/course")]
    public class CourseController : ApiController
    {
        private CourseManager courseBll = new CourseManager();
        [HttpGet]
        [Route("all")]
        public List<CourseModel> Get()
        {
            return courseBll.GetAllCourses();

        }
        [HttpGet]
        [Route("id/{id}")]
        public IHttpActionResult Get([FromUri]int id)
        {
            CourseModel course = courseBll.GetCourseById(id);
            if (course != null) return Ok(course);
            return NotFound();
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult post([FromBody]CourseModel value)
        {
            if (ModelState.IsValid)
            {
                bool succsess = courseBll.AddCourse(value);
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
        public IHttpActionResult Put([FromUri]int id, [FromBody]CourseModel value)
        {
            if (ModelState.IsValid)
            {
                bool succsess = courseBll.UpdateCourse(id, value);
                if (succsess)
                    return Ok();
            }
            return BadRequest();
        }
        [HttpDelete]
        [Route("id/{id}")]
        public IHttpActionResult Delete([FromUri]int id)
        {
            bool succsess = courseBll.DeleteCourse(id);
            if (succsess)
                return Ok();
            return BadRequest();
        }
        [HttpGet]
        [Route("courseId/{courseId}/id/{id}")]
        public IHttpActionResult Get1([FromUri]int courseId, [FromUri]int id)
        {
            string course = courseBll.GetCourseNameById(courseId, id);
            if (course != null) return Ok(course);
            return NotFound();
        }

        [HttpGet]
        [Route("LectureId/{lectureId}/dateOnly/{dateOnly}/hourOnly/{hourOnly}")]
        public IHttpActionResult GetCheck([FromUri]int lectureId, [FromUri]string dateOnly, [FromUri]string hourOnly)
        {
            int ans = courseBll.CheckIfLeccture(lectureId, dateOnly, hourOnly);
            if (ans != null) return Ok(ans);
            return NotFound();
        }
        [HttpGet]
        [Route("GetAllCourses/all")]
        public IHttpActionResult GetAllCourses()
        {
            List<string> ans = courseBll.GetAllCoursespp();
            if (ans != null) return Ok(ans);
            return NotFound();
        }
    }
}
