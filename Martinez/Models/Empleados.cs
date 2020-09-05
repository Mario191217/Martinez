using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Martinez.Models
{
    public class Empleados
    {
        [Key]
        public int IdEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cargo { get; set; }
        public string Direccion { get; set; }
        public string DUI { get; set; }
        public string NIT { get; set; }
        public string Email { get; set; }
        public string ContactoEmergencia { get; set; }
        public string TelefonoEmergencia { get; set; }
        public string Observaciones { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        [Display(Name = "Estado")]
        public int IdEstado { get; set; }
        public virtual Estados Estado { get; set; }

        [Display(Name = "Genero")]
        public int IdGenero { get; set; }
        public virtual Generos Genero { get; set; }

        public virtual List<Usuarios> Usuarios { get; set; }
    }
}