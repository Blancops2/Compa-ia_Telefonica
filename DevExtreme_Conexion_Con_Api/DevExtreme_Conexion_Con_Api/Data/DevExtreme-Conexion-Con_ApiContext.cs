using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DevExtreme_Conexion_Con_Api.Data
{
    public class DevExtreme_Conexion_Con_ApiContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public DevExtreme_Conexion_Con_ApiContext() : base("name=TelefoniaDevExtremeContext")
        {
        }

        public System.Data.Entity.DbSet<DevExtreme_Conexion_Con_Api.Models.Cliente> Clientes { get; set; }
        public System.Data.Entity.DbSet<DevExtreme_Conexion_Con_Api.Models.Recarga.SuperPack> SuperPack { get; set; }
        public System.Data.Entity.DbSet<DevExtreme_Conexion_Con_Api.Models.Promociones> Promociones { get; set; }
        public System.Data.Entity.DbSet<DevExtreme_Conexion_Con_Api.Models.Recarga.Internet_Ilimitado> Internet_Ilimitado { get; set; }
        public System.Data.Entity.DbSet<DevExtreme_Conexion_Con_Api.Models.Recarga.Recarga_Cls> Recarga_Cls { get; set; }
        public System.Data.Entity.DbSet<DevExtreme_Conexion_Con_Api.Models.Cable_Internet.Cable_Internet_Basico> Cable_Internet_Basico { get; set; }
        public System.Data.Entity.DbSet<DevExtreme_Conexion_Con_Api.Models.Cable_Internet.Cable_Internet_Premium> Cable_Internet_Premium { get; set; }
        public System.Data.Entity.DbSet<DevExtreme_Conexion_Con_Api.Models.Cable.Cbl_Normal> Cbl_Normal { get; set; }
        public System.Data.Entity.DbSet<DevExtreme_Conexion_Con_Api.Models.Cable.Cbl_Premium> Cbl_Premium { get; set; }
        public System.Data.Entity.DbSet<DevExtreme_Conexion_Con_Api.Models.Internet_Residencial.Antena_Satelital> Antena_Satelital { get; set; }
        public System.Data.Entity.DbSet<DevExtreme_Conexion_Con_Api.Models.Internet_Residencial.Fibra_Optica> Fibra_Optica { get; set; }
        public System.Data.Entity.DbSet<DevExtreme_Conexion_Con_Api.Models.Tecnologia.Computadoras> Computadoras { get; set; }
        public System.Data.Entity.DbSet<DevExtreme_Conexion_Con_Api.Models.Tecnologia.Celular> Celular { get; set; }
    }
}