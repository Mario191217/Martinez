using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Martinez.Models
{
    public class Generos
    {
        [Key]
        public int IdGenero { get; set; }
        public string Genero { get; set; }

        public virtual List<Empleados> Empleados { get; set; }
    }
}