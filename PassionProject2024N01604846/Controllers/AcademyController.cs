using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using PassionProject2024N01604846.Models;

namespace PassionProject2024N01604846.Controllers
{
    public class AcademyController : Controller
    {
        // GET: Academy/List
        /// <summary>
        /// To list the data from the database for the academies
        /// </summary>
        /// <example>
        /// https://localhost:44300/api/AcademyData/ListAcademy
        /// </example>
        /// <returns>This will communicate with the AcademyData API and retrieve the academy data, then display its details in the view</returns>
        public ActionResult List()
        {

            HttpClient client = new HttpClient() { };
            string url = "https://localhost:44300/api/AcademyData/ListAcademy";
            HttpResponseMessage response = client.GetAsync(url).Result;

            Debug.WriteLine("The response code is");
            Debug.WriteLine(response.StatusCode);

            //IEnumerable<Academy> academys = response.Content.ReadAsAsync<IEnumerable<Academy>>().Result;
            //Debug.WriteLine("Number of academies recieved ");
            //Debug.WriteLine(academys.Count());
            return View();
        }

        /// <summary>
        /// To retrieve the details of a specific academy by its ID
        /// </summary>
        /// <param name="id">The ID of the academy</param>
        /// <example>
        /// https://localhost:44300/api/AcademyData/FindAcademy/5
        /// </example>
        /// <returns>This will communicate with the AcademyData API and retrieve the details of the specified academy, then display its details in the view</returns>
        public ActionResult Details(int id)
        {
            return View();
        }



        // GET: Academy/Create
        /// <summary>
        /// To display a form for adding a new academy
        /// </summary>
        /// <example>
        /// https://localhost:44300/api/AcademyData/AddAcademy
        /// </example>
        /// <returns>This will display a form to the user to input details for a new academy, then submit the data to add the academy</returns>
        public ActionResult Create()
        {
            return View();
        }

        // POST: Academy/AddAcademy
        // POST: Academy/Create
        /// <summary>
        /// To add a new academy to the database
        /// </summary>
        /// <param name="collection">The form collection containing the data for the new academy</param>
        /// <example>
        /// https://localhost:44300/api/AcademyData/AddAcademy
        /// </example>
        /// <returns>If successful, this will redirect to the index view. If an error occurs, it will return to the create view.</returns>
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            { 

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Academy/Edit/5
        /// <summary>
        /// To display a form for editing an existing academy
        /// </summary>
        /// <param name="id">The ID of the academy to edit</param>
        /// <example>
        /// https://localhost:44300/api/AcademyData/EditAcademy/5
        /// </example>
        /// <returns>This will display a form to the user to edit the details of the specified academy</returns>
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Academy/Edit/5
        /// <summary>
        /// To update the details of an existing academy in the database
        /// </summary>
        /// <param name="id">The ID of the academy to update</param>
        /// <param name="collection">The form collection containing the updated data for the academy</param>
        /// <example>
        /// https://localhost:44300/api/AcademyData/UpdateAcademy/5
        /// </example>
        /// <returns>If successful, this will redirect to the index view. If an error occurs, it will return to the edit view.</returns>
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // GET: Academy/Delete/5
        /// <summary>
        /// To display a confirmation view for deleting an academy
        /// </summary>
        /// <param name="id">The ID of the academy to delete</param>
        /// <example>
        /// https://localhost:44300/api/AcademyData/DeleteAcademy/5
        /// </example>
        /// <returns>This will display a confirmation view to the user for deleting the specified academy</returns>
        public ActionResult Delete(int id)
        {
            return View();
        }
        // POST: Academy/Delete/5
        /// <summary>
        /// To delete an existing academy from the database
        /// </summary>
        /// <param name="id">The ID of the academy to delete</param>
        /// <param name="collection">The form collection </param>
        /// <example>
        /// https://localhost:44300/api/AcademyData/DeleteAcademy/5
        /// </example>
        /// <returns>If successful, this will redirect to the index view. If an error occurs, it will return to the delete confirmation view.</returns>
        // POST: Academy/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
               

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
