using System;
using System.Collections.Generic;
using System.Text;

namespace integracion.api.Models
{
    public class MonthTransaction
    {
        public int Month { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
