using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevExtreme_Conexion_Con_Api.Models
{
    static class SampleData
    {
        public static List<SampleOrder> Orders = new List<SampleOrder>() {
            new SampleOrder {
                OrderID = 10248,
                OrderDate = new DateTime(1996, 7, 4),
                ShipCountry = "France",
                ShipCity = "Reims",
                CustomerName = "Paul Henriot"
            },
        };
    }
}