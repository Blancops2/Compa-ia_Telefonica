using _Compañia_Telefonica_Api.Models.Cable_Internet;
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
    public class Cable_Internet_PremiumController : ApiController
    {
        private DBContextProject db = new DBContextProject();

        // GET: api/Cable_Internet_Premium
        public IQueryable<Cable_Internet_Premium> GetCable_Internet_Premium()
        {
            return db.Cable_Internet_Premium;
        }

        // GET: api/Cable_Internet_Premium/5
        [ResponseType(typeof(Cable_Internet_Premium))]
        public IHttpActionResult GetCable_Internet_Premium(int id)
        {
            Cable_Internet_Premium cable_Internet_Premium = db.Cable_Internet_Premium.Find(id);
            if (cable_Internet_Premium == null)
            {
                return NotFound();
            }

            return Ok(cable_Internet_Premium);
        }

        // PUT: api/Cable_Internet_Premium/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCable_Internet_Premium(int id, Cable_Internet_Premium cable_Internet_Premium)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cable_Internet_Premium.Id)
            {
                return BadRequest();
            }

            db.Entry(cable_Internet_Premium).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Cable_Internet_PremiumExists(id))
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

        // POST: api/Cable_Internet_Premium
        [ResponseType(typeof(Cable_Internet_Premium))]
        public IHttpActionResult PostCable_Internet_Premium(Cable_Internet_Premium cable_Internet_Premium)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cable_Internet_Premium.Add(cable_Internet_Premium);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cable_Internet_Premium.Id }, cable_Internet_Premium);
        }

        // DELETE: api/Cable_Internet_Premium/5
        [ResponseType(typeof(Cable_Internet_Premium))]
        public IHttpActionResult DeleteCable_Internet_Premium(int id)
        {
            Cable_Internet_Premium cable_Internet_Premium = db.Cable_Internet_Premium.Find(id);
            if (cable_Internet_Premium == null)
            {
                return NotFound();
            }

            db.Cable_Internet_Premium.Remove(cable_Internet_Premium);
            db.SaveChanges();

            return Ok(cable_Internet_Premium);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Cable_Internet_PremiumExists(int id)
        {
            return db.Cable_Internet_Premium.Count(e => e.Id == id) > 0;
        }
    }
}
