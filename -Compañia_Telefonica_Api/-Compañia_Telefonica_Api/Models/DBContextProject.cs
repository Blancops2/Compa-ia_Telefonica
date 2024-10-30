using _Compañia_Telefonica_Api.Models.Cable;
using _Compañia_Telefonica_Api.Models.Cable_Internet;
using _Compañia_Telefonica_Api.Models.Internet_Residencial;
using _Compañia_Telefonica_Api.Models.Recarga;
using _Compañia_Telefonica_Api.Models.Tecnologia;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace _Compañia_Telefonica_Api.Models
{
    public class DBContextProject : DbContext
    {
        public DBContextProject() : base("MyDbConnectionString")
        {
        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Promociones> Promociones { get; set; }
        public DbSet<Celular> Celular { get; set; }
        public DbSet<Computadoras> Computadoras { get; set; }
        public DbSet<SuperPack> SuperPack { get; set; }
        public DbSet<Internet_Ilimitado> Internet_Ilimitado { get; set; }
        public DbSet<Recarga_Cls> Recarga_Cls { get; set; }
        public DbSet<Antena_Satelital> Antena_Satelital { get; set; }
        public DbSet<Fibra_Optica> Fibra_Optica { get; set; }
        public DbSet<Cbl_Normal> Cable_Normal { get; set; }
        public DbSet<Cbl_Premium> Cable_Premium { get; set; }
        public DbSet<Cable_Internet_Basico> Cable_Internet_Basico { get; set; }
        public DbSet<Cable_Internet_Premium> Cable_Internet_Premium { get; set; }
    }
}