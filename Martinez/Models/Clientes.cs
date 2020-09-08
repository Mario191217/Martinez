using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Martinez.Models
{
    public class Clientes
    {
        [Key]
        public int IdCliente { get; set; }
        public string Cliente { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string DUI { get; set; }
        public string NIT { get; set; }

        public virtual List<Trabajos> Trabajos { get; set; }
    }
}