
using System;
using integracion.api.Models.Generic;

namespace integracion.api.Models{
    public class EntryType : BaseModel
    {
        //Nombre
        public string Name { get; set; }
        //Depende de salario
        public bool SalaryDepend { get; set; }
        //Estado
    }

}

