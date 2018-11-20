
using System;
using integracion.api.Models.Enums;
using integracion.api.Models.Generic;

namespace integracion.api.Models{


    public class Transaction : BaseModel
    {
        //Nombre
        public int EmployeeId { get; set; }
        //Deduccion o entrada
        public int? DeductionTypeId { get; set; }
        public int? EntryTypeId { get; set; }
        //Fecha

        public DateTime Date { get; set; } 
        //Monto
        public decimal Amount { get; set; }
        //Estado
        public TrasactionStatus Status { get; set; }

        public virtual Employee Employee{get;set;}
        public virtual DeductionType DeductionType{get;set;}
        public virtual EntryType EntryType {get;set;}
    }



}

