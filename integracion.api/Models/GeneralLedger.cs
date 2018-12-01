
using System;
using System.ComponentModel.DataAnnotations.Schema;
using integracion.api.Models.Enums;
using integracion.api.Models.Generic;

namespace integracion.api.Models{


    public class GeneralLedger : BaseModel
    {
        //Nombre
        public string Description { get; set; }
        public string Account { get; set; }

        public string ExternalId { get; set; }

        public MovementType MovementType { get; set; }
        [NotMapped]
        public string MovementTypeName { get { return this.MovementType.ToString(); } }

        public DateTime Date { get; set; }

        public decimal Amount { get; set; }
        public TrasactionStatus Status { get; set; }
        [NotMapped]
        public string StatusName { get { return this.Status.ToString(); } }


    }


}

