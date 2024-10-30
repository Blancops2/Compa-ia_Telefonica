using _Compañia_Telefonica_Api.Models.Recarga;
using _Compañia_Telefonica_Api.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace _Compañia_Telefonica_Api.Controllers
{
    public class Internet_IlimitadoController : ApiController
    {
        private DBContextProject db = new DBContextProject();

        // GET: api/Internet_Ilimitado
        public IQueryable<Internet_Ilimitado> GetInternet_Ilimitado()
        {
            return db.Internet_Ilimitado;
        }

        // GET: api/Internet_Ilimitado/5
        [ResponseType(typeof(Internet_Ilimitado))]
        public IHttpActionResult GetInternet_Ilimitado(int id)
        {
            Internet_Ilimitado internet_Ilimitado = db.Internet_Ilimitado.Find(id);
            if (internet_Ilimitado == null)
            {
                return NotFound();
            }

            return Ok(internet_Ilimitado);
        }

        // PUT: api/Internet_Ilimitado/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutInternet_Ilimitado(int id, Internet_Ilimitado internet_Ilimitado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != internet_Ilimitado.Id)
            {
                return BadRequest();
            }

            db.Entry(internet_Ilimitado).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Internet_IlimitadoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Internet_Ilimitado
        [ResponseType(typeof(Internet_Ilimitado))]
        public IHttpActionResult PostInternet_Ilimitado(Internet_Ilimitado internet_Ilimitado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Internet_Ilimitado.Add(internet_Ilimitado);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = internet_Ilimitado.Id }, internet_Ilimitado);
        }

        // DELETE: api/Internet_Ilimitado/5
        [ResponseType(typeof(Internet_Ilimitado))]
        public IHttpActionResult DeleteInternet_Ilimitado(int id)
        {
            Internet_Ilimitado internet_Ilimitado = db.Internet_Ilimitado.Find(id);
            if (internet_Ilimitado == null)
            {
                return NotFound();
            }

            db.Internet_Ilimitado.Remove(internet_Ilimitado);
            db.SaveChanges();

            return Ok(internet_Ilimitado);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Internet_IlimitadoExists(int id)
        {
            return db.Internet_Ilimitado.Count(e => e.Id == id) > 0;
        }
    }
}
