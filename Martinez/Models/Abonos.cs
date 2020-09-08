using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Martinez.Models
{
    public class Abonos
    {
        [Key]
        public int IdAbono { get; set; }
        public double Abono { get; set; }

        public int IdTrabajo { get; set; }
        public virtual Trabajos Trabajos { get; set; }

        public DateTime FechaAbono { get; set; }
    }
}