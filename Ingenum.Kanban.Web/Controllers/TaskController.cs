using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Ingenum.Kanban.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;

namespace Ingenum.Kanban.Web.Controllers
{
    public class TaskController : Controller
    {
        private readonly string pathApi = "https://localhost:44349/api/Task/";
        // GET: Task
        public ActionResult Index()
        {
            return View();
        }

        // GET: Task/Details/5
        public ActionResult Details(int taskId)
        {
            return View();
        }

        // GET: Task/Create
        public async Task<IActionResult> Create(int boardID)
        {

            BoardViewModel board = new BoardViewModel();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44349/api/board/" + boardID))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    board = JsonConvert.DeserializeObject<BoardViewModel>(apiResponse);
                }

            }
            TaskViewModel model = new TaskViewModel
            {
                Board = board,
                Section = SectionEnum.TODO
            };
            ViewBag.Board = board;
            return View(model);
        }

        // POST: Task/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] TaskViewModel collection)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                // TODO: Add insert logic here
                BoardViewModel board = new BoardViewModel();
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync("https://localhost:44349/api/board/" + collection.BoardId))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        board = JsonConvert.DeserializeObject<BoardViewModel>(apiResponse);
                    }

                }

                collection.Board = board;

                using (var httpClient = new HttpClient())
                {
                    var json = new StringContent(JsonConvert.SerializeObject(collection), Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync(pathApi, json);

                }

                return RedirectToAction("Details", new RouteValueDictionary(
                    new { controller = "Board", action = "Details", id = board.BoardId}));
            }
            catch
            {
                return View();
            }
        }

        // GET: Task/Edit/5
        public async Task<ActionResult> Edit(int taskId)
        {
            TaskViewModel task = new TaskViewModel();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(pathApi + taskId))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    task = JsonConvert.DeserializeObject<TaskViewModel>(apiResponse);
                }

            }

            ViewBag.SectionItems = SectionDispo(task.Section);
            return View(task);
        }

        // POST: Task/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([FromForm] TaskViewModel task)
        {
            try
            {
                // TODO: Add update logic here
                using (var httpClient = new HttpClient())
                {
                    var json = new StringContent(JsonConvert.SerializeObject(task), Encoding.UTF8, "application/json");
                    await httpClient.PutAsync(pathApi + task.TaskId, json);

                }
                return RedirectToAction("Index", "Board");
            }
            catch
            {
                return View();
            }
        }

        // GET: Task/Delete/5
        public ActionResult Delete(int id)
        {
            var task = GetTask(id).Result;
            return View(task);
        }

        // POST: Task/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var task = GetTask(id).Result;
                using (var httpClient = new HttpClient())
                {
                    await httpClient.DeleteAsync(pathApi + id);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public List<SectionEnum> SectionDispo(SectionEnum section)
        {
            List<SectionEnum> list = new List<SectionEnum>();
            switch (section)
            {
                case SectionEnum.TODO:
                    list = new List<SectionEnum> { SectionEnum.DOING, SectionEnum.TODO };
                    break;
                case SectionEnum.DOING:
                    list = new List<SectionEnum> { SectionEnum.DONE, SectionEnum.DOING };
                    break;
                case SectionEnum.DONE:
                    break;
                default:
                    list = new List<SectionEnum> { SectionEnum.DONE, SectionEnum.DOING };
                    break;
            }
            return list;
        }

        public async Task<TaskViewModel> GetTask(int id)
        {
            TaskViewModel task = new TaskViewModel();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(pathApi + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    task = JsonConvert.DeserializeObject<TaskViewModel>(apiResponse);
                }

            }

            return task;
        }
    }
}