using _Compañia_Telefonica_Api.Models.Internet_Residencial;
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
    public class Fibra_OpticaController : ApiController
    {
        private DBContextProject db = new DBContextProject();

        // GET: api/Fibra_Optica
        public IQueryable<Fibra_Optica> GetFibra_Optica()
        {
            return db.Fibra_Optica;
        }

        // GET: api/Fibra_Optica/5
        [ResponseType(typeof(Fibra_Optica))]
        public IHttpActionResult GetFibra_Optica(int id)
        {
            Fibra_Optica fibra_Optica = db.Fibra_Optica.Find(id);
            if (fibra_Optica == null)
            {
                return NotFound();
            }

            return Ok(fibra_Optica);
        }

        // PUT: api/Fibra_Optica/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFibra_Optica(int id, Fibra_Optica fibra_Optica)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fibra_Optica.Id)
            {
                return BadRequest();
            }

            db.Entry(fibra_Optica).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Fibra_OpticaExists(id))
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

        // POST: api/Fibra_Optica
        [ResponseType(typeof(Fibra_Optica))]
        public IHttpActionResult PostFibra_Optica(Fibra_Optica fibra_Optica)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Fibra_Optica.Add(fibra_Optica);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = fibra_Optica.Id }, fibra_Optica);
        }

        // DELETE: api/Fibra_Optica/5
        [ResponseType(typeof(Fibra_Optica))]
        public IHttpActionResult DeleteFibra_Optica(int id)
        {
            Fibra_Optica fibra_Optica = db.Fibra_Optica.Find(id);
            if (fibra_Optica == null)
            {
                return NotFound();
            }

            db.Fibra_Optica.Remove(fibra_Optica);
            db.SaveChanges();

            return Ok(fibra_Optica);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Fibra_OpticaExists(int id)
        {
            return db.Fibra_Optica.Count(e => e.Id == id) > 0;
        }
    }
}
