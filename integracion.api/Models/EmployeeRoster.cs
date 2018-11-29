
using System;
using System.Collections.Generic;
using integracion.api.Models.Generic;

namespace integracion.api.Models{


    public class EmployeeRoster
    {
        public string EmployeeName { get; set; }
        public string EmployeeIdentification { get; set; }
        public decimal  DeductionTotal { get; set; } 
        public decimal EntyTotal { get; set; }   
        public decimal SalaryBruto { get; set; }  
        public decimal SalaryNeto { get; set; }

    }


    public class MonthRoster { 

        public MonthRoster()
        {
            Employees = new List<EmployeeRoster>();
        }
        public int EmployeeTotalAfected { get; set; } 
        public string RosterMonthMonth { get; set; } 

        public decimal TotalRosterAmount { get; set; }

        public List<EmployeeRoster> Employees { get; set; }

    }

}

