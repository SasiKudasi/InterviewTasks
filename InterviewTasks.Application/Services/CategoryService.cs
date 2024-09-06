using System;
using InterviewTasks.Core.Abstractions;
using InterviewTasks.Core.Enums;
using InterviewTasks.Core.Factories;
using InterviewTasks.Core.Models;
using InterviewTasks.DataAccess.Entities;

namespace InterviewTasks.Application.Services
{
	public class CategoryService : IService<Category>
	{
        private readonly ICrudRepository<CategoryEntity> _repository;
        private readonly ICategoryFactory _factory;
        private readonly ITestTaskFactory _testTaskFactory;

        public CategoryService(ICrudRepository<CategoryEntity> repository, ICategoryFactory factory, ITestTaskFactory testTaskFactory)
        {
            _repository = repository;
            _factory = factory;
            _testTaskFactory = testTaskFactory;
        }

        public async Task<ICollection<Category>> GetList()
        {
            var categoryEntities = await _repository.GetListAsync();

            var categories = categoryEntities.Select(c =>
            {
                // Преобразование TestTaskEntity в TestTask
                var testTasks = c.TestTasks.Select(t => _testTaskFactory.Create(
                    t.Id,
                    t.Title,
                    t.Description,
                    t.DateAdded,
                    t.FilePath,
                    t.DifficultyLevels,
                    t.CategoryId,
                    null,  // Можете установить Category позже, если нужно
                    null  // Tags можно преобразовать аналогичным образом, если требуется
                )).ToList();

                // Создание категории через фабрику
                return _factory.Create(c.Id, c.Name, testTasks);
            }).ToList();

            return categories;
        }


        public async Task<Category> GetById(Guid id)
        {
            var categoryEntity = await _repository.GetByIdAsync(id);
            var testTask = categoryEntity.TestTasks.Select(t =>
            {
                var task = _testTaskFactory.Create(
                   t.Id,
                    t.Title,
                    t.Description,
                    t.DateAdded,
                    t.FilePath,
                    t.DifficultyLevels,
                    t.CategoryId,
                    null,  // установить Category позже
                    null);
                return task;
            }).ToList();
            var category = _factory.Create(categoryEntity.Id, categoryEntity.Name, testTask);
            return category;
        }

        public async Task<Category> Create(Category category)
        {
            var testsTasks = category.TestTasks;
            var tasksEntities = testsTasks.Select(t =>
            {
                var entity = new TestTaskEntity
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    DateAdded = t.DateAdded,
                    FilePath = t.FilePath,
                    DifficultyLevels = t.DifficultyLevels,
                    CategoryId = t.CategoryId,
                    Category = null,  // установить Category позже
                    Tags = null
                };
                return entity;
            }).ToList();

            var categoryEntity = new CategoryEntity
            {
                Id = category.Id,
                Name = category.Name,
                TestTasks = tasksEntities
            };
            await _repository.PostAsync(categoryEntity);
            return category;
        }

        public async Task<Category> Update(Category category)
        {
            var testsTasks = category.TestTasks;
            var tasksEntities = testsTasks.Select(t =>
            {
                var entity = new TestTaskEntity
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    DateAdded = t.DateAdded,
                    FilePath = t.FilePath,
                    DifficultyLevels = t.DifficultyLevels,
                    CategoryId = t.CategoryId,
                    Category = null,  // установить Category позже
                    Tags = null
                };
                return entity;
            }).ToList();

            var categoryEntity = new CategoryEntity
            {
                Id = category.Id,
                Name = category.Name,
                TestTasks = tasksEntities
            };
            await _repository.PutAsync(categoryEntity);
            return category;
        }

        public async Task Delete(Guid id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}

