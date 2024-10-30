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
    public class PromocionesController : ApiController
    {
        private DBContextProject db = new DBContextProject();

        // GET: api/Promociones
        public IQueryable<Promociones> GetPromociones()
        {
            return db.Promociones;
        }

        // GET: api/Promociones/5
        [ResponseType(typeof(Promociones))]
        public IHttpActionResult GetPromociones(int id)
        {
            Promociones promociones = db.Promociones.Find(id);
            if (promociones == null)
            {
                return NotFound();
            }

            return Ok(promociones);
        }

        // PUT: api/Promociones/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPromociones(int id, Promociones promociones)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != promociones.Id)
            {
                return BadRequest();
            }

            db.Entry(promociones).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PromocionesExists(id))
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

        // POST: api/Promociones
        [ResponseType(typeof(Promociones))]
        public IHttpActionResult PostPromociones(Promociones promociones)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Promociones.Add(promociones);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = promociones.Id }, promociones);
        }

        // DELETE: api/Promociones/5
        [ResponseType(typeof(Promociones))]
        public IHttpActionResult DeletePromociones(int id)
        {
            Promociones promociones = db.Promociones.Find(id);
            if (promociones == null)
            {
                return NotFound();
            }

            db.Promociones.Remove(promociones);
            db.SaveChanges();

            return Ok(promociones);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PromocionesExists(int id)
        {
            return db.Promociones.Count(e => e.Id == id) > 0;
        }
    }
}
