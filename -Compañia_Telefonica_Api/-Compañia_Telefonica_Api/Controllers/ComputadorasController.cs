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
    public class ComputadorasController : ApiController
    {
        private DBContextProject db = new DBContextProject();

        // GET: api/Computadoras
        public IQueryable<Computadoras> GetComputadoras()
        {
            return db.Computadoras;
        }

        // GET: api/Computadoras/5
        [ResponseType(typeof(Computadoras))]
        public IHttpActionResult GetComputadoras(int id)
        {
            Computadoras computadoras = db.Computadoras.Find(id);
            if (computadoras == null)
            {
                return NotFound();
            }

            return Ok(computadoras);
        }

        // PUT: api/Computadoras/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutComputadoras(int id, Computadoras computadoras)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != computadoras.Id)
            {
                return BadRequest();
            }

            db.Entry(computadoras).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComputadorasExists(id))
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

        // POST: api/Computadoras
        [ResponseType(typeof(Computadoras))]
        public IHttpActionResult PostComputadoras(Computadoras computadoras)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Computadoras.Add(computadoras);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = computadoras.Id }, computadoras);
        }

        // DELETE: api/Computadoras/5
        [ResponseType(typeof(Computadoras))]
        public IHttpActionResult DeleteComputadoras(int id)
        {
            Computadoras computadoras = db.Computadoras.Find(id);
            if (computadoras == null)
            {
                return NotFound();
            }

            db.Computadoras.Remove(computadoras);
            db.SaveChanges();

            return Ok(computadoras);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ComputadorasExists(int id)
        {
            return db.Computadoras.Count(e => e.Id == id) > 0;
        }
    }
}
