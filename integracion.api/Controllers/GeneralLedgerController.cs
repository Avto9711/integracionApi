using System.Collections.Generic;
using System.Linq;
using integracion.api.Models;
using integracion.api.Models.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace integracion.api.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class GeneralLedgerController: ControllerBase {

        private readonly IntegrationDbContext _integrationDbContext ;
        public GeneralLedgerController(IntegrationDbContext integrationDbContext)
        {
         _integrationDbContext = integrationDbContext;   
        }

        [HttpGet]
        public ActionResult <IEnumerable<EntryType>> GetAll(){
            var ctx = _integrationDbContext.Set<GeneralLedger>();
            return Ok(ctx.ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<EntryType> Get(int id)
        {
           var ctx = _integrationDbContext.Set<GeneralLedger>();
           var obj = ctx.FirstOrDefault(x=>x.Id == id);

            return Ok(obj);
        }

        // POST api/values
        [HttpPost]
        public ActionResult<EntryType> Post([FromBody] GeneralLedger generalLedger)
        {

            _integrationDbContext.Set<GeneralLedger>().Add(generalLedger);
            _integrationDbContext.SaveChanges();

            return Created("",generalLedger);

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] GeneralLedger value)
        {
            
         _integrationDbContext.Entry(value).State = EntityState.Modified;
         _integrationDbContext.SaveChanges();
         return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
           var generalLedger =  _integrationDbContext.Set<GeneralLedger>().FirstOrDefault(x=> x.Id == id);
            _integrationDbContext.Set<GeneralLedger>().Remove(generalLedger);
            _integrationDbContext.SaveChanges();
            return NoContent();

        }


    }
    
}