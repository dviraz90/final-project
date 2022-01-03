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
    [RoutePrefix("api/lessonTime")]
    public class LessonTimeController : ApiController
    {
        private LessonTimeManager LessonTimeBll = new LessonTimeManager();
        [HttpGet]
        [Route("all")]
        public List<LessonTimeModel> Get()
        {
            return LessonTimeBll.GetAllLessonTimes();
        }

        [HttpGet]
        [Route("id/{id}")]
        public IHttpActionResult Get([FromUri]int id)
        {
            LessonTimeModel lessonTime = LessonTimeBll.GetLessonTimeById(id);
            if (lessonTime != null) return Ok(lessonTime);
            return NotFound();
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult post([FromBody]LessonTimeModel value)
        {
            if (ModelState.IsValid)
            {
                bool succsess = LessonTimeBll.AddLessonTime(value);
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
        public IHttpActionResult Put([FromUri]int id, [FromBody]LessonTimeModel value)
        {
        if (ModelState.IsValid)
        {
            bool succsess = LessonTimeBll.UpdateLessonTime(id, value);
            if (succsess)
                return Ok();
        }
            return BadRequest();
        }
        [HttpDelete]
        [Route("id/{id}")]
        public IHttpActionResult Delete([FromUri]int id)
        {
            bool succsess = LessonTimeBll.DeleteLessonTime(id);
            if (succsess)
                return Ok();
            return BadRequest();
        }

        [HttpGet]
        [Route("date/{dateOnly}/hour/{hourOnly}/Lecture/{lecturerId}")]
        public IHttpActionResult Get([FromUri]string dateOnly, [FromUri]string hourOnly, [FromUri]int lecturerId)
        {
            int lessonId = LessonTimeBll.CheckLessonIdIsNow(dateOnly, hourOnly, lecturerId);
            if (lessonId != -1) return Ok(lessonId);
            return NotFound();
        }

        [HttpGet]
        [Route("dateOnly/{dateOnly}/hourOnly/{hourOnly}")]
        public IHttpActionResult Get1([FromUri]string dateOnly, [FromUri]string hourOnly)
        {
            int courseId = LessonTimeBll.CheckWhatLessonIsNow(dateOnly, hourOnly);
            if (courseId != null) return Ok(courseId);
            return NotFound();
        }

        [HttpGet]
        [Route("GetLessonTime/{lessonTimeId}")]
        public IHttpActionResult GetLessonTime([FromUri]int lessonTimeId)
        {
            string lessonTime = LessonTimeBll.GetLessonTimeByLessonId(lessonTimeId);
            if (lessonTime != null) return Ok(lessonTime);
            return NotFound();
        }
        [HttpGet]
        [Route("GetLessonDate/{SelectedItem}")]
        public IHttpActionResult GetLessonDate([FromUri]int SelectedItem)
        {
            string lessonDate = LessonTimeBll.GetLessonDateByLessonId(SelectedItem);
            if (lessonDate != null) return Ok(lessonDate);
            return NotFound();
        }

        [HttpGet]
        [Route("GetLessonCode/{lessonTimeId}")]
        public IHttpActionResult GetLessonCode([FromUri]int lessonTimeId)
        {
            int lessonCode = LessonTimeBll.GetLessonCodeByLessonId(lessonTimeId);
            if (lessonCode != null) return Ok(lessonCode);
            return NotFound();
        }

        [HttpGet]
        [Route("d/{d}/h/{h}")]
        public IHttpActionResult GetIds([FromUri]string d, [FromUri]string h)
        {
            List<int> lessonTimes = new List<int>();
            lessonTimes = LessonTimeBll.GetAllLessonIdsNow(d, h);
            if (lessonTimes != null) return Ok(lessonTimes);
            return NotFound();
        }
    }
}

