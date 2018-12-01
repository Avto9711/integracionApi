
using System;
using integracion.api.Models.Generic;
using Integracion.api.converters;
using Newtonsoft.Json;

namespace integracion.api.Models{


    public class Employee : BaseModel
    {
        //Nombre
        public string Name { get; set; }
        //Cedula
        public string  Identification { get; set; } 
        //Departamento  
        public string Department { get; set; }   
        //Puesto 
        public string JobTitle { get; set; }  
        //Salario Mensual
        [JsonConverter(typeof(DecimalCurrencyConverter))]

        public decimal MontSalary { get; set; }
        //Identificador al tipo de nomina a la que pertenece
        public int? RosterTypeId { get; set; }
        public virtual RosterType RosterType { get; set; }

    }


}

