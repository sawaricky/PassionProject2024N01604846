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
using PassionProject2024N01604846.Models;

namespace PassionProject2024N01604846.Controllers
{
    public class AcademyDataController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: api/AcademyData/ListAcademy
        /// <summary>
        /// Retrieves a list of academies from the database in DTO format.
        /// </summary>
        /// <returns>An enumerable list of AcademyDto objects showing academies.</returns>
        // GET: api/AcademyData/ListAcademy
        [HttpGet]
        public IEnumerable<AcademyDto> ListAcademy()
        {
            List<Academy> Academys = db.Academys.ToList();
            List<AcademyDto> AcademyDtos = new List<AcademyDto>();

            Academys.ForEach(a => AcademyDtos.Add(new AcademyDto()
            {
                AcademyId = a.AcademyId,
                AcademyAddress = a.AcademyAddress,
                AcademyName = a.AcademyName
            }));
            return AcademyDtos;
        }
        // GET: api/AcademyData/FindAcademy
        /// <summary>
        /// Retrieves details of a specific academy by its ID.
        /// </summary>
        /// <param name="id">The ID of the academy to retrieve.</param>
        /// <returns>Returns the details of the academy by the given ID in DTO format.</returns>
        [ResponseType(typeof(InstructorDto))]
        [HttpGet]

        public IHttpActionResult FindAcademy(int id)
        {
            Academy academy = db.Academys.Find(id);
            AcademyDto AcademyDto = new AcademyDto()
            {
                AcademyId = academy.AcademyId,
                AcademyName = academy.AcademyName,
                AcademyAddress = academy.AcademyAddress

            };

            if (academy == null)
            {
                return NotFound();
            }
            return Ok(AcademyDto);

        }
        // POST: api/AcademyData/UpdateAcademy
        /// <summary>
        /// Updates the details of an existing academy in the database.
        /// </summary>
        /// <param name="id">The ID of the academy to update.</param>
        /// <param name="academy">The updated academy object containing new details.</param>
        /// <returns>Returns a status code indicating the success of the update operation.</returns>
        // Post: api/AcademyData/5
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult UpdateAcademy(int id, Academy academy)
        {
            if (academy == null)
            {
                return BadRequest("Academy object is null. Please check the request body format and ensure it is correctly formatted JSON.");
            }

            db.Entry(academy).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AcademyExists(id))
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
        // POST: api/AcademyData/AddAcademy
        /// <summary>
        /// Adds a new academy to the database.
        /// </summary>
        /// <param name="academy">The academy object to add.</param>
        /// <returns>Returns the newly added academy.</returns>
        // POST: api/AcademyData
        [ResponseType(typeof(Academy))]
        [HttpPost]
        public IHttpActionResult AddAcademy(Academy academy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Academys.Add(academy);
            db.SaveChanges();

            return Ok(academy);
        }
        // POST: api/AcademyData/DeleteAcademy/5
        /// <summary>
        /// Deletes an existing academy from the database.
        /// </summary>
        /// <param name="id">The ID of the academy to delete.</param>
        /// <returns>Returns the deleted academy if successful; otherwise, returns a NotFound response.</returns>
        // DELETE: api/AcademyData/5
        [ResponseType(typeof(Academy))]
        [HttpPost]
        public IHttpActionResult DeleteAcademy(int id)
        {
            Academy academy = db.Academys.Find(id);
            if (academy == null)
            {
                return NotFound();
            }

            db.Academys.Remove(academy);
            db.SaveChanges();

            return Ok(academy);
        }
        /// <summary>
        /// Disposes resources used by the controller.
        /// </summary>
        /// <param name="disposing">Set to true if cleaning up resources that the code has allocated; set to false otherwise.</param>

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        /// <summary>
        /// Checks if an academy exists in the database based on its ID.
        /// </summary>
        /// <param name="id">The ID of the academy to check.</param>
        /// <returns>True if an academy with the specified ID exists; otherwise, false.</returns>
        private bool AcademyExists(int id)
        {
            return db.Academys.Count(e => e.AcademyId == id) > 0;
        }
    }
}