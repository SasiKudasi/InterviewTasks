using System;
using InterviewTasks.Core.Abstractions;
using InterviewTasks.Core.Enums;
using InterviewTasks.Core.Factories;
using InterviewTasks.Core.Models;
using InterviewTasks.DataAccess.Entities;

namespace InterviewTasks.Application.Services
{
	public class TestTaskService : IService<TestTask>
	{
        private readonly ICrudRepository<TestTaskEntity> _repository;
        private readonly ITestTaskFactory _factory;
        private readonly ICategoryFactory _categoryFactory;
        private readonly ITagFactory _tagFactory;


        public TestTaskService(ICrudRepository<TestTaskEntity> repository, ITestTaskFactory factory,
            ICategoryFactory categoryFactory, ITagFactory tagFactory)
        {
            _repository = repository;
            _factory = factory;
            _categoryFactory = categoryFactory;
            _tagFactory = tagFactory;

        }

        public async Task<ICollection<TestTask>> GetList()
        {
            var tasksEntities = await _repository.GetListAsync("Category.TestTasks.Tags");
            var testTasks = tasksEntities.Select(t =>
            {
                var categoryEntity = t.Category;
                var newCategory = _categoryFactory.Create(categoryEntity.Id, categoryEntity.Name, new List<TestTask>());
                var tegEntities = t.Tags;
                var newTask = _factory.Create(
                    t.Id,
                    t.Title,
                    t.Description,
                    t.DateAdded,
                    t.FilePath,
                    t.DifficultyLevels,
                    t.CategoryId,
                    newCategory,
                    new List<Tag>()
                    );
                var tags = tegEntities.Select(tag => _tagFactory.Create(
                    tag.Id,
                    tag.Name,
                    tag.TestTaskId,
                    newTask
                    )).ToList();

                var task = _factory.Create(t.Id,
                   t.Title,
                   t.Description,
                   t.DateAdded,
                   t.FilePath,
                   t.DifficultyLevels,
                   t.CategoryId,
                   newCategory,
                   tags);

                newCategory.TestTasks.Add(task);
                return task;
            }).ToList();
            return testTasks;
        }

        public async Task<TestTask> GetById(Guid id)
        {
            var taskEntity = await _repository.GetByIdAsync(id, "Category.TestTasks.Tags");
            var categoryEntity = taskEntity.Category;
            var category = _categoryFactory.Create(
                categoryEntity.Id,
                categoryEntity.Name,
                new List<TestTask>());

            var tags = taskEntity.Tags?.Select(tag => _tagFactory.Create(
                tag.Id,
                tag.Name,
                tag.TestTaskId,
                null))
                .ToList() ?? new List<Tag>();

            var task = _factory.Create(
                taskEntity.Id,
                taskEntity.Title,
                taskEntity.Description,
                taskEntity.DateAdded,
                taskEntity.FilePath,
                taskEntity.DifficultyLevels,
                taskEntity.CategoryId,
                category,
                tags);

            foreach (var tag in tags)
            {
                tag.TestTask = task;
            }
            return task;
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
                Tags = testTask.Tags.Select(tag => new TagEntity
                {
                    Id = tag.Id,
                    Name = tag.Name,
                    TestTaskId = testTask.Id
                }).ToList()
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
                Tags = testTask.Tags.Select(tag => new TagEntity
                {
                    Id = tag.Id,
                    Name = tag.Name,
                    TestTaskId = testTask.Id
                }).ToList()
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

