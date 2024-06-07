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
        public ActionResult List()
        {
            //objective: communivate with out instructor data api to retrieve a list of instrumetn lessons 
            //curl https://localhost:44300/api/InstrumentLessonData/ListInstrumentLesso
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

        // GET: Instructor/Details/5
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

        // GET: Instructor/Edit/5
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

        // POST: Instructor/Edit/5
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

        // GET: Instructor/Delete/5
        public ActionResult DeleteConfirm(int id)
        {
            HttpClient client = new HttpClient();
            string url = "https://localhost:44300/api/InstrumentLessonData/FindInstrumentLesson/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;
            InstrumentLessonDto selectedlesson = response.Content.ReadAsAsync<InstrumentLessonDto>().Result;
            return View(selectedlesson);
        }

        // POST: Animal/Delete/5
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
