using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _Compañia_Telefonica_Api.Models.Internet_Residencial
{
    public class Planes
    {
        public int Id { get; set; }
        public int velocidad { get; set; }
        public String tipo { get; set; } //fibra optica o antena
        public int costo { get; set; }
    }
}