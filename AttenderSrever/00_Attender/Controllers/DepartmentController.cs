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
    [RoutePrefix("api/department")]
    public class DepartmentController : ApiController
    {
        private DepartmentManager departmentBll = new DepartmentManager();
        [HttpGet]
        [Route("all")]
        public List<DepartmentModel> Get()
        {
            return departmentBll.GetAllDepartments();

        }
        [HttpGet]
        [Route("id/{id}")]
        public IHttpActionResult Get([FromUri]int id)
        {
            DepartmentModel department = departmentBll.GetDepartmentById(id);
            if (department != null) return Ok(department);
            return NotFound();
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult post([FromBody]DepartmentModel value)
        {
            if (ModelState.IsValid)
            {
                bool succsess = departmentBll.AddDepartment(value);
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
        public IHttpActionResult Put([FromUri]int id, [FromBody]DepartmentModel value)
        {
            if (ModelState.IsValid)
            {
                bool succsess = departmentBll.UpdateDepartment(id, value);
                if (succsess)
                    return Ok();
            }
            return BadRequest();
        }
        [HttpDelete]
        [Route("id/{id}")]
        public IHttpActionResult Delete([FromUri]int id)
        {
            bool succsess = departmentBll.DeleteDepartment(id);
            if (succsess)
                return Ok();
            return BadRequest();
        }
        [HttpGet]
        [Route("GetDepartments/{id}")]
        public IHttpActionResult GetAllDepartments([FromUri]int id)
        {
            List<string> department = departmentBll.GetDepartmentsByUniId(id);
            if (department != null) return Ok(department);
            return NotFound();
        }
    }
}