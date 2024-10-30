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
using DevExtreme_Conexion_Con_Api.Models.Cable_Internet;
using DevExtreme_Conexion_Con_Api.Models;

namespace DevExtreme_Conexion_Con_Api.Controllers
{
    [Route("api/Cable_Internet_Premium/{action}", Name = "Cable_Internet_PremiumApi")]
    public class Cable_Internet_PremiumController : ApiController
    {
        private static readonly HttpClient client = new HttpClient();
        [HttpGet]
        public async Task<HttpResponseMessage> Get(DataSourceLoadOptions loadOptions)
        {
            var apiUrl = "https://localhost:44349/api/Cable_Internet_Premium/";
            var respuestaJson = await GetAsync(apiUrl);
            //System.Diagnostics.Debug.WriteLine(respuestaJson); imprimir info
            List<Cable_Internet_Premium> listaCliente = JsonConvert.DeserializeObject<List<Cable_Internet_Premium>>(respuestaJson);
            return Request.CreateResponse(DataSourceLoader.Load(listaCliente, loadOptions));
        }

        public static async Task<string> GetAsync(string uri)
        {
            var response = await client.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Post(FormDataCollection form)
        {

            var values = form.Get("values");

            var httpContent = new StringContent(values, System.Text.Encoding.UTF8, "application/json");

            var url = "https://localhost:44349/api/Cable_Internet_Premium/";
            var response = await client.PostAsync(url, httpContent);

            var result = response.Content.ReadAsStringAsync().Result;

            return Request.CreateResponse(HttpStatusCode.Created);
        }


        [HttpPut]
        public async Task<HttpResponseMessage> Put(FormDataCollection form)
        {
            //Parámetros del form
            var key = Convert.ToInt32(form.Get("key")); //llave que estoy modificando
            var values = form.Get("values"); //Los valores que yo modifiqué en formato JSON

            var apiUrlGetCliente = "https://localhost:44349/api/Cable_Internet_Premium/" + key;
            var respuestaCliente = await GetAsync(apiUrlGetCliente = "https://localhost:44349/api/Cable_Internet_Premium/" + key);
            Cable_Internet_Premium Cable_Internet_Premium = JsonConvert.DeserializeObject<Cable_Internet_Premium>(respuestaCliente);

            JsonConvert.PopulateObject(values, Cable_Internet_Premium);

            string jsonString = JsonConvert.SerializeObject(Cable_Internet_Premium);
            var httpContent = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json");


            var url = "https://localhost:44349/api/Cable_Internet_Premium/" + key;
            var response = await client.PutAsync(url, httpContent);

            var result = response.Content.ReadAsStringAsync().Result;

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> Delete(FormDataCollection form)
        {
            var key = Convert.ToInt32(form.Get("key"));

            var apiUrlDelPeli = "https://localhost:44349/api/Cable_Internet_Premium/" + key;
            var respuestaPelic = await client.DeleteAsync(apiUrlDelPeli);

            return Request.CreateResponse(HttpStatusCode.OK);
        }



    }
}