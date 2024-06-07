using PassionProject2024N01604846.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Diagnostics;
using System.Web.Http.Description;
using static System.Net.WebRequestMethods;

namespace PassionProject2024N01604846.Controllers
{
    public class InstrumentLessonDataController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        /// <summary>
        /// Lists the instrument lessons in the database
        /// </summary>
        /// <returns>an array of intrument lesson objects Dtos </returns>
        /// <example>
        /// Get: api/InstrumentLessonData/ListInstrumentLesson -> [{ "LessonId": 1, "LessonName": "Guitar"}{"LessonId": 2, "LessonName": "Piano"}] 
        /// </example>
        [HttpGet]
        [Route("api/InstrumentLessonData/ListInstrumentLesson")]
        public List<InstrumentLessonDto> ListInstrumentLessons()
        {
            // this is similar to Select * from InstrumentLesson
            List<InstrumentLesson> Lessons = db.InstrumentLessons.ToList();

            List<InstrumentLessonDto> LessonDtos = new List<InstrumentLessonDto>();

            foreach (InstrumentLesson Lesson in Lessons)
            {
                InstrumentLessonDto Dto = new InstrumentLessonDto();

                Dto.LessonName = Lesson.LessonName;
                Dto.StartDate = Lesson.StartDate;
                Dto.EndDate = Lesson.EndDate;
                Dto.LessonID = Lesson.LessonID;
                Dto.FirstName = Lesson.Instructor.FirstName;
                Dto.InstructorId = Lesson.Instructor.InstructorId;
                LessonDtos.Add(Dto);
            }

            return LessonDtos;
        }
        /// <summary>
        /// Retrieves the details of a specific instructor based on the provided ID.
        /// </summary>
        /// <param name="id">The ID of the instructor to retrieve.</param>
        /// <returns>An IHttpActionResult containing the instructor details if found, otherwise a NotFound result.</returns>
        /// <example>
        /// GET: /api/InstructorData/FindInstructor/5
        /// This will retrieve the instructor with ID 5 and return its details as an InstructorDto object.
        /// </example>
        [ResponseType(typeof(InstructorDto))]
        [HttpGet]

        public IHttpActionResult FindInstructor(int id)
        {
            Instructor Instructor = db.Instructors.Find(id);
            InstructorDto InstructorDto = new InstructorDto()
            {

                InstructorId = Instructor.InstructorId,
                FirstName = Instructor.FirstName
                //InstrumentLessonWeight = Instructor.InstrumentLessonWeight,
                //SpeciesID = Instructor.Species.SpeciesID,
                //SpeciesName = InstrumentLesson.Species.SpeciesName
            };
            if (Instructor == null)
            {
                return NotFound();
            }

            return Ok(InstructorDto);

        }
        /// <summary>
        /// Retrieves the details of a specific instrument lesson based on the provided ID.
        /// </summary>
        /// <param name="id">The ID of the instrument lesson to retrieve.</param>
        /// <returns>An IHttpActionResult containing the instrument lesson details if found, otherwise a NotFound result.</returns>
        /// <example>
        /// GET: /api/InstrumentLessonData/FindInstrumentLesson/5
        /// This will retrieve the instrument lesson with ID 5 and return its details as an InstrumentLessonDto object.
        /// </example>
        [ResponseType(typeof(InstrumentLessonDto))]
        [HttpGet]
        public IHttpActionResult FindInstrumentLesson(int id)
        {
            InstrumentLesson instrumentLesson = db.InstrumentLessons.Find(id);
            if (instrumentLesson == null)
            {
                return NotFound();
            }

            InstrumentLessonDto instrumentLessonDto = new InstrumentLessonDto
            {
                LessonID = instrumentLesson.LessonID,
                LessonName = instrumentLesson.LessonName,
                StartDate = instrumentLesson.StartDate,
                EndDate = instrumentLesson.EndDate,
                InstructorId = instrumentLesson.InstructorId,
                FirstName = instrumentLesson.Instructor?.FirstName,
                LastName = instrumentLesson.Instructor?.LastName
            };

            return Ok(instrumentLessonDto);

        }
        /// <summary>
        /// Updates the details of a specific instrument lesson by sending the provided data to the API.
        /// </summary>
        /// <param name="id">The ID of the instrument lesson to be updated.</param>
        /// <param name="instrumentLessonDto">The instrument lesson DTO containing the updated details.</param>
        /// <returns>An IHttpActionResult indicating the result of the update operation.</returns>
        /// <example>
        /// POST: /api/InstrumentLessonData/UpdateInstrumentLesson/5
        /// This will update the instrument lesson with ID 5 using the provided details in the InstrumentLessonDto object.
        /// </example>
        //curl -d @instructor.json -H "Content-type:application/json" https://localhost:44300/api/InstrumentLessonData/UpdateInstructor/1

        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult UpdateInstrumentLesson(int id, InstrumentLessonDto instrumentLessonDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != instrumentLessonDto.LessonID)
            {
                return BadRequest();
            }

