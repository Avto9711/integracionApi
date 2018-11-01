
using System;
using integracion.api.Models.Enums;
using integracion.api.Models.Generic;

namespace integracion.api.Models{


    public class RosterType : BaseModel
    {
        //Nombre
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
    }


}

