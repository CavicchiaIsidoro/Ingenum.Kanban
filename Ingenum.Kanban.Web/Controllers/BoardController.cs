using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Ingenum.Kanban.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Ingenum.Kanban.Web.Controllers
{
    public class BoardController : Controller
    {
        // GET: Board
        public async Task<IActionResult> Index()
        {
            List<BoardViewModel> list = new List<BoardViewModel>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44349/api/board"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    list = JsonConvert.DeserializeObject<List<BoardViewModel>>(apiResponse);
                }

            }
            return View(list);
        }

        // GET: Board/Details/5
        public IActionResult Details(int id)
        {
            var model = GetBoard(id).Result;
            return View(model);
        }

        // GET: Board/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Board/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm]BoardViewModel collection)
        {
            try
            {
                // TODO: Add insert logic here
                using (var httpClient = new HttpClient())
                {
                    var json = new StringContent(JsonConvert.SerializeObject(collection), Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync("https://localhost:44349/api/Board", json);

                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Board/Edit/5
        public ActionResult Edit(int id)
        {
            var board = GetBoard(id).Result;
            return View(board);
        }

        // POST: Board/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([FromForm] BoardViewModel board)
        {
            try
            {
                // TODO: Add update logic here
                using (var httpClient = new HttpClient())
                {
                    var json = new StringContent(JsonConvert.SerializeObject(board), Encoding.UTF8, "application/json");
                    var response = await httpClient.PutAsync("https://localhost:44349/api/Board/" + board.BoardId, json);

                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Board/Delete/5
        public ActionResult Delete(int id)
        {
            var board = GetBoard(id).Result;
            return View(board);
        }

        // POST: Board/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (var httpClient = new HttpClient())
                {
                    var response = httpClient.DeleteAsync("https://localhost:44349/api/Board/" + id);
                }

                return RedirectToAction("Index", "Board");
            }
            catch
            {
                return View();
            }
        }

        public async Task<BoardViewModel> GetBoard(int id)
        {
            BoardViewModel model = new BoardViewModel();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44349/api/board/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    model = JsonConvert.DeserializeObject<BoardViewModel>(apiResponse);
                }

            }
            return model;
        }
    }
}