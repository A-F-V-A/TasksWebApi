using Microsoft.AspNetCore.Mvc;
using TasksWebApi.Models;
using TasksWebApi.Services;

namespace TasksWebApi.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {

        ICategoryService categoryService;
        public CategoryController(ICategoryService categoryService) => this.categoryService = categoryService;

        [HttpGet]
        public IActionResult Get() => Ok(categoryService.Get());

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Category category)
        {
            await categoryService.Save(category);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] Category category)
        {
            await categoryService.Update(id, category);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Post(Guid id)
        {
            await categoryService.Remove(id);
            return Ok();
        }
    }
}
