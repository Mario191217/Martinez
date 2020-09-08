using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Martinez.Models
{
    public class DetalleProyecto
    {
        [Key]
        public int IdDetalle { get; set; }

        public int IdArticulo { get; set; }
        public virtual Articulos Articulos { get; set; }
        
        public int Cantidad { get; set; }
        public double PrecioUnitario { get; set; }
        public double Total { get; set; }
    }
}