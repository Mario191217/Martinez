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
    }
}