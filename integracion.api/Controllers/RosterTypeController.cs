using System.Collections.Generic;
using System.Linq;
using integracion.api.Models;
using integracion.api.Models.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace integracion.api.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class RosterTypeController: ControllerBase {

        private readonly IntegrationDbContext _integrationDbContext ;
        public RosterTypeController(IntegrationDbContext integrationDbContext)
        {
         _integrationDbContext = integrationDbContext;   
        }

        [HttpGet]
        public ActionResult <IEnumerable<RosterType>> GetAll(){
            var ctx = _integrationDbContext.Set<RosterType>();
            return Ok(ctx.ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<RosterType> Get(int id)
        {
           var ctx = _integrationDbContext.Set<RosterType>();
           var obj = ctx.FirstOrDefault(x=>x.Id == id);

            return Ok(obj);
        }

        // POST api/values
        [HttpPost]
        public ActionResult<RosterType> Post([FromBody] RosterType rosterType)
        {

            _integrationDbContext.Set<RosterType>().Add(rosterType);
            _integrationDbContext.SaveChanges();

            return Created("",rosterType);

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] RosterType value)
        {
            
         _integrationDbContext.Entry(value).State = EntityState.Modified;
         _integrationDbContext.SaveChanges();
         return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
           var rosterType =  _integrationDbContext.Set<RosterType>().FirstOrDefault(x=> x.Id == id);
            _integrationDbContext.Set<RosterType>().Remove(rosterType);
            _integrationDbContext.SaveChanges();
            return NoContent();

        }


    }
    
}