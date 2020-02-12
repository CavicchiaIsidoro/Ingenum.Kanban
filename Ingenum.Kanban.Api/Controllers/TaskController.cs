using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ingenum.Kaban.Business.Models;
using Ingenum.Kaban.Business.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ingenum.Kanban.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly TaskReposiroty taskReposiroty;

        public TaskController(TaskReposiroty _taskRepo)
        {
            this.taskReposiroty = _taskRepo;
        }

        // GET: api/Task
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}", Name = "TaskGet")]
        public TaskBusiness Get(int id)
        {
            return this.taskReposiroty.Get(id);
        }

        // GET: api/Task/5
        [HttpGet("BoardID={id}", Name = "TaskBoardGet")]
        public IEnumerable<TaskBusiness> GetAll(int id)
        {
            return this.taskReposiroty.GetAllByBoard(id);
        }

        // POST: api/Task
        [HttpPost]
        public void Post([FromBody] TaskBusiness value)
        {
            this.taskReposiroty.Add(value);
        }

        // PUT: api/Task/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] TaskBusiness value)
        {
            this.taskReposiroty.Update(value);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var task = this.taskReposiroty.Get(id);
            this.taskReposiroty.Delete(task);
        }
    }
}
