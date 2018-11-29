using System.Collections.Generic;
using System.Globalization;
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

        [HttpGet("GenerateMontNomina/{month}")]
        public ActionResult<EntryType> GenerateMontNomina(int month)
        {

            var rosterMonth = new MonthRoster();
            rosterMonth.RosterMonthMonth =  CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month);


            var ctx = _integrationDbContext.Set<Transaction>();
 
            var transactions = ctx.
            Where(x=>x.Date.Month == month && x.Date.Year == System.DateTime.Now.Year)
            .GroupBy(y=>y.Employee);

            foreach (var item in transactions)
            {
                var employeeRoster = new EmployeeRoster
                {
                    EmployeeName = item.Key.Name,
                    EmployeeIdentification =  item.Key.Identification,
                    DeductionTotal =  item.Where(y=>y.DeductionTypeId.HasValue).Sum(y=>y.Amount),
                    EntyTotal =  item.Where(y=>y.EntryTypeId.HasValue).Sum(y=>y.Amount),
                    SalaryBruto = item.Key.MontSalary,
                    SalaryNeto = ( item.Key.MontSalary + 
                    (item.Where(y=>y.EntryTypeId.HasValue).Sum(y=>y.Amount) -
                     item.Where(y=>y.DeductionTypeId.HasValue).Sum(y=>y.Amount) ) )
                };

                rosterMonth.Employees.Add(employeeRoster);
            }

            rosterMonth.EmployeeTotalAfected = rosterMonth.Employees.Count;
            rosterMonth.TotalRosterAmount = rosterMonth.Employees.Sum(o=>o.SalaryNeto);

            return Ok(rosterMonth);
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