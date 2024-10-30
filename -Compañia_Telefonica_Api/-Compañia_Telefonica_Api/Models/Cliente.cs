using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _Compañia_Telefonica_Api.Models
{
    public class Cliente
    {
        public string nombre { get; set; }
        public int id { get; set; }
        public int numero { get; set; }
        public DateTime seUnio { get; set; }
    }
}