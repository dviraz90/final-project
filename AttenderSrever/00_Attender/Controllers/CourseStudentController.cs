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
    [RoutePrefix("api/courseStudent")]
    public class CourseStudentController : ApiController
    {
        private CourseStudentManager courseStudentBll = new CourseStudentManager();
        [HttpGet]
        [Route("all")]
        public List<CourseStudentModel> Get()
        {
            return courseStudentBll.GetAllCourseStudent();
        }
        [HttpGet]
        [Route("id/{id}")]
        public IHttpActionResult Get([FromUri]int id)
        {
            CourseStudentModel courseStudent = courseStudentBll.GetCourseStudentById(id);
            if (courseStudent != null) return Ok(courseStudent);
            return NotFound();
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult post([FromBody]CourseStudentModel value)
        {
            if (ModelState.IsValid)
            {
                bool succsess = courseStudentBll.AddCourseStudent(value);
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
        public IHttpActionResult Put([FromUri]int id, [FromBody]CourseStudentModel value)
        {
            if (ModelState.IsValid)
            {
                bool succsess = courseStudentBll.UpdateCourseStudent(id, value);
                if (succsess)
                    return Ok();
            }
            return BadRequest();
        }
        [HttpDelete]
        [Route("id/{id}")]
        public IHttpActionResult Delete([FromUri]int id)
        {
            bool succsess = courseStudentBll.DeleteCourseStudent(id);
            if (succsess)
                return Ok();
            return BadRequest();
        }

        [HttpGet]
        [Route("courseId/{courseId}")]
        public IHttpActionResult Get1([FromUri]int courseId)
        {

            List<string> courseStudent = courseStudentBll.GetAllCurrentStudents(courseId);
            if (courseStudent != null) return Ok(courseStudent);
            return NotFound();
        }

        [HttpGet]
        [Route("CheckIfExists/studentId/{studentId}/courseId/{courseId}")]
        public IHttpActionResult GetExists([FromUri]int studentId, [FromUri]int courseId)
        {
            bool exists = courseStudentBll.CheckIfExists(studentId, courseId);
            if (exists != false) return Ok(exists);
            return NotFound();
        }
        [HttpDelete]
        [Route("DeleteStudentFromAll/{memberId}")]
        public IHttpActionResult DeleteAll([FromUri]int memberId)
        {
            bool deletAll = courseStudentBll.DeleteStudentFromAll(memberId);
            if (deletAll != false) return Ok(deletAll);
            return NotFound();
        }
    }
}