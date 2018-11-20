using System.Collections.Generic;
using System.Linq;
using integracion.api.Models;
using integracion.api.Models.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace integracion.api.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController: ControllerBase {

        private readonly IntegrationDbContext _integrationDbContext ;
        public TransactionController(IntegrationDbContext integrationDbContext)
        {
         _integrationDbContext = integrationDbContext;   
        }

        [HttpGet]
        public ActionResult <IEnumerable<Transaction>> GetAll(){
            var ctx = _integrationDbContext.Set<Transaction>();
            return Ok(ctx.ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<Transaction> Get(int id)
        {
           var ctx = _integrationDbContext.Set<Transaction>();
           var obj = ctx.FirstOrDefault(x=>x.Id == id);

            return Ok(obj);
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Transaction> Post([FromBody] Transaction transaction)
        {

            _integrationDbContext.Set<Transaction>().Add(transaction);
            _integrationDbContext.SaveChanges();

            return Created("",transaction);

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Transaction value)
        {
            
         _integrationDbContext.Entry(value).State = EntityState.Modified;
         _integrationDbContext.SaveChanges();
         return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
           var transaction =  _integrationDbContext.Set<Transaction>().FirstOrDefault(x=> x.Id == id);
            _integrationDbContext.Set<Transaction>().Remove(transaction);
            _integrationDbContext.SaveChanges();
            return NoContent();

        }


    }
    
}