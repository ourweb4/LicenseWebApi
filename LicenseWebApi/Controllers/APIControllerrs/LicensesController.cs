using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using LicenseWebApi.Models;

namespace LicenseWebApi.Controllers.APIControllerrs
{
    public class LicensesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Licenses
        public IQueryable<License> GetLicenses()
        {
            return db.Licenses;
        }

        // GET: api/Licenses/5
        [ResponseType(typeof(License))]
        public async Task<IHttpActionResult> GetLicense(int id)
        {
            License license = await db.Licenses.FindAsync(id);
            if (license == null)
            {
                return NotFound();
            }

            return Ok(license);
        }

        // PUT: api/Licenses/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutLicense(int id, License license)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != license.Id)
            {
                return BadRequest();
            }

            db.Entry(license).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LicenseExists(id))
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

        // POST: api/Licenses
        [ResponseType(typeof(License))]
        public async Task<IHttpActionResult> PostLicense(License license)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Licenses.Add(license);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = license.Id }, license);
        }

        // DELETE: api/Licenses/5
        [ResponseType(typeof(License))]
        public async Task<IHttpActionResult> DeleteLicense(int id)
        {
            License license = await db.Licenses.FindAsync(id);
            if (license == null)
            {
                return NotFound();
            }

            db.Licenses.Remove(license);
            await db.SaveChangesAsync();

            return Ok(license);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LicenseExists(int id)
        {
            return db.Licenses.Count(e => e.Id == id) > 0;
        }
    }
}