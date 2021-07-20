using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CRMProspecto.Models;

namespace CRMProspecto.Controllers
{
    public class ProspectosInformacionsController : ApiController
    {
        private EjercicioCRMEntities db = new EjercicioCRMEntities();

        // GET: api/ProspectosInformacions
        public IQueryable<ProspectosInformacion> GetProspectosInformacion()
        {
            return db.ProspectosInformacion;
        }

        // GET: api/ProspectosInformacions/5
        [ResponseType(typeof(ProspectosInformacion))]
        public IHttpActionResult GetProspectosInformacion(int id)
        {
            ProspectosInformacion prospectosInformacion = db.ProspectosInformacion.Find(id);
            if (prospectosInformacion == null)
            {
                return NotFound();
            }

            return Ok(prospectosInformacion);
        }

        // PUT: api/ProspectosInformacions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProspectosInformacion(int id, ProspectosInformacion prospectosInformacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != prospectosInformacion.Id)
            {
                return BadRequest();
            }

            db.Entry(prospectosInformacion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProspectosInformacionExists(id))
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

        // POST: api/ProspectosInformacions
        [ResponseType(typeof(ProspectosInformacion))]
        public IHttpActionResult PostProspectosInformacion(ProspectosInformacion prospectosInformacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProspectosInformacion.Add(prospectosInformacion);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = prospectosInformacion.Id }, prospectosInformacion);
        }

        // DELETE: api/ProspectosInformacions/5
        [ResponseType(typeof(ProspectosInformacion))]
        public IHttpActionResult DeleteProspectosInformacion(int id)
        {
            ProspectosInformacion prospectosInformacion = db.ProspectosInformacion.Find(id);
            if (prospectosInformacion == null)
            {
                return NotFound();
            }

            db.ProspectosInformacion.Remove(prospectosInformacion);
            db.SaveChanges();

            return Ok(prospectosInformacion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProspectosInformacionExists(int id)
        {
            return db.ProspectosInformacion.Count(e => e.Id == id) > 0;
        }
    }
}