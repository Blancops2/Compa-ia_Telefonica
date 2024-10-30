using System.Web;
using System.Web.Mvc;

namespace DevExtreme_Conexion_Con_Api {
    public class FilterConfig {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
