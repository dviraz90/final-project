using _00_Attender.Filters;
using _02_BOL;
using _02_BOL.Validations;
using _03_BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Security;

namespace Attender.Controllers
{
    [RoutePrefix("api/member")]
    public class MemberController : ApiController
    {
        private LettersOnlyAttribute lettersatrribute = new LettersOnlyAttribute();
        private IsMailValideAttribute mailattribute = new IsMailValideAttribute();
        private IdAttribute idattribute = new IdAttribute();
        private MemberManager memberBll = new MemberManager();

        [HttpGet]
        [MemberAuthFilter]
        //[Authorize(Roles = "a,l,h")]
        [Route("all")]
        public List<MemberModel> Get()
        {
            return memberBll.GetAllMembers();
        }

        [HttpGet]
        [MemberAuthFilter]
        //[Authorize(Roles = "a,s,l,h")]
        [Route("id/{id}")]
        public IHttpActionResult Get([FromUri]int id)
        {
            MemberModel member = memberBll.GetMemberById(id);
            if (member != null) return Ok(member);
            return NotFound();
        }
        [HttpPost]
        [MemberAuthFilter]
        //[Authorize(Roles = "a,h")]
        [Route("")]
        public IHttpActionResult post([FromBody]MemberModel value)
        {
            if (ModelState.IsValid)
            {
                bool succsess = memberBll.AddMember(value);
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
        [MemberAuthFilter]
        //[Authorize(Roles = "a,s,l,h")]
        [Route("id/{id}")]
        public IHttpActionResult Put([FromUri]int id, [FromBody]MemberModel value)
        {
            if (ModelState.IsValid)
            {
                bool succsess = memberBll.UpdateMember(id, value);
                if (succsess)
                    return Ok();
            }
            return BadRequest();
        }

        [HttpDelete]
        [MemberAuthFilter]
        //[Authorize(Roles = "a,h")]
        [Route("id/{id}")]
        public IHttpActionResult Delete([FromUri]int id)
        {
            bool success = memberBll.DeleteMember(id);
            if (success) return Ok();

            return BadRequest();
        }
        [HttpPost]
        [MemberAuthFilter]
        //[Authorize(Roles = "a,h")]
        [Route("mail")]

        public void Mail()
        {
            memberBll.SendMails();
        }

        [HttpPost]
        [MemberAuthFilter]
        //[Authorize(Roles = "a,h")]
        [Route("mail/passport/{passport}")]

        public void MailbyId([FromUri]string passport)
        {
            memberBll.SendMailsByPassportId(passport);
        }


        [HttpGet]
        //[Authorize(Roles = "a,s,l,h")]
        [Route("user/{user}/password/{password}")]
        public IHttpActionResult Get([FromUri]string user, [FromUri]string password)
        {
            string member = memberBll.getName(user, password);
            if (member != null) return Ok(member);
            return NotFound();
        }

        [HttpGet]
        [MemberAuthFilter]
        [Route("Iduser/{user}/Idpassword/{password}")]
        public IHttpActionResult Get1([FromUri]string user, [FromUri]string password)
        {
            int id = memberBll.getId(user, password);
            if (id != null) return Ok(id);
            return NotFound();
        }

        [HttpGet]
        [MemberAuthFilter]
        [Route("memberInfo/{id}")]
        public IHttpActionResult Get1([FromUri]int id)
        {
            string info = memberBll.GetMemberInfoById(id);
            if (info != null) return Ok(info);
            return NotFound();
        }

        [HttpGet]
        [MemberAuthFilter]
        [Route("courseId/{name}")]
        public IHttpActionResult GetCourseId([FromUri]string name)
        {
            int courseId = memberBll.getCourseId(name);
            if (courseId != null) return Ok(courseId);
            return NotFound();
        }


        [HttpGet]
        [MemberAuthFilter]
        [Route("allCourses/{id}")]
        public IHttpActionResult GetAllCourses([FromUri]int id)
        {
            List<string> courses = new List<string>();
            courses = memberBll.GetAllCoursesIdName(id);
            if (courses != null) return Ok(courses);
            return NotFound();
        }

        [HttpGet]
        [MemberAuthFilter]
        [Route("studentId/{studentId}")]
        public IHttpActionResult GetsId([FromUri]int studentId)
        {
            string member = memberBll.GetMemberDetailsById(studentId);
            if (member != null) return Ok(member);
            return NotFound();
        }

        [HttpGet]
        [MemberAuthFilter]
        [Route("specified/{selectedItem}")]
        public IHttpActionResult GetspecifiedId([FromUri]string selectedItem)
        {
            int specifiedId = memberBll.getIdByPassport(selectedItem);
            if (specifiedId != null) return Ok(specifiedId);
            return NotFound();
        }

        [HttpGet]
        [MemberAuthFilter]
        [Route("macAddress/{macAddress}")]
        public IHttpActionResult GetStudentId([FromUri]string macAddress)
        {
            int studentId = memberBll.getStudentIdByMac(macAddress);
            if (studentId != null) return Ok(studentId);
            return NotFound();

        }
        [HttpGet]
        [MemberAuthFilter]
        [Route("GetName/Mail/{mail}/Password/{password}")]
        public IHttpActionResult GetName([FromUri]string mail, [FromUri]string password)
        {
            string name = memberBll.getName(mail, password);
            if (name != null) return Ok(name);
            return NotFound();
        }
        [HttpGet]
        [MemberAuthFilter]

        [Route("GetPassportValidation/{passport}")]
        public IHttpActionResult GetPassportValid([FromUri]string passport)
        {
            bool validPassport = idattribute.IsValid(passport);
            if (validPassport) return Ok(validPassport);
            return NotFound();
        }

        [Route("GetMailtValidation/{mail}")]
        public IHttpActionResult GetMailValid([FromUri]string mail)
        {
            bool validMail = mailattribute.IsValid(mail);
            if (validMail) return Ok(validMail);
            return NotFound();
        }


        [Route("GetLettersValidation/first/{first}")]
        public IHttpActionResult GetLettersValidFirst([FromUri]string first)
        {
            bool validFirst = lettersatrribute.IsValid(first);
            if (validFirst) return Ok(validFirst);
            return NotFound();
        }

        [Route("GetLettersValidation/last/{last}")]
        public IHttpActionResult GetLettersValidLast([FromUri]string last)
        {
            bool validLast = lettersatrribute.IsValid(last);
            if (validLast) return Ok(validLast);
            return NotFound();
        }


        [Route("GetIdByPassport/{passport}")]
        public IHttpActionResult GetIdByPassport([FromUri]string passport)
        {
            int Id = memberBll.getIdByPassport(passport);
            if (Id != null) return Ok(Id);
            return NotFound();
        }


        [Route("GetAllStudents/{uniId}")]
        public IHttpActionResult GetAllStudents([FromUri]int uniId)
        {
            List<string> students = memberBll.GetAllStudents(uniId);
            if (students != null) return Ok(students);
            return NotFound();
        }

        [Route("GetAllLecturers/{uniId}")]
        public IHttpActionResult GetAllLecturers([FromUri]int uniId)
        {
            List<string> lecturers = memberBll.GetAllLecturers(uniId);
            if (lecturers != null) return Ok(lecturers);
            return NotFound();
        }
    }
}