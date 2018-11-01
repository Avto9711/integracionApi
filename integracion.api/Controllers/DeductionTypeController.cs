using System.Collections.Generic;
using System.Linq;
using integracion.api.Models;
using integracion.api.Models.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace integracion.api.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class DeductionTypeController: ControllerBase {

        private readonly IntegrationDbContext _integrationDbContext ;
        public DeductionTypeController(IntegrationDbContext integrationDbContext)
        {
         _integrationDbContext = integrationDbContext;   
        }

        [HttpGet]
        public ActionResult <IEnumerable<DeductionType>> GetAll(){
            var ctx = _integrationDbContext.Set<DeductionType>();
            return Ok(ctx.ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<DeductionType> Get(int id)
        {
           var ctx = _integrationDbContext.Set<DeductionType>();
           var obj = ctx.FirstOrDefault(x=>x.Id == id);

            return Ok(obj);
        }

        // POST api/values
        [HttpPost]
        public ActionResult<DeductionType> Post([FromBody] DeductionType deductionType)
        {

            _integrationDbContext.DeductionTypes.Add(deductionType);
            _integrationDbContext.SaveChanges();

            return Created("",deductionType);

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] DeductionType value)
        {
         _integrationDbContext.Entry(value).State = EntityState.Modified;
         _integrationDbContext.SaveChanges();
         return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
           var deductionType =  _integrationDbContext.DeductionTypes.FirstOrDefault(x=> x.Id == id);
            _integrationDbContext.DeductionTypes.Remove(deductionType);
            _integrationDbContext.SaveChanges();
            return NoContent();

        }

    }
    
}