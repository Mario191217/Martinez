using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Martinez.Models
{
    public class Usuarios
    {
        [Key]
        public int IdUsuario { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }

        public int IdRol { get; set; }
        public virtual Roles Rol { get; set; }

        public int IdEmpleado { get; set; }
        public virtual Empleados Empleado { get; set; }
    }
}