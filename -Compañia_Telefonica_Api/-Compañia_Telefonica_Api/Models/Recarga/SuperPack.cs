using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _Compañia_Telefonica_Api.Models.Recarga
{
    public class SuperPack : Paquete
    {
        public int Id { get; set; }
        public int datos { get; set; }
        public String redesSociales { get; set; }
    }
}