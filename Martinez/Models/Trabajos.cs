using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Martinez.Models
{
    public class Trabajos
    {
        [Key]
        public int IdTrabajo { get; set; }
        public string Trabajo { get; set; }

        [Display(Name = "Comisionista")]
        public int IdEmpleado { get; set; }
        public virtual Empleados Empleados { get; set; }

        public double Comision { get; set; }
        public double CostoTotal { get; set; }
        public double MontoTotal { get; set; }
        public double Rentabilidad { get; set; }
        public string Ubicacion { get; set; }

        [Display(Name = "Cliente")]
        public int IdCliente { get; set; }
        public virtual Clientes Clientes { get; set; }

        public double Abono { get; set; }
        public double Saldo { get; set; }

        public virtual List<Abonos> Abonos { get; set; }

        public DateTime FechaRegistro { get; set; }
        public DateTime FechaFinalizacion { get; set; }
        public bool Terminado { get; set; }

        public virtual List<TrabajoProyecto> TrabajoProyectos { get; set; }
    }
}