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
        private readonly ITagFactory _tagFactory;

        public CategoryService(ICrudRepository<CategoryEntity> repository, ICategoryFactory factory,
            ITestTaskFactory testTaskFactory, ITagFactory tagFactory)
        {
            _repository = repository;
            _factory = factory;
            _testTaskFactory = testTaskFactory;
            _tagFactory = tagFactory;
        }

        public async Task<ICollection<Category>> GetList()
        {
            var categoryEntities = await _repository.GetListAsync("TestTasks.Tags");

            var categories = categoryEntities.Select(c =>
            {
                var category = _factory.Create(c.Id, c.Name, new List<TestTask>());

                var testTasks = c.TestTasks.Select(t =>
                {
                    var newTask = _testTaskFactory.Create(
                        t.Id,
                        t.Title,
                        t.Description,
                        t.DateAdded,
                        t.FilePath,
                        t.DifficultyLevels,
                        t.CategoryId,
                        category,
                        new List<Tag>());
                    var tags = t.Tags?.Select(tag => _tagFactory
                                                 .Create(tag.Id, tag.Name, tag.TestTaskId, newTask))
                                                 .ToList() ?? new List<Tag>();
                    var task = _testTaskFactory.Create(
                       t.Id,
                       t.Title,
                       t.Description,
                       t.DateAdded,
                       t.FilePath,
                       t.DifficultyLevels,
                       t.CategoryId,
                       category,
                       tags);

                       return task;
                }).ToList();

                return _factory.Create(c.Id, c.Name, testTasks);
            }).ToList();

            return categories;
         }


        public async Task<Category> GetById(Guid id)
        {
            var categoryEntity = await _repository.GetByIdAsync(id, "TestTasks.Tags");
            var newCategory = _factory.Create(categoryEntity.Id, categoryEntity.Name, new List<TestTask>());

            var testTask = categoryEntity.TestTasks.Select(t =>
            {
                
                var newTask = _testTaskFactory.Create(
                   t.Id,
                    t.Title,
                    t.Description,
                    t.DateAdded,
                    t.FilePath,
                    t.DifficultyLevels,
                    t.CategoryId,
                    newCategory,
                    new List<Tag>());
                var tags = t.Tags?.Select(tag => _tagFactory
                                             .Create(tag.Id, tag.Name, tag.TestTaskId, newTask))
                                             .ToList() ?? new List<Tag>();
                var task = _testTaskFactory.Create(
                  t.Id,
                   t.Title,
                   t.Description,
                   t.DateAdded,
                   t.FilePath,
                   t.DifficultyLevels,
                   t.CategoryId,
                   newCategory,
                   tags);
                return task;
            }).ToList();
            var category = _factory.Create(newCategory.Id, newCategory.Name, testTask);
            return category;
        }

        public async Task<Category> Create(Category category)
        {
            var categoryEntity = new CategoryEntity
            {
                Id = new Guid(),
                Name = category.Name,
                TestTasks = new List<TestTaskEntity>()
            };

            await _repository.PostAsync(categoryEntity);
            return category;
        }



        public async Task<Category> Update(Category category)
        {
            var categoryEntity = new CategoryEntity
            {
                Id = category.Id,
                Name = category.Name,
                TestTasks = new List<TestTaskEntity>()
            };

            var tasksEntities = category.TestTasks.Select(t =>
            {
                var taskEntity = new TestTaskEntity
                {
                    Id = (Guid)t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    DateAdded = t.DateAdded,
                    FilePath = t.FilePath,
                    DifficultyLevels = t.DifficultyLevels,
                    CategoryId = t.CategoryId,
                    Category = categoryEntity,
                    Tags = new List<TagEntity>()
                };

                taskEntity.Tags = t.Tags.Select(tag =>
                {
                    return new TagEntity
                    {
                        Id = tag.Id,
                        Name = tag.Name,
                        TestTaskId = taskEntity.Id,
                        TestTask = taskEntity
                    };
                }).ToList();
                return taskEntity;
            }).ToList();

            categoryEntity.TestTasks = tasksEntities;
            await _repository.PutAsync(categoryEntity);
            return category;
        }

        public async Task Delete(Guid id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}

