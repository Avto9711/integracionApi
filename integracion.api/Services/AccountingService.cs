using integracion.api.Models;
using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Text;

namespace integracion.api.Services
{
    class AccountingService
    {
        public int RegisterSeat(MonthTransaction monthTransaction)
        {
            var client = new WSXContabilidadSoapClient();
            return 0;
        }
    }
}
