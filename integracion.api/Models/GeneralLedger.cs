
using System;
using integracion.api.Models.Enums;
using integracion.api.Models.Generic;

namespace integracion.api.Models{


    public class GeneralLedger : BaseModel
    {
        //Nombre
        public string Description { get; set; }
        public int EmployeeId { get; set; }
        public string Account { get; set; }
        public MovementType MovementType { get; set; }

        public DateTime Date { get; set; }

        public decimal Amount { get; set; }
        public TrasactionStatus Status { get; set; }

        public virtual Employee Employee {get;set;}

    }


}

