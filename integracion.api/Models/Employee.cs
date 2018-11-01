
using System;
using integracion.api.Models.Generic;

namespace integracion.api.Models{


    public class Employee : IBaseModel
    {
        //Identificador
        public int Id { get ; set ; }
        //Cedula
        public string  Identification { get; set; } 
        //Departamento  
        public string Department { get; set; }   
        //Puesto 
        public string JobTitle { get; set; }  
        //Salario Mensual
        public decimal MontSalary { get; set; }
        //Identificador de la nomina a la que pertenece
        public int? RosterId { get; set; }


    }

}