            InstrumentLesson instrumentLesson = db.InstrumentLessons.Find(id);
            if (instrumentLesson == null)
            {
                return NotFound();
            }

            instrumentLesson.LessonName = instrumentLessonDto.LessonName;
            instrumentLesson.StartDate = instrumentLessonDto.StartDate;
            instrumentLesson.EndDate = instrumentLessonDto.EndDate;
            instrumentLesson.InstructorId = instrumentLessonDto.InstructorId;

            db.Entry(instrumentLesson).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InstrumentLessonExists(id))
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
        /// <summary>
        /// Adds a new instrument lesson by sending the provided data to the API.
        /// </summary>
        /// <param name="instrumentLesson">The instrument lesson object containing the details to be added.</param>
        /// <returns>An IHttpActionResult indicating the result of the add operation. Returns Ok if successful, otherwise returns BadRequest with the model state.</returns>
        /// <example>
        /// POST: /api/InstrumentLessonData/AddInstrumentLesson
        /// This will add a new instrument lesson using the provided details in the InstrumentLesson object.
        /// </example>
        [ResponseType(typeof(InstrumentLesson))]
        [HttpPost]
        public IHttpActionResult AddInstrumentLesson(InstrumentLesson instrumentLesson)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.InstrumentLessons.Add(instrumentLesson);
            db.SaveChanges();

            return Ok();
        }
        /// <summary>
        /// Deletes a specific instrument lesson by sending a delete request to the API.
        /// </summary>
        /// <param name="id">The ID of the instrument lesson to be deleted.</param>
        /// <returns>An IHttpActionResult indicating the result of the delete operation. Returns Ok if successful, otherwise returns NotFound.</returns>
        /// <example>
        /// POST: /api/InstrumentLessonData/DeleteInstrumentLesson/2
        /// This will delete the instrument lesson with ID 2 from the database.
        /// </example>
        // POST: api/InstrumentLessonData/DeleteInstructor/2
        [ResponseType(typeof(InstrumentLesson))]
        [HttpPost]
        public IHttpActionResult DeleteInstrumentLesson(int id)
        {
            InstrumentLesson instrumentlesson = db.InstrumentLessons.Find(id);
            if (instrumentlesson == null)
            {
                return NotFound();
            }

            db.InstrumentLessons.Remove(instrumentlesson);
            db.SaveChanges();

            return Ok(instrumentlesson);
        }
        /// <summary>
        /// Checks if an instrument lesson with the specified ID exists in the database.
        /// </summary>
        /// <param name="id">The ID of the instrument lesson to check for existence.</param>
        /// <returns>True if an instrument lesson with the specified ID exists, otherwise false.</returns>
        /// <example>
        /// bool lessonExists = InstrumentLessonExists(5);
        /// </example>
        private bool InstrumentLessonExists(int id)
        {
            return db.InstrumentLessons.Count(e => e.LessonID == id) > 0;
        }
    }
}
