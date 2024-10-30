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
    public class Recarga_ClsController : ApiController
    {
        private DBContextProject db = new DBContextProject();

        // GET: api/Recarga_Cls
        public IQueryable<Recarga_Cls> GetRecarga_Cls()
        {
            return db.Recarga_Cls;
        }

        // GET: api/Recarga_Cls/5
        [ResponseType(typeof(Recarga_Cls))]
        public IHttpActionResult GetRecarga_Cls(int id)
        {
            Recarga_Cls recarga_Cls = db.Recarga_Cls.Find(id);
            if (recarga_Cls == null)
            {
                return NotFound();
            }

            return Ok(recarga_Cls);
        }

        // PUT: api/Recarga_Cls/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRecarga_Cls(int id, Recarga_Cls recarga_Cls)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != recarga_Cls.Id)
            {
                return BadRequest();
            }

            db.Entry(recarga_Cls).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Recarga_ClsExists(id))
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

        // POST: api/Recarga_Cls
        [ResponseType(typeof(Recarga_Cls))]
        public IHttpActionResult PostRecarga_Cls(Recarga_Cls recarga_Cls)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Recarga_Cls.Add(recarga_Cls);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = recarga_Cls.Id }, recarga_Cls);
        }

        // DELETE: api/Recarga_Cls/5
        [ResponseType(typeof(Recarga_Cls))]
        public IHttpActionResult DeleteRecarga_Cls(int id)
        {
            Recarga_Cls recarga_Cls = db.Recarga_Cls.Find(id);
            if (recarga_Cls == null)
            {
                return NotFound();
            }

            db.Recarga_Cls.Remove(recarga_Cls);
            db.SaveChanges();

            return Ok(recarga_Cls);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Recarga_ClsExists(int id)
        {
            return db.Recarga_Cls.Count(e => e.Id == id) > 0;
        }
    }
}
