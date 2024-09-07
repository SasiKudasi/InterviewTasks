using System;
using InterviewTasks.Core.Abstractions;
using InterviewTasks.Core.Models;
using InterviewTasks.DataAccess.Entities;

namespace InterviewTasks.Application.Services
{
	public class TagService : IService<Tag>
	{
        private readonly ICrudRepository<TagEntity> _repository;
        private readonly ITagFactory _factory;
        private readonly ITestTaskFactory _testTaskFactory;
        private readonly ICategoryFactory _categoryFactpry;

        public TagService(ICrudRepository<TagEntity> repository, ITagFactory factory,
            ITestTaskFactory testTaskFactory, ICategoryFactory categoryFactory)
		{

            _repository = repository;
            _factory = factory;
            _testTaskFactory = testTaskFactory;
            _categoryFactpry = categoryFactory;
		}

        public async Task<Tag> Create(Tag obj)
        {
            var tagEntity = new TagEntity
            {
                Id = new Guid(),
                Name = obj.Name,
                TestTaskId = obj.TestTaskId,
            };
            await _repository.PostAsync(tagEntity);
            return obj;
        }

        public async Task Delete(Guid id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<Tag> GetById(Guid id)
        {
            var tagEntity = await _repository.GetByIdAsync(id);
            var taskEntity = tagEntity.TestTask;
            var task = _testTaskFactory.Create(
                 taskEntity.Id,
                taskEntity.Title,
                taskEntity.Description,
                taskEntity.DateAdded,
                taskEntity.FilePath,
                taskEntity.DifficultyLevels,
                taskEntity.CategoryId,
                null,
                null);

            var tag = _factory.Create(
                tagEntity.Id,
                tagEntity.Name,
                tagEntity.TestTaskId,
                task);
            return tag;
        }

        public async Task<ICollection<Tag>> GetList()
        {
            var tagEntities = await _repository.GetListAsync();
            var tagList = tagEntities.Select(t =>
            {
                var tag = _factory.Create(
                    t.Id,
                    t.Name,
                    t.TestTaskId,
                    null);
                return tag;
            }).ToList();
            return tagList;
        }

        public async Task<Tag> Update(Tag obj)
        {
            var tagEntity = new TagEntity
            {
                Id = obj.Id,
                Name = obj.Name,
                TestTaskId = obj.TestTaskId,
                TestTask = null
            };
            await _repository.PutAsync(tagEntity);
            return obj;
        }
    }
}

