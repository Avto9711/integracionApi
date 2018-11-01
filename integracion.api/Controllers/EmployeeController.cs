using System.Collections.Generic;
using System.Linq;
using integracion.api.Models;
using integracion.api.Models.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace integracion.api.Controllers{

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController: ControllerBase {

        private readonly IntegrationDbContext _integrationDbContext ;
        public EmployeeController(IntegrationDbContext integrationDbContext)
        {
         _integrationDbContext = integrationDbContext;   
        }

        [HttpGet]
        public ActionResult <IEnumerable<Employee>> GetAll(){
            var ctx = _integrationDbContext.Set<Employee>();
            return Ok(ctx.ToList());
        }

        [HttpGet("{id}",Name = "GetById")]
        public ActionResult<Employee> Get(int id)
        {
           var ctx = _integrationDbContext.Set<Employee>();
           var obj = ctx.FirstOrDefault(x=>x.Id == id);

            return Ok(obj);
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Employee> Post([FromBody] Employee employee)
        {

            _integrationDbContext.Employees.Add(employee);
            _integrationDbContext.SaveChanges();

            return CreatedAtRoute("GetById",new {id = employee.Id},employee);

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Employee value)
        {
          _integrationDbContext.Entry(value).State = EntityState.Modified;
         _integrationDbContext.SaveChanges();
         return NoContent();

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
           var employee =  _integrationDbContext.Employees.FirstOrDefault(x=> x.Id == id);
            _integrationDbContext.Employees.Remove(employee);
            _integrationDbContext.SaveChanges();
            return NoContent();

        }


    }
    
}