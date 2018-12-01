using System;
using System.Collections.Generic;
using System.Text;

namespace integracion.api.Models
{
    class MonthTransaction
    {
        public int Month { get; set; }
        public decimal Deduction { get; set; }
        public decimal Entry { get; set; }
        public DateTime Date { get; set; }
    }
}
