using _Compañia_Telefonica_Api.Models.Cable;
using _Compañia_Telefonica_Api.Models.Internet_Residencial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _Compañia_Telefonica_Api.Models.Cable_Internet
{
    public class Cable_Internet_Premium : Cable_Internet_Cls
    {
        public new int Id { get; set; }
        public String fibraOpticaId { get; set; }
    }
}