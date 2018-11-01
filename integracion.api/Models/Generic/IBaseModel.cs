
using System;

namespace integracion.api.Models.Generic{
        public class BaseModel{
            public int Id {get;set;}    
            public bool Deleted {get;set;}   
            public bool Disabled { get; set; } 
        }

}