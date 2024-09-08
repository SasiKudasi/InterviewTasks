using System;
using InterviewTasks.Contracts.TagDTO;
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
        private readonly ITagFactory _factory;
		public TagController(IService<Tag> service, ITagFactory factory)
		{
			_service = service;
            _factory = factory;
		}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tag>>> GetTestTasks()
        {
            var tags = await _service.GetList();
            return Ok(tags);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tag>> GetTag(Guid id)
        {
            var tag = await _service.GetById(id);
            return Ok(tag);
        }

        [HttpPost]
        public async Task<ActionResult<Tag>> CreateTag(TagRequest tagRequest)
        {
            var tag = _factory.Create(
                tagRequest.Id,
                tagRequest.Name,
                tagRequest.TestTaskId,
                null
                );
            var newTag = await _service.Create(tag);
            return Ok(newTag);
        }

        [HttpPut]
        public async Task<ActionResult<Tag>> UpdateTag(Tag tag)
        {
            var updateTag = await _service.Update(tag);
            return Ok(updateTag);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTag(Guid id)
        {
            await _service.Delete(id);
            return Ok();
        }

    }
}

