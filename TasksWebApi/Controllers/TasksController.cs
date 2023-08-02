using Microsoft.AspNetCore.Mvc;
using TasksWebApi.Models;
using TasksWebApi.Services;

namespace TasksWebApi.Controllers
{
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {

        ITasksService tasksService;
        public TasksController(ITasksService tasksService) => this.tasksService = tasksService;

        [HttpGet]
        public IActionResult Get() => Ok(tasksService.Get());

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Tasks tasks)
        {
            await tasksService.Save(tasks);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] Tasks tasks)
        {
            await tasksService.Update(id, tasks);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Post(Guid id)
        {
            await tasksService.Remove(id);
            return Ok();
        }
    }
}
