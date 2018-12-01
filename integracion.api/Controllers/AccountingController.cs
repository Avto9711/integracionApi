using System.Collections.Generic;
using System.Linq;
using integracion.api.Models;
using integracion.api.Models.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceReference1;
using static ServiceReference1.WSXContabilidadSoapClient;

namespace integracion.api.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class AccountingController: ControllerBase {

        private readonly IntegrationDbContext _integrationDbContext ;
        public AccountingController(IntegrationDbContext integrationDbContext)
        {
         _integrationDbContext = integrationDbContext;   
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Transaction> Post([FromBody] MonthTransaction transaction)
        {
            var account = 71;
            var debitAccount = 48;
            var creditAccont = 48;
            var description = "Nomina de Empleados";

            var client = new WSXContabilidadSoapClient(EndpointConfiguration.WSXContabilidadSoap);
            var request = client.registrarAsientoAsync(description, account, (double)transaction.Amount, debitAccount, creditAccont);
            var result = request.Result;

            var generalLedger = new GeneralLedger{
                Account = account.ToString(),
                Date = transaction.Date,
                Description = description,
                Amount = transaction.Amount,
                ExternalId = result.Body.registrarAsientoResult.ToString(),
                MovementType = Models.Enums.MovementType.Db,
                Status = Models.Enums.TrasactionStatus.Approved
            };

            _integrationDbContext.Set<GeneralLedger>().Add(generalLedger);
            _integrationDbContext.SaveChanges();

            return Created("", generalLedger);
        }

    }
    
}