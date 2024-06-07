using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using static System.Net.WebRequestMethods;
using PassionProject2024N01604846.Models;
using System.Web.Script.Serialization;

namespace PassionProject2024N01604846.Controllers
{
    ///
    public class InstructorController : Controller
    {
        private JavaScriptSerializer jss = new JavaScriptSerializer();

        // GET: Instructor/List
        /// <summary>
        /// To list the data from the database for the instrument lessons
        /// </summary>
        /// <example>
        /// https://localhost:44300/api/InstrumentLessonData/ListInstrumentLesson
        /// </example>
        /// <returns>Lesson information</returns>
        public ActionResult List()
        {
            
            //objective: communivate with out instructor data api to retrieve a list of instrumetn lessons 
            //curl https://localhost:44300/api/InstrumentLessonData/ListInstrumentLesson
            HttpClient client = new HttpClient();
            string url = "https://localhost:44300/api/InstrumentLessonData/ListInstrumentLesson";
            HttpResponseMessage response = client.GetAsync(url).Result;

            Debug.WriteLine("The response code is ");
            Debug.WriteLine(response.StatusCode);

            IEnumerable<InstrumentLessonDto> lessons = response.Content.ReadAsAsync<IEnumerable<InstrumentLessonDto>>().Result;
            Debug.WriteLine("number of lessons received ");
            Debug.WriteLine(lessons.Count());

            return View(lessons);
        }
        /// <summary>
        /// Retrieves the details of a specific instrument lesson based on the provided ID.
        /// </summary>
        /// /// <param name="id">The ID of the instrument lesson to retrieve.</param>
        /// <example>
        /// GET: /InstrumentLesson/Details/5
        /// This will communicate with the InstrumentLessonData API and retrieve the instrument lesson with ID 5,
        /// and then display its details in the view.
        /// </example>
        public ActionResult Details(int id)
        {
            // Objective: Communicate with our instructor data API to retrieve one instructor
            HttpClient client = new HttpClient();
            string url = "https://localhost:44300/api/InstrumentLessonData/FindInstrumentLesson/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;


            InstrumentLessonDto selectedInstructor = response.Content.ReadAsAsync<InstrumentLessonDto>().Result;
            Debug.WriteLine("Instructor received ");

            return View(selectedInstructor);
        }

        // GET: Instructor/New
        public ActionResult New()
        {
            return View();
        }
        /// <summary>
        /// Creates a new instrument lesson by posting the provided data to the API.
        /// </summary>
        /// /// <param name="instrumentlesson">The instrument lesson object containing the details to be created.</param>
        /// <returns>A redirection to the list view if the creation is successful, otherwise it will redirect to an error view.
        /// </returns>
        /// /// <example>
        /// POST: /Instructor/Create
        /// This will send a JSON payload containing the new instrument lesson details to the InstrumentLessonData API and create the instrument lesson in the system.
        /// </example>
        // POST: Instructor/Create
        [HttpPost]
        public ActionResult Create(InstrumentLesson instrumentlesson)
        {
            Debug.WriteLine("the json payload is :");
            //Debug.WriteLine(animal.AnimalName);
            //objective: add a new animal into our system using the API
            //curl -H "Content-Type:application/json" -d @animal.json https://localhost:44324/api/animaldata/addanimal 
            HttpClient client = new HttpClient();
            string url = "https://localhost:44300/api/InstrumentLessonData/AddInstrumentLesson";

            string jsonpayload = jss.Serialize(instrumentlesson);

            Debug.WriteLine(jsonpayload);

            HttpContent content = new StringContent(jsonpayload);
            content.Headers.ContentType.MediaType = "application/json";

            HttpResponseMessage response = client.PostAsync(url, content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("List");
            }
            else
            {
                return RedirectToAction("Error");
            }


        }
        /// <summary>
        /// Retrieves the details of a specific instrument lesson for editing based on the provided ID.
        /// </summary>
        /// <param name="id">The ID of the instrument lesson to retrieve for editing.</param>
        /// <returns>A View displaying the details of the selected instrument lesson for editing.</returns>
        /// /// GET: /InstrumentLesson/Edit/5
        /// This will communicate with the InstrumentLessonData API to retrieve the instrument lesson with ID 5,
        /// and then display its details in the view for editing.
        /// </example>

