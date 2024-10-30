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
    public class SuperPackController : ApiController
    {
        private DBContextProject db = new DBContextProject();

        // GET: api/SuperPack
        public IQueryable<SuperPack> GetSuperPack()
        {
            return db.SuperPack;
        }

        // GET: api/SuperPack/5
        [ResponseType(typeof(SuperPack))]
        public IHttpActionResult GetSuperPack(int id)
        {
            SuperPack superPack = db.SuperPack.Find(id);
            if (superPack == null)
            {
                return NotFound();
            }

            return Ok(superPack);
        }

        // PUT: api/SuperPack/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSuperPack(int id, SuperPack superPack)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != superPack.Id)
            {
                return BadRequest();
            }

            db.Entry(superPack).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SuperPackExists(id))
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

        // POST: api/SuperPack
        [ResponseType(typeof(SuperPack))]
        public IHttpActionResult PostSuperPack(SuperPack superPack)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SuperPack.Add(superPack);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = superPack.Id }, superPack);
        }

        // DELETE: api/SuperPack/5
        [ResponseType(typeof(SuperPack))]
        public IHttpActionResult DeleteSuperPack(int id)
        {
            SuperPack superPack = db.SuperPack.Find(id);
            if (superPack == null)
            {
                return NotFound();
            }

            db.SuperPack.Remove(superPack);
            db.SaveChanges();

            return Ok(superPack);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SuperPackExists(int id)
        {
            return db.SuperPack.Count(e => e.Id == id) > 0;
        }
    }
}
