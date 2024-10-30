using _Compañia_Telefonica_Api.Models.Cable;
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
    public class Cbl_PremiumController : ApiController
    {
        private DBContextProject db = new DBContextProject();

        // GET: api/Cbl_Premium
        public IQueryable<Cbl_Premium> GetCable_Premium()
        {
            return db.Cable_Premium;
        }

        // GET: api/Cbl_Premium/5
        [ResponseType(typeof(Cbl_Premium))]
        public IHttpActionResult GetCbl_Premium(int id)
        {
            Cbl_Premium cbl_Premium = db.Cable_Premium.Find(id);
            if (cbl_Premium == null)
            {
                return NotFound();
            }

            return Ok(cbl_Premium);
        }

        // PUT: api/Cbl_Premium/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCbl_Premium(int id, Cbl_Premium cbl_Premium)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cbl_Premium.Id)
            {
                return BadRequest();
            }

            db.Entry(cbl_Premium).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Cbl_PremiumExists(id))
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

        // POST: api/Cbl_Premium
        [ResponseType(typeof(Cbl_Premium))]
        public IHttpActionResult PostCbl_Premium(Cbl_Premium cbl_Premium)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cable_Premium.Add(cbl_Premium);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cbl_Premium.Id }, cbl_Premium);
        }

        // DELETE: api/Cbl_Premium/5
        [ResponseType(typeof(Cbl_Premium))]
        public IHttpActionResult DeleteCbl_Premium(int id)
        {
            Cbl_Premium cbl_Premium = db.Cable_Premium.Find(id);
            if (cbl_Premium == null)
            {
                return NotFound();
            }

            db.Cable_Premium.Remove(cbl_Premium);
            db.SaveChanges();

            return Ok(cbl_Premium);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Cbl_PremiumExists(int id)
        {
            return db.Cable_Premium.Count(e => e.Id == id) > 0;
        }
    }
}
