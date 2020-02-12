using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Ingenum.Kaban.Business.Models;
using Ingenum.Kaban.Business.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ingenum.Kanban.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class BoardController : ControllerBase
    {
        private readonly BoardRepository repoBoard;
        private readonly TaskReposiroty repoTask;
        public BoardController(BoardRepository repo, TaskReposiroty taskRepo)
        {
            this.repoBoard = repo;
            this.repoTask = taskRepo;
        }
        // GET: api/Board
        [HttpGet]
        public IEnumerable<BoardBusiness> Get()
        {
            var list = this.repoBoard.GetAll();
            return list;
        }

        // GET: api/Board/5
        [HttpGet("{id}", Name = "BoardGet")]
        public IActionResult Get(int id)
        {
            var board = this.repoBoard.Get(id);
            return Ok(board);
        }

        // POST: api/Board
        [HttpPost]
        public void Post([FromBody]BoardBusiness value)
        {
            value.Tasks = new List<TaskBusiness>();
            this.repoBoard.Add(value);
        }

        // PUT: api/Board/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] BoardBusiness value)
        {
            this.repoBoard.Update(value);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            
        }
    }
}
