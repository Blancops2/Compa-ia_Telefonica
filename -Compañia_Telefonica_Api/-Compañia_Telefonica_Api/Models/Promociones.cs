using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _Compañia_Telefonica_Api.Models
{
    public class Promociones
    {
        public int Id { get; set; }
        //public DateTime fechaActual = DateTime.Now;
        public int ClienteId { get; set; }
        public int SuperPackId { get; set; }

    }
}