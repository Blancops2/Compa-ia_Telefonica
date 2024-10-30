using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _Compañia_Telefonica_Api.Models.Tecnologia
{
    public class Dispositivo
    {
        public String marca { get; set; }
        public String modelo { get; set; }
        public String procesador { get; set; }
        public int bateria { get; set; }
        public int rom { get; set; }
        public int ram { get; set; }
        public int codigo { get; set; }
    }
}