using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _Compañia_Telefonica_Api.Models.Recarga
{
    public class Recarga_Cls : Paquete
    {
        public int Id { get; set; }
        public int saldo { get; set; }
    }
}