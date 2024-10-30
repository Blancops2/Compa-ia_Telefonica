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
    public class Antena_SatelitalController : ApiController
    {
        private DBContextProject db = new DBContextProject();

        // GET: api/Antena_Satelital
        public IQueryable<Antena_Satelital> GetAntena_Satelital()
        {
            return db.Antena_Satelital;
        }

        // GET: api/Antena_Satelital/5
        [ResponseType(typeof(Antena_Satelital))]
        public IHttpActionResult GetAntena_Satelital(int id)
        {
            Antena_Satelital antena_Satelital = db.Antena_Satelital.Find(id);
            if (antena_Satelital == null)
            {
                return NotFound();
            }

            return Ok(antena_Satelital);
        }

        // PUT: api/Antena_Satelital/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAntena_Satelital(int id, Antena_Satelital antena_Satelital)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != antena_Satelital.Id)
            {
                return BadRequest();
            }

            db.Entry(antena_Satelital).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Antena_SatelitalExists(id))
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

        // POST: api/Antena_Satelital
        [ResponseType(typeof(Antena_Satelital))]
        public IHttpActionResult PostAntena_Satelital(Antena_Satelital antena_Satelital)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Antena_Satelital.Add(antena_Satelital);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = antena_Satelital.Id }, antena_Satelital);
        }

        // DELETE: api/Antena_Satelital/5
        [ResponseType(typeof(Antena_Satelital))]
        public IHttpActionResult DeleteAntena_Satelital(int id)
        {
            Antena_Satelital antena_Satelital = db.Antena_Satelital.Find(id);
            if (antena_Satelital == null)
            {
                return NotFound();
            }

            db.Antena_Satelital.Remove(antena_Satelital);
            db.SaveChanges();

            return Ok(antena_Satelital);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Antena_SatelitalExists(int id)
        {
            return db.Antena_Satelital.Count(e => e.Id == id) > 0;
        }
    }
}
