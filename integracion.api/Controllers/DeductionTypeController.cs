using System.Collections.Generic;
using System.Linq;
using integracion.api.Models;
using integracion.api.Models.Context;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("{id}",Name = "GetById")]
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

            return CreatedAtRoute("GetById",new {id = deductionType.Id},deductionType);

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
           var deductionType =  _integrationDbContext.DeductionTypes.FirstOrDefault(x=> x.Id == id);
            _integrationDbContext.DeductionTypes.Remove(deductionType);
            _integrationDbContext.SaveChanges();
            return Delete(id);

        }

    }
    
}