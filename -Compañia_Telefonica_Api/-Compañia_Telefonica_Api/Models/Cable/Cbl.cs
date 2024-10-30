using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _Compañia_Telefonica_Api.Models.Cable
{
    public class Cbl
    {
        public int canalesAnalogos { get; set; }
        public int canalesDigitales { get; set; }
        public int canalesPremium { get; set; }
        public int precio { get; set; }
    }
}