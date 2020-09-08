using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Martinez.Models
{
    public class TrabajoProyecto
    {
        [Key]
        public int IdTrabajoProyecto { get; set; }

        public int IdTrabajo { get; set; }
        public virtual Trabajos Trabajos { get; set; }

        public int IdProyecto { get; set; }
        public virtual Proyectos Proyectos { get; set; }
    }
}