using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Martinez.Models
{
    public class Contexto : DbContext
    {
        public DbSet<Empleados> Empleados { get; set; }
        public DbSet<Estados> Estados { get; set; }
        public DbSet<Generos> Generos { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Articulos> Articulos { get; set; }
        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<Abonos> Abonos { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<DetalleProyecto> DetalleProyectos { get; set; }
        public DbSet<Proyectos> Proyectos { get; set; }
        public DbSet<TrabajoProyecto> TrabajoProyectos { get; set; }
        public DbSet<Trabajos> Trabajos { get; set; }
    }
}