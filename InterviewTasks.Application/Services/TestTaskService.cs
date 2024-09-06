using System;
using InterviewTasks.Core.Abstractions;
using InterviewTasks.Core.Enums;
using InterviewTasks.Core.Models;
using InterviewTasks.DataAccess.Entities;

namespace InterviewTasks.Application.Services
{
	public class TestTaskService : IService<TestTask>
	{
        private readonly ICrudRepository<TestTaskEntity> _repository;
        private readonly ITestTaskFactory _factory;
        private readonly ICategoryFactory _categoryFactory;

        public TestTaskService(ICrudRepository<TestTaskEntity> repository, ITestTaskFactory factory, ICategoryFactory categoryFactory)
        {
            _repository = repository;
            _factory = factory;
            _categoryFactory = categoryFactory;
        }

        public async Task<ICollection<TestTask>> GetList()
        {
            var tasksEntities = await _repository.GetListAsync();
            var testTasks = tasksEntities.Select(t =>
            {
                var task = _factory.Create(
                    t.Id,
                    t.Title,
                    t.Description,
                    t.DateAdded,
                    t.FilePath,
                    t.DifficultyLevels,
                    t.CategoryId,
                    null, // категория
                    null // список тегов
                    );
                return task;
            }).ToList();
            return testTasks;
        }

        public async Task<TestTask> GetById(Guid id)
        {
            var taskEntity = await _repository.GetByIdAsync(id);
            var testTask = _factory.Create(
                    taskEntity.Id,
                    taskEntity.Title,
                    taskEntity.Description,
                    taskEntity.DateAdded,
                    taskEntity.FilePath,
                    taskEntity.DifficultyLevels,
                    taskEntity.CategoryId,
                    null, // категория
                    null // список тегов
                    );
            return testTask;
        }
        public async Task<TestTask> Create(TestTask testTask)
        {
            var testTaskEntity = new TestTaskEntity
            {
                Id = testTask.Id,
                Title = testTask.Title,
                Description = testTask.Description,
                DateAdded = testTask.DateAdded,
                FilePath = testTask.FilePath,
                DifficultyLevels = testTask.DifficultyLevels,
                CategoryId = testTask.CategoryId,
                Category = null, // категория
                Tags = null // список тегов
            };
                  
              
            await _repository.PostAsync(testTaskEntity);
            return testTask;
        }

        public async Task<TestTask> Update(TestTask testTask)
        {
            var testTaskEntity = new TestTaskEntity
            {
                Id = testTask.Id,
                Title = testTask.Title,
                Description = testTask.Description,
                DateAdded = testTask.DateAdded,
                FilePath = testTask.FilePath,
                DifficultyLevels = testTask.DifficultyLevels,
                CategoryId = testTask.CategoryId,
                Category = null, // категория
                Tags = null // список тегов
            };


            await _repository.PutAsync(testTaskEntity);
            return testTask;
        }

        public async Task Delete(Guid id)
        {
            await _repository.DeleteAsync(id);
        }

    }
}

