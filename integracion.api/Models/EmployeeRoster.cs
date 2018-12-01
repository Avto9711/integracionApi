
using System;
using System.Collections.Generic;
using integracion.api.Models.Generic;
using Integracion.api.converters;
using Newtonsoft.Json;

namespace integracion.api.Models{


    public class EmployeeRoster
    {
        public string EmployeeName { get; set; }
        public string EmployeeIdentification { get; set; }
                [JsonConverter(typeof(DecimalCurrencyConverter))]

        public decimal  DeductionTotal { get; set; } 
                [JsonConverter(typeof(DecimalCurrencyConverter))]

        public decimal EntyTotal { get; set; }  
                [JsonConverter(typeof(DecimalCurrencyConverter))]
 
        public decimal SalaryBruto { get; set; } 
                [JsonConverter(typeof(DecimalCurrencyConverter))]
 
        public decimal SalaryNeto { get; set; }

    }


    public class MonthRoster { 

        public MonthRoster()
        {
            Employees = new List<EmployeeRoster>();
        }
        public int EmployeeTotalAfected { get; set; } 
        public string RosterMonthMonth { get; set; } 
        [JsonConverter(typeof(DecimalCurrencyConverter))]
        public decimal TotalRosterAmount { get; set; }
                [JsonConverter(typeof(DecimalCurrencyConverter))]

        public decimal TotalRosterEntryAmount { get; set; }
                [JsonConverter(typeof(DecimalCurrencyConverter))]

        public decimal TotalRosterDeductionAmount { get; set; }

        public List<EmployeeRoster> Employees { get; set; }

    }

}

