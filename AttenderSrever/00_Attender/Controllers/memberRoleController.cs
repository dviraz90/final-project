using _00_Attender.Filters;
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
    [RoutePrefix("api/memberRole")]
    public class MemberRoleController : ApiController
    {
        private MemberRoleManager memberRoleBll = new MemberRoleManager();

        [HttpGet]
        [Route("all")]
        public List<MemberRoleModel> Get()
        {
            return memberRoleBll.GetAllMemberRoles();
        }

        [HttpGet]
        [Route("id/{id}")]
        public IHttpActionResult Get([FromUri]int id)
        {
            MemberRoleModel memberRole = memberRoleBll.GetMemberRoleById(id);
            if (memberRole != null) return Ok(memberRole);
            return NotFound();
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult post([FromBody]MemberRoleModel value)
        {
            if (ModelState.IsValid)
            {

                bool succsess = memberRoleBll.AddMemberRole(value);
                if (succsess)
                    return Ok("OK");

                return BadRequest();
            }
            else
            {

                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        [Route("id/{id}")]
        public IHttpActionResult Put([FromUri]int id, [FromBody]MemberRoleModel value)
        {
            if (ModelState.IsValid)
            {
                bool succsess = memberRoleBll.UpdateMemberRole(id, value);
                if (succsess)
                    return Ok();
            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("id/{id}")]
        public IHttpActionResult Delete([FromUri]int id)
        {
            bool succsess = memberRoleBll.DeleteMemberRole(id);
            if (succsess)
                return Ok();
            return BadRequest();
        }

        [HttpGet]
        [MemberAuthFilter]
        [Route("Roleid/{id}")]
        public IHttpActionResult Get1([FromUri]int id)
        {
            string role = memberRoleBll.GetRoleById(id);
            if (role != null) return Ok(role);
            return NotFound();
        }

        [HttpGet]
        [Route("lecturerId/{lecturerId}")]
        public IHttpActionResult GetlecId([FromUri]int lecturerId)
        {
            string memberRole = memberRoleBll.GetRoleById(lecturerId);
            if (memberRole != null) return Ok(memberRole);
            return NotFound();
        }
        [HttpGet]
        [Route("GetUniversityById/{id}")]
        public IHttpActionResult GetUniId([FromUri]int id)
        {
            int uniId = memberRoleBll.GetUniversityById(id);
            if (uniId != null) return Ok(uniId);
            return NotFound();
        }

        [HttpGet]
        [Route("GetIdByMemberId/memberId/{memberId}/role/{role}")]
        public IHttpActionResult GetIdByMemberId([FromUri]int memberId, [FromUri]string role)
        {
            int id = memberRoleBll.GetIdByMemberId(memberId, role);
            if (id != null) return Ok(id);
            return NotFound();
        }

    }
}
