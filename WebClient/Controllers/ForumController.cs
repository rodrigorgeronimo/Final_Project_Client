using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebClient.Models;
using WebClient.Models.Enum;

namespace WebClient.Controllers
{
    public class ForumController : Controller
    {
        // GET: Thread
        public ActionResult Index()
        {
            IEnumerable<Thread> threads = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Constants.BaseAPIAddress);
                //HTTP GET
                var responseTask = client.GetAsync("threads");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Thread>>();
                    readTask.Wait();

                    threads = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    threads = Enumerable.Empty<Thread>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(threads);
        }

        // GET: Thread/Details/5
        public ActionResult Details(int id)
        {
            return View();

        }

        // GET: Thread/Create
        public ActionResult Create([Bind("ThreadId,UserId,Subject,PostedOn")] Thread thread)
        {
            thread.ThreadId = Guid.NewGuid();

            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Constants.BaseAPIAddress);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<Thread>("threads", thread);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }

                ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
            }
            return View(thread);
        }

        // POST: Thread/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Thread/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Thread/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Thread/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Thread/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}