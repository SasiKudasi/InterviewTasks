using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using InterviewTasks.Contracts.TagDTO;
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
        /*TODO
         * Подумать на счет какой никакой валидации
         * Добавить фильтры по дате и тегам
         * Вообще стоит продумать какую то архитектуру (Сейчас все идет по наитию)
         * В зависимости от архитектуры посмотреть на счет того что бы натянуть сюда фронт 
         * или фронт будет натянут на какой то кор или где оно вообще будет???
         * Покрыть сервис тестами :(
         * Упаковать в контейнер
         * Посмотреть как вообще настроить CI/CD
         * Что то на счет деплоя
         */
        private readonly IService<TestTask> _service;
        private readonly ITestTaskFactory _testTaskFactory;
        private readonly ITagFactory _tagFactory;
        public TestTaskController(IService<TestTask> service, ITestTaskFactory testTaskFactory, ITagFactory tagFactory)
        {
            _service = service;
            _testTaskFactory = testTaskFactory;
            _tagFactory = tagFactory;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TestTaskResponce>>> GetTestTasks()
        {
            var tasks = await _service.GetList();

            var testTasks = tasks.Select(t =>
            {
                var tags = t.Tags.Select(tag =>
                {
                    var tagResponce = new TagRequest(
                        tag.Id,
                        tag.Name,
                        tag.TestTaskId);
                    return tagResponce;
                }).ToList();
                var testTask = new TestTaskResponce(
                    (Guid)t.Id,
                    t.Title,
                    t.Description,
                    t.DateAdded,
                    t.FilePath,
                    t.DifficultyLevels,
                    t.CategoryId,
                    tags);
                return testTask;
            }).ToList();
            return Ok(testTasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TestTaskResponce>> GetTask(Guid id)
        {
            var testTask = await _service.GetById(id);

            var tags = testTask.Tags.Select(t =>
            {
                var tag = new TagRequest(t.Id, t.Name, t.TestTaskId);
                return tag;
            }).ToList();
            var taskResponce = new TestTaskResponce(
                (Guid)testTask.Id,
                testTask.Title,
                testTask.Description,
                testTask.DateAdded,
                testTask.FilePath,
                testTask.DifficultyLevels,
                testTask.CategoryId,
                tags);
            return Ok(taskResponce);
        }

        [HttpPost]
        public async Task<ActionResult<TestTask>> CreateTask(TestTaskRequest testTask)
        {
            var tagsRquest = testTask.Tags;
            var tags = tagsRquest.Select(t =>
            {
                var tag = _tagFactory.Create(
                    t.Id,
                    t.Name,
                    t.TestTaskId,
                    null);
                return tag;
            }).ToList();

            var task = _testTaskFactory.Create(
                new Guid(),
                testTask.Title,
                testTask.Description,
                testTask.DateAdded,
                testTask.FilePath,
                testTask.DifficultyLevels,
                testTask.CategoryId,
                null, // ссылкка на категорию не нужна в данном случае 
                tags);// тут предварительно нужно будет как то получить все айди всех связанных тегов
            return Ok(await _service.Create(task));
        }

        [HttpPut]
        public async Task<ActionResult<TestTask>> UpdateTask(TestTaskRequest testTask)
        {

            var tagsRquest = testTask.Tags;
            var tags = tagsRquest.Select(t =>
            {
                var tag = _tagFactory.Create(
                    t.Id,
                    t.Name,
                    t.TestTaskId,
                    null);
                return tag;
            }).ToList();

            var task = _testTaskFactory.Create(
                testTask.Id,
                testTask.Title,
                testTask.Description,
                testTask.DateAdded,
                testTask.FilePath,
                testTask.DifficultyLevels,
                testTask.CategoryId,
                null,
                tags);
            return Ok(await _service.Update(task));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTask(Guid id)
        {
            await _service.Delete(id);
            return Ok();
        }




    }
}