        public ActionResult Edit(int id)
        {
            // Objective: Communicate with our instructor data API to retrieve one instructor
            HttpClient client = new HttpClient();
            string url = "https://localhost:44300/api/InstrumentLessonData/FindInstrumentLesson/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;


            InstrumentLessonDto selectedInstructor = response.Content.ReadAsAsync<InstrumentLessonDto>().Result;
            Debug.WriteLine("Instructor received ");

            return View(selectedInstructor);
        }
        /// <summary>
        /// Updates the details of a specific instrument lesson by posting the provided data to the API.
        /// </summary>
        /// <param name="id">The ID of the instrument lesson to be updated.</param>
        //// <param name="instrumentLesson">The instrument lesson object containing the updated details.</param>
        /// <returns>It is redirecting to the list view if the update is successful, otherwise redirects to an error view.</returns>
        /// <example>
        /// POST: /Instructor/Edit/5
        /// This will send a JSON payload containing the updated instrument lesson details to the InstrumentLessonData API and update the instrument lesson in the system.
        /// </example>
        [HttpPost]
        public ActionResult Update(int id, InstrumentLesson instrumentLesson)
        {
            try
            {
                Debug.WriteLine("The new lesson info is:");
                Debug.WriteLine(instrumentLesson.LessonName);
                Debug.WriteLine(instrumentLesson.StartDate);
                Debug.WriteLine(instrumentLesson.EndDate);
                Debug.WriteLine(instrumentLesson.InstructorId);

                // Serialize into JSON and send the request to the API
                HttpClient client = new HttpClient();
                string url = "https://localhost:44300/api/InstrumentLessonData/UpdateInstrumentLesson/" + instrumentLesson.LessonID;

                string jsonpayload = jss.Serialize(instrumentLesson);
                Debug.WriteLine(jsonpayload);

                HttpContent content = new StringContent(jsonpayload);
                content.Headers.ContentType.MediaType = "application/json";

                HttpResponseMessage response = client.PostAsync(url, content).Result;

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("List");
                }
                else
                {
                    return RedirectToAction("Error");
                }
            }
            catch
            {
                return View();
            }

        }
        /// <summary>
        /// Retrieves the details of a specific instrument lesson for confirmation of deletion based on the provided ID.
        /// </summary>
        /// <param name="id">The ID of the instrument lesson to retrieve for deletion confirmation.</param>
        /// <returns>A View displaying the details of the selected instrument lesson for confirmation of deletion.</returns>
        /// <example>
        /// GET: /InstrumentLesson/DeleteConfirm/5
        /// This will communicate with the InstrumentLessonData API to retrieve the instrument lesson with ID 5, and then display its details in the view for deletion confirmation.
        /// </example>

        // GET: Instructor/Delete/5
        public ActionResult DeleteConfirm(int id)
        {
            HttpClient client = new HttpClient();
            string url = "https://localhost:44300/api/InstrumentLessonData/FindInstrumentLesson/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;
            InstrumentLessonDto selectedlesson = response.Content.ReadAsAsync<InstrumentLessonDto>().Result;
            return View(selectedlesson);
        }
        /// <summary>
        /// Deletes a specific instrument lesson by sending a delete request to the API.
        /// </summary>
        /// <param name="id">The ID of the instrument lesson to be deleted.</param>
        /// <returns>A redirection to the list view if the deletion is successful, otherwise redirects to an error view.</returns>
        /// <example>
        /// POST: /Animal/Delete/5
        /// This will send a delete request to the InstrumentLessonData API to remove the instrument lesson with ID 5 from the system.
        /// </example>

        [HttpPost]
        public ActionResult Delete(int id)
        {
            HttpClient client = new HttpClient();
            string url = "https://localhost:44300/api/InstrumentLessonData/DeleteInstrumentLesson/" + id;
            HttpContent content = new StringContent("");
            content.Headers.ContentType.MediaType = "application/json";
            HttpResponseMessage response = client.PostAsync(url, content).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("List");
            }
            else
            {
                return RedirectToAction("Error");
            }
        }
    }
}
