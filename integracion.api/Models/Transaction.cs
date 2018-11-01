
using System;
using integracion.api.Models.Generic;

namespace integracion.api.Models{


    public class Transaction : IBaseModel
    {
        //Identificador
        public int Id { get ; set ; }
        //Nombre
        public string Name { get; set; }
        //Depende de salario
        public bool SalaryDepend { get; set; }
        //Estado
        public bool Status { get; set; }
    }

}

