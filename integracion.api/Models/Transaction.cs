
using System;
using System.ComponentModel.DataAnnotations.Schema;
using integracion.api.Models.Enums;
using integracion.api.Models.Generic;
using Integracion.api.converters;
using Newtonsoft.Json;

namespace integracion.api.Models{


    public class Transaction : BaseModel
    {
        //Nombre
        public int EmployeeId { get; set; }
        //Deduccion o entrada
        public int? DeductionTypeId { get; set; }
        public int? EntryTypeId { get; set; }
        //Fecha
        [JsonConverter(typeof(OnlyDateConverter))]
        public DateTime Date { get; set; } 
        //Monto
        [JsonConverter(typeof(DecimalCurrencyConverter))]

        public decimal Amount { get; set; }
        //Estado
        public TrasactionStatus Status { get; set; }

        public virtual Employee Employee{get;set;}
        public virtual DeductionType DeductionType{get;set;}
        public virtual EntryType EntryType {get;set;}

        [NotMapped]
        public string   TypeName { get { 
            
            return this.EntryTypeId != null  ?  this.EntryType?.Name : this.DeductionType?.Name;
        
        } }         


        [NotMapped]
        public string   Type { get { 
            
            return this.EntryTypeId != null  ?  "Entrada" : "Deducción";
        
        } }    
    }



}

