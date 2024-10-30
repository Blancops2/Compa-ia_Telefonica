using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using DevExtreme_Conexion_Con_Api.Data;
using DevExtreme_Conexion_Con_Api.Models;

namespace DevExtreme_Conexion_Con_Api.Controllers
{
    [Route("api/Promociones/{action}", Name = "PromocionesApi")]
    public class PromocionesController : ApiController
    {
        private static readonly HttpClient client = new HttpClient();
        [HttpGet]
        public async Task<HttpResponseMessage> GetClientes()
        {
            var apiUrlClientes = "https://localhost:44349/api/Cliente/";
            var response = await client.GetAsync(apiUrlClientes);

            var Clientes = await response.Content.ReadAsAsync<List<Cliente>>();

            var ClientesPromocion = Clientes.Select(c => new
            {
                c.id, c.nombre, c.numero, c.seUnio,
                aplicaPromo = (DateTime.Now - c.seUnio).TotalDays >= 365 //mas de un año
            }
            ).ToList();

            return Request.CreateResponse(HttpStatusCode.OK, ClientesPromocion);


        }

        /*public static async Task<string> GetAsync(string uri)
        {
            var response = await client.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }*/



    }
}