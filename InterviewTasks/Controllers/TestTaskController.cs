using System;
using InterviewTasks.Core.Abstractions;
using InterviewTasks.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace InterviewTasks.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestTaskController : ControllerBase
    {
        private readonly IService<TestTask> _service;
        public TestTaskController(IService<TestTask> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TestTask>>> GetTestTasks()
        {
            var testTasks = await _service.GetList();
            return Ok(testTasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TestTask>> GetTask(Guid id)
        {
            var testTask = await _service.GetById(id);
            return Ok(testTask);
        }

        [HttpPost]
        public async Task<ActionResult<TestTask>> CreateTask(TestTask testTask)
        {
            var task = await _service.Create(testTask);
            return Ok(task);
        }

        [HttpPut]
        public async Task<ActionResult<TestTask>> UpdateTask(TestTask testTask)
        {
            var task = await _service.Update(testTask);
            return Ok(task);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTask(Guid id)
        {
            await _service.Delete(id);
            return Ok();
        }




    }
}

