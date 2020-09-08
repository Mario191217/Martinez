using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Martinez.Models
{
    public class Proyectos
    {
        [Key]
        public int IdProyecto { get; set; }
        public string Proyecto { get; set; }
        public double Costo { get; set; }
        public double Monto { get; set; }
        public double Rentabilidad { get; set; }
        public bool Terminado { get; set; }

        public virtual List<TrabajoProyecto> TrabajoProyectos { get; set; }
    }
}