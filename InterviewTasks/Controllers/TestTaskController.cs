using System;
using System.ComponentModel.DataAnnotations;
using InterviewTasks.Contracts.TestTaskDTO;
using InterviewTasks.Core.Abstractions;
using InterviewTasks.Core.Enums;
using InterviewTasks.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace InterviewTasks.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestTaskController : ControllerBase
    {
        private readonly IService<TestTask> _service;
        private readonly ITestTaskFactory _testTaskFactory;
        public TestTaskController(IService<TestTask> service, ITestTaskFactory testTaskFactory)
        {
            _service = service;
            _testTaskFactory = testTaskFactory;
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
        public async Task<ActionResult<TestTask>> CreateTask(TestTaskRequest testTask)
        {
           //с тегами должно быть что то вроде
           /*
            получаем реквест со списком названий
           после обращаемся куда нибудь и получаем все теги по названиям
           после уже передаем в фактори тасок все данные
            */

            var task = _testTaskFactory.Create(
                new Guid(),
                testTask.Title,
                testTask.Description,
                testTask.DateAdded,
                testTask.FilePath,
                testTask.DifficultyLevels,
                testTask.CategoryId,
                null, // ссылкка на категорию не нужна в данном случае
                null);// тут предварительно нужно будет как то получить все айди всех связанных тегов
            return Ok(await _service.Create(task));
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

