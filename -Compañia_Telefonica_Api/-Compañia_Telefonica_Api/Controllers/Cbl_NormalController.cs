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
    public class Cbl_NormalController : ApiController
    {
        private DBContextProject db = new DBContextProject();

        // GET: api/Cbl_Normal
        public IQueryable<Cbl_Normal> GetCable_Normal()
        {
            return db.Cable_Normal;
        }

        // GET: api/Cbl_Normal/5
        [ResponseType(typeof(Cbl_Normal))]
        public IHttpActionResult GetCbl_Normal(int id)
        {
            Cbl_Normal cbl_Normal = db.Cable_Normal.Find(id);
            if (cbl_Normal == null)
            {
                return NotFound();
            }

            return Ok(cbl_Normal);
        }

        // PUT: api/Cbl_Normal/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCbl_Normal(int id, Cbl_Normal cbl_Normal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cbl_Normal.Id)
            {
                return BadRequest();
            }

            db.Entry(cbl_Normal).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Cbl_NormalExists(id))
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

        // POST: api/Cbl_Normal
        [ResponseType(typeof(Cbl_Normal))]
        public IHttpActionResult PostCbl_Normal(Cbl_Normal cbl_Normal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cable_Normal.Add(cbl_Normal);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cbl_Normal.Id }, cbl_Normal);
        }

        // DELETE: api/Cbl_Normal/5
        [ResponseType(typeof(Cbl_Normal))]
        public IHttpActionResult DeleteCbl_Normal(int id)
        {
            Cbl_Normal cbl_Normal = db.Cable_Normal.Find(id);
            if (cbl_Normal == null)
            {
                return NotFound();
            }

            db.Cable_Normal.Remove(cbl_Normal);
            db.SaveChanges();

            return Ok(cbl_Normal);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Cbl_NormalExists(int id)
        {
            return db.Cable_Normal.Count(e => e.Id == id) > 0;
        }
    }
}
