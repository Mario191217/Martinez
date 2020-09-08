using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Martinez.Models
{
    public class Articulos
    {
        [Key]
        public int IdArticulo { get; set; }
        public string Articulo { get; set; }
        public double Cantidad { get; set; }
        public double Precio { get; set; }
        public string Descripcion { get; set; }
        public DateTime UltimaCompra { get; set; }

        public int IdCategoria { get; set; }
        public virtual Categorias Categorias { get; set; }

        public virtual List<DetalleProyecto> DetalleProyectos { get; set; }


    }
}