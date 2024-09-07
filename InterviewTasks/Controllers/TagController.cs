using System;
using InterviewTasks.Core.Abstractions;
using InterviewTasks.Core.Models;
using Microsoft.AspNetCore.Mvc;


namespace InterviewTasks.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TagController : ControllerBase
	{
		private readonly IService<Tag> _service;
		public TagController(IService<Tag> service)
		{
			_service = service;
		}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tag>>> GetTestTasks()
        {
            var tags = await _service.GetList();
            return Ok(tags);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tag>> GetTask(Guid id)
        {
            var tag = await _service.GetById(id);
            return Ok(tag);
        }

        [HttpPost]
        public async Task<ActionResult<Tag>> CreateTask(Tag tag)
        {
            var newTag = await _service.Create(tag);
            return Ok(newTag);
        }

        [HttpPut]
        public async Task<ActionResult<Tag>> UpdateTask(Tag tag)
        {
            var updateTag = await _service.Update(tag);
            return Ok(updateTag);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTask(Guid id)
        {
            await _service.Delete(id);
            return Ok();
        }

    }
}

