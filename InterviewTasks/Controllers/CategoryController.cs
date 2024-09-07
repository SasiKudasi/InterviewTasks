using System;
using InterviewTasks.Core.Abstractions;
using InterviewTasks.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace InterviewTasks.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
	{
        private readonly IService<Category> _service;
        public CategoryController(IService<Category> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetTestTasks()
        {
            var categories = await _service.GetList();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetTask(Guid id)
        {
            var category = await _service.GetById(id);
            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult<Category>> CreateTask(Category category)
        {
            var newCategory = await _service.Create(category);
            return Ok(newCategory);
        }

        [HttpPut]
        public async Task<ActionResult<Category>> UpdateTask(Category category)
        {
            var updatedCategory = await _service.Update(category);
            return Ok(updatedCategory);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTask(Guid id)
        {
            await _service.Delete(id);
            return Ok();
        }
    }
}

