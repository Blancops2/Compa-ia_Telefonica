using _Compañia_Telefonica_Api.Models.Tecnologia;
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
    public class CelularController : ApiController
    {
        private DBContextProject db = new DBContextProject();

        // GET: api/Celular
        public IQueryable<Celular> GetCelular()
        {
            return db.Celular;
        }

        // GET: api/Celular/5
        [ResponseType(typeof(Celular))]
        public IHttpActionResult GetCelular(int id)
        {
            Celular celular = db.Celular.Find(id);
            if (celular == null)
            {
                return NotFound();
            }

            return Ok(celular);
        }

        // PUT: api/Celular/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCelular(int id, Celular celular)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != celular.Id)
            {
                return BadRequest();
            }

            db.Entry(celular).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CelularExists(id))
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

        // POST: api/Celular
        [ResponseType(typeof(Celular))]
        public IHttpActionResult PostCelular(Celular celular)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Celular.Add(celular);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = celular.Id }, celular);
        }

        // DELETE: api/Celular/5
        [ResponseType(typeof(Celular))]
        public IHttpActionResult DeleteCelular(int id)
        {
            Celular celular = db.Celular.Find(id);
            if (celular == null)
            {
                return NotFound();
            }

            db.Celular.Remove(celular);
            db.SaveChanges();

            return Ok(celular);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CelularExists(int id)
        {
            return db.Celular.Count(e => e.Id == id) > 0;
        }
    }
}
