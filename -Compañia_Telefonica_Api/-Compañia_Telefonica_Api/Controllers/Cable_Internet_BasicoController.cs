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
    public class Cable_Internet_BasicoController : ApiController
    {
        private DBContextProject db = new DBContextProject();

        // GET: api/Cable_Internet_Basico
        public IQueryable<Cable_Internet_Basico> GetCable_Internet_Basico()
        {
            return db.Cable_Internet_Basico;
        }

        // GET: api/Cable_Internet_Basico/5
        [ResponseType(typeof(Cable_Internet_Basico))]
        public IHttpActionResult GetCable_Internet_Basico(int id)
        {
            Cable_Internet_Basico cable_Internet_Basico = db.Cable_Internet_Basico.Find(id);
            if (cable_Internet_Basico == null)
            {
                return NotFound();
            }

            return Ok(cable_Internet_Basico);
        }

        // PUT: api/Cable_Internet_Basico/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCable_Internet_Basico(int id, Cable_Internet_Basico cable_Internet_Basico)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cable_Internet_Basico.Id)
            {
                return BadRequest();
            }

            db.Entry(cable_Internet_Basico).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Cable_Internet_BasicoExists(id))
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

        // POST: api/Cable_Internet_Basico
        [ResponseType(typeof(Cable_Internet_Basico))]
        public IHttpActionResult PostCable_Internet_Basico(Cable_Internet_Basico cable_Internet_Basico)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cable_Internet_Basico.Add(cable_Internet_Basico);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cable_Internet_Basico.Id }, cable_Internet_Basico);
        }

        // DELETE: api/Cable_Internet_Basico/5
        [ResponseType(typeof(Cable_Internet_Basico))]
        public IHttpActionResult DeleteCable_Internet_Basico(int id)
        {
            Cable_Internet_Basico cable_Internet_Basico = db.Cable_Internet_Basico.Find(id);
            if (cable_Internet_Basico == null)
            {
                return NotFound();
            }

            db.Cable_Internet_Basico.Remove(cable_Internet_Basico);
            db.SaveChanges();

            return Ok(cable_Internet_Basico);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Cable_Internet_BasicoExists(int id)
        {
            return db.Cable_Internet_Basico.Count(e => e.Id == id) > 0;
        }
    }
}
