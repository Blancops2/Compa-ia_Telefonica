using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevExtreme_Conexion_Con_Api.Models.Cable
{
    public class Cbl
    {
        public int canalesAnalogos { get; set; }
        public int canalesDigitales { get; set; }
        public int canalesPremium { get; set; }
        public int precio { get; set; }
    }
}