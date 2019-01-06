using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC_Eksamen.Models;

namespace MVC_Eksamen.Controllers
{
    public class TestController : Controller
    {
        public HttpClient client;
        // GET: Test
        public TestController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44325/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<IActionResult> Index()
        {

            HttpResponseMessage responseTask = await client.GetAsync("values/GetallValues");
            //responseTask.Wait();

            // var result = responseTask.Result;
            if (responseTask.IsSuccessStatusCode)
            {
                var readTask = responseTask.Content.ReadAsAsync<IEnumerable<TestObject>>();
                readTask.Wait();



                return View(readTask.Result);
            }


            return Content("Noget gik galt");
        }
        [Authorize]
        // GET: Test/Details/5
        public async Task<IActionResult> Details(int id)
        {

            TestObject value = new TestObject();
            HttpResponseMessage responseTask = await client.GetAsync($"values/GetById/{id}");
            //responseTask.Wait();

            // var result = responseTask.Result;
            if (responseTask.IsSuccessStatusCode)
            {
                var readTask = responseTask.Content.ReadAsAsync<TestObject>();
                readTask.Wait();

                value = readTask.Result;
                return View(value);
            }
            else if ((int)responseTask.StatusCode == 404)
            {
                return Content("Den findes ikke");
            }
            else
            {
                return View("Index");
            }

        }

        // GET: Test/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Test/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TestObject testObject)
        {
            var postTask = await client.PostAsJsonAsync("values/Create", testObject);



            if (postTask.IsSuccessStatusCode)


            {
                var readTask = postTask.Content.ReadAsAsync<TestObject>();
                readTask.Wait();

                var content = readTask.Result;
                return RedirectToAction("Details", content.Id);
            }

            else if ((int)postTask.StatusCode == 400)
            {
                return View(testObject);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Test/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            TestObject value = new TestObject();
            HttpResponseMessage responseTask = await client.GetAsync($"values/GetById/{id}");
            //responseTask.Wait();

            // var result = responseTask.Result;
            if (responseTask.IsSuccessStatusCode)
            {
                var readTask = responseTask.Content.ReadAsAsync<TestObject>();
                readTask.Wait();

                value = readTask.Result;
                return View(value);
            }
            else if ((int)responseTask.StatusCode == 404)
            {
                return Content("Den findes ikke");
            }
            else
            {
                return View("Index");
            }
        }

        // POST: Test/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditCompleteAsync(TestObject testObject)
        {

            var postTask = await client.PutAsJsonAsync($"values/Update/{testObject.Id}", testObject);



            if (postTask.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return Content("Noget gik galt");
            }
        }

        // GET: Test/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var postTask = await client.DeleteAsync($"values/Delete/{id}");
            if (postTask.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else if ((int)postTask.StatusCode == 404)
            {
                return Content("Den findes ikke");
            }

            return Content("Noget gik galt");


        }
    }
}