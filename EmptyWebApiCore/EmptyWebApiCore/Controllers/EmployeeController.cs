using EmptyWebApiCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmptyWebApiCore.Controllers
{
    public class EmployeeController : ApiController
    {
        EmployeeDbContext db = new EmployeeDbContext();

        [HttpPost]
        public IHttpActionResult Add([FromBody] Employee employee)
        {
            db.employees.Add(employee);
            int rowCount = db.SaveChanges();
            if (rowCount > 0)
            {
                return Ok("Employee has been saved");
            }
            return BadRequest("Saved Faild");
        }
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var employees = db.employees.ToList();
            if (employees.Count == 0)
            {
                return NotFound();

            }
            return Ok(employees);
        }
        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var employee = db.employees.FirstOrDefault(c => c.id == id);
            if (employee == null)
            {
                return NotFound();

            }
            return Ok(employee);
        }
        [HttpPut]
        public IHttpActionResult Update([FromBody] Employee employee)
        {
            if (employee.id<= 0)
            {
                return NotFound();
            }
            db.Entry(employee).State = System.Data.Entity.EntityState.Modified;
            int rowCount = db.SaveChanges();
            if (rowCount > 0)
            {
                return Ok(employee);
            }
               return BadRequest("Modified Faild");
        }
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var employee = db.employees.FirstOrDefault(c => c.id == id);
            if (employee == null)
            {
                return NotFound();

            }
            db.employees.Remove(employee);
            int rowCount = db.SaveChanges();
            if (rowCount > 0)
            {
                return Ok("Employee has been Delete");
            }
            return BadRequest("Delete Faild");

        }

    }
   
}
