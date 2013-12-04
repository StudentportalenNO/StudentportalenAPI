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
using Ninject;
using StudentportalenAPI.DAL;
using StudentportalenAPI.Models;
using StudentportalenAPI.DAL.Configuration.Entityframework;

namespace StudentportalenAPI.Web.Controllers
{
    public class SchoolsController : ApiController
    {
        [Inject]
        public UnitOfWork UOW;

        // GET api/Schools
        public IQueryable<School> GetSchools()
        {
            return UOW.Schools;
        }

        // GET api/Schools/5
        [ResponseType(typeof(School))]
        public async Task<IHttpActionResult> GetSchool(int id)
        {
            School school = await UOW.Schools.FindAsync(id);
            if (school == null)
            {
                return NotFound();
            }

            return Ok(school);
        }

        // PUT api/Schools/5
        public async Task<IHttpActionResult> PutSchool(int id, School school)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != school.Id)
            {
                return BadRequest();
            }

            db.Entry(school).State = EntityState.Modified;

            try
            {
                await UOW.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SchoolExists(id))
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

        // POST api/Schools
        [ResponseType(typeof(School))]
        public async Task<IHttpActionResult> PostSchool(School school)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            UOW.Schools.Add(school);
            await UOW.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = school.Id }, school);
        }

        // DELETE api/Schools/5
        [ResponseType(typeof(School))]
        public async Task<IHttpActionResult> DeleteSchool(int id)
        {
            School school = await UOW.Schools.FindAsync(id);
            if (school == null)
            {
                return NotFound();
            }

            UOW.Schools.Remove(school);
            await UOW.SaveChangesAsync();

            return Ok(school);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                UOW.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SchoolExists(int id)
        {
            return UOW.Schools.Count(e => e.Id == id) > 0;
        }
    }
}