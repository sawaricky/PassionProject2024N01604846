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
        /// <returns>This will communicate with the InstrumentLessonData API and retrieve the InstrumentLesson and then display its details in the view</returns>
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
        /// To list the data from the database for the instructors
        /// </summary>
        /// <example>
        /// https://localhost:44300/api/InstrumentLessonData/ListInstructors
        /// </example>
        /// <returns>This will communicate with the InstrumentLessonData API and retrieve theinstructors and then display its details in the view</returns>
        public ActionResult ListInstructor()
        {

            //objective: communivate with out instructor data api to retrieve a list of INstructors
            //curl https://localhost:44300/api/InstrumentLessonData/ListInstructor
            HttpClient client = new HttpClient();
            string url = "https://localhost:44300/api/InstrumentLessonData/ListInstructors";
            HttpResponseMessage response = client.GetAsync(url).Result;

            Debug.WriteLine("The response code is ");
            Debug.WriteLine(response.StatusCode);

            IEnumerable<InstructorDto> instructors = response.Content.ReadAsAsync<IEnumerable<InstructorDto>>().Result;
            Debug.WriteLine("Number of instructors received ");
            Debug.WriteLine(instructors.Count());

            return View(instructors);
        }

        /// <summary>
        /// Retrieves the details of a specific instrument lesson based on the provided ID.
        /// </summary>
        /// /// <param name="id">The ID of the instrument lesson to retrieve.</param>
        /// <example>
        /// GET: /InstrumentLesson/Details/5
        /// This will communicate with the InstrumentLessonData API and retrieve the instrument lesson with ID 5, and then display its details in the view.
        /// </example>
        public ActionResult Details(int id)
        {
            // Objective: Communicate with our instructor data API to retrieve one Instrument lesson
            HttpClient client = new HttpClient();
            string url = "https://localhost:44300/api/InstrumentLessonData/FindInstrumentLesson/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;


            InstrumentLessonDto selectedInstructor = response.Content.ReadAsAsync<InstrumentLessonDto>().Result;
            Debug.WriteLine("InstrumentLesson received ");

            return View(selectedInstructor);
        }
        /// <summary>
        /// Retrieves the details of a specific instructor based on the provided ID.
        /// </summary>
        /// /// <param name="id">The ID of the instructor to retrieve.</param>
        /// <example>
        /// GET: /InstrumentLesson/InstructorDetails/5
        /// This will communicate with the InstrumentLessonData API and retrieve the instructor with ID 5, and then displays its details in the view.
        /// </example>
        public ActionResult InstructorDetails(int id)
        {
            // Objective: Communicate with our instructor data API to retrieve one instructor
            HttpClient client = new HttpClient();
            string url = "https://localhost:44300/api/InstrumentLessonData/FindInstructor/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;

            InstructorDto selectedInstructor = response.Content.ReadAsAsync<InstructorDto>().Result;
            Debug.WriteLine("Instructor received ");

            return View(selectedInstructor);
        }




        // GET: Instructor/New
        public ActionResult New()
        {
            return View();
        }
        // GET: Instructor/NewInstructor
        public ActionResult NewInstructor()
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

            //objective: add a new InstrumentLesson into our system using the API
            //curl -H "Content-Type:application/json" -d @InstrumentLesson.json https://localhost:44324/api/InstrumentLessondata/AddInstrumentLesson 
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
        /// Creates a new instructor by posting the provided data to the API.
        /// </summary>
        /// /// <param name="Instructor">The Instructor object containing the details to be created.</param>
        /// <returns>A redirection to the list view if the creation is successful, otherwise it will redirect to an error view.
        /// </returns>
        /// /// <example>
        /// POST: /Instructor/Create
        /// This will send a JSON payload containing the new Instructor details to the InstrumentLessonData API and create the Instructor in the system.
        /// </example>
        [HttpPost]
        public ActionResult CreateInstructor(Instructor instructor)
        {
            Debug.WriteLine("the json payload is :");
            //objective: add a new Instructor into our system using the API
            //curl -H "Content-Type:application/json" -d @instructor.json https://localhost:44324/api/InstrumentLessonData/AddInstructor
            HttpClient client = new HttpClient();
            string url = "https://localhost:44300/api/InstrumentLessonData/AddInstructor";

            string jsonpayload = jss.Serialize(instructor);

            Debug.WriteLine(jsonpayload);

            HttpContent content = new StringContent(jsonpayload);
            content.Headers.ContentType.MediaType = "application/json";

            HttpResponseMessage response = client.PostAsync(url, content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ListInstructor");
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
            // Objective: Communicate with our instructor data API to Edit one Instrument lesson
            HttpClient client = new HttpClient();
            string url = "https://localhost:44300/api/InstrumentLessonData/FindInstrumentLesson/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;


            InstrumentLessonDto selectedInstrumentLesson = response.Content.ReadAsAsync<InstrumentLessonDto>().Result;
            Debug.WriteLine("Instructor received ");

            return View(selectedInstrumentLesson);
        }
        /// <summary>
        /// Retrieves the details of a specific Instructor for editing based on the provided ID.
        /// </summary>
        /// <param name="id">The ID of the Instructor to retrieve for editing.</param>
        /// <returns>A View displaying the details of the selected Instructor for editing.</returns>
        /// /// GET: /InstrumentLesson/EditInstructor/5
        /// This will communicate with the InstrumentLessonData API to retrieve the Instructor with ID 5, and then display its details in the view for editing.
        /// </example>
        public ActionResult EditInstructor(int id)
        {
            // Objective: Communicate with our instructor data API to edit one instructor
            HttpClient client = new HttpClient();
            string url = "https://localhost:44300/api/InstrumentLessonData/FindInstructor/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;


            InstructorDto selectedInstructor = response.Content.ReadAsAsync<InstructorDto>().Result;
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
        /// POST: /Instructor/Update/5
        /// This will send a JSON payload containing the updated instrument lesson details to the InstrumentLessonData API and update the instrument lesson in the system.
        /// </example>
        [HttpPost]
        public ActionResult Update(InstrumentLesson instrumentLesson)
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
        /// Updates the details of a specific instructor by posting the provided data to the API.
        /// </summary>
        /// <param name="id">The ID of the instructor to be updated.</param>
        //// <param name="instructor">The instructorobject containing the updated details.</param>
        /// <returns>It is redirecting to the list view if the update is successful, otherwise redirects to an error view.</returns>
        /// <example>
        /// POST: /Instructor/UpdateInstructor/5
        /// This will send a JSON payload containing the updated Instructor details to the InstrumentLessonData API and update the Instructor in the system.
        /// </example>
        [HttpPost]
        public ActionResult UpdateInstructor(int id, Instructor instructor)
        {
            try
            {

                Debug.WriteLine("The new lesson info is:");
                Debug.WriteLine(instructor.FirstName);
                Debug.WriteLine(instructor.LastName);
                Debug.WriteLine(instructor.InstructorNumber);
                Debug.WriteLine(instructor.HireDate);
                Debug.WriteLine(instructor.Wages);
                Debug.WriteLine(instructor.InstructorId);

                HttpClient client = new HttpClient();
                string url = "https://localhost:44300/api/InstrumentLessonData/UpdateInstructor/" + id;

                string jsonpayload = jss.Serialize(instructor);
                HttpContent content = new StringContent(jsonpayload);
                content.Headers.ContentType.MediaType = "application/json";

                HttpResponseMessage response = client.PostAsync(url, content).Result;

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("ListInstructor");
                }
                else
                {
                    return RedirectToAction("Error");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex.Message);
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
        /// Retrieves the details of a specific Instructor for confirmation of deletion based on the provided ID.
        /// </summary>
        /// <param name="id">The ID of the Instructor to retrieve for deletion confirmation.</param>
        /// <returns>A View displaying the details of the selected Instructor for confirmation of deletion.</returns>
        /// <example>
        /// GET: /InstrumentLesson/DeleteConfirmInstructor/5
        /// This will communicate with the InstrumentLessonData API to retrieve the Instructor with ID 5, and then display its details in the view for deletion confirmation.
        /// </example>
        public ActionResult DeleteConfirmInstructor(int id)
        {
            HttpClient client = new HttpClient();
            string url = "https://localhost:44300/api/InstrumentLessonData/FindInstructor/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;
            InstructorDto selectedinstructor = response.Content.ReadAsAsync<InstructorDto>().Result;
            return View(selectedinstructor);
        }
        //both summary blocks of instrument and instructor below
        /// <summary>
        /// Deletes a specific instrument lesson by sending a delete request to the API.
        /// </summary>
        /// /// <summary>
        /// Deletes a specific Instructor by sending a delete request to the API.
        /// </summary>
        /// <param name="id">The ID of the instrument lesson to be deleted.</param>
        /// /// <param name="id">The ID of the Instructor to be deleted.</param>
        /// <returns>A redirection to the list view if the deletion is successful, otherwise redirects to an error view.</returns>
        /// <example>
        /// POST: /InstrumentLessonData/Delete/5
        /// POST: /InstrumentLessonData/DeleteInstructor/5
        /// This will send a delete request to the InstrumentLessonData API to remove the instrument lesson with ID 5 from the system.
        /// This will send a delete request to the InstrumentLessonData API to remove the Instructor with ID 5 from the system.
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
        [HttpPost]
        public ActionResult DeleteInstructor(int id)
        {
            HttpClient client = new HttpClient();
            string url = "https://localhost:44300/api/InstrumentLessonData/DeleteInstructor/" + id;
            HttpContent content = new StringContent("");
            content.Headers.ContentType.MediaType = "application/json";
            HttpResponseMessage response = client.PostAsync(url, content).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ListInstructor");
            }
            else
            {
                return RedirectToAction("Error");
            }
        }
    }
}
