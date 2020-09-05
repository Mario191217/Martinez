using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Martinez.Models
{
    public class Estados
    {
        [Key]
        public int IdEstado { get; set; }
        public string Estado { get; set; }

        public virtual List<Empleados> Empleados { get; set; } 
    }
}