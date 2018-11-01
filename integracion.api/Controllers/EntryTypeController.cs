using System.Collections.Generic;
using System.Linq;
using integracion.api.Models;
using integracion.api.Models.Context;
using Microsoft.AspNetCore.Mvc;

namespace integracion.api.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class EntryTypeController: ControllerBase {

        private readonly IntegrationDbContext _integrationDbContext ;
        public EntryTypeController(IntegrationDbContext integrationDbContext)
        {
         _integrationDbContext = integrationDbContext;   
        }

        [HttpGet]
        public ActionResult <IEnumerable<EntryType>> GetAll(){
            var ctx = _integrationDbContext.Set<EntryType>();
            return Ok(ctx.ToList());
        }

        [HttpGet("{id}",Name = "GetById")]
        public ActionResult<EntryType> Get(int id)
        {
           var ctx = _integrationDbContext.Set<EntryType>();
           var obj = ctx.FirstOrDefault(x=>x.Id == id);

            return Ok(obj);
        }

        // POST api/values
        [HttpPost]
        public ActionResult<EntryType> Post([FromBody] EntryType entryType)
        {

            _integrationDbContext.EntryTypes.Add(entryType);
            _integrationDbContext.SaveChanges();

            return CreatedAtRoute("GetById",new {id = entryType.Id},entryType);

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
           var entryType =  _integrationDbContext.EntryTypes.FirstOrDefault(x=> x.Id == id);
            _integrationDbContext.EntryTypes.Remove(entryType);
            _integrationDbContext.SaveChanges();
            return Delete(id);

        }


    }
    
}