using System;
using InterviewTasks.Core.Abstractions;
using InterviewTasks.Core.Models;
using InterviewTasks.DataAccess.Entities;

namespace InterviewTasks.Application.Services
{
	public class TagService : IService<Tag>
	{
        private readonly ICrudRepository<TagEntity> _repository;
        private readonly ITegFactory _factory;
        private readonly ITestTaskFactory _testTaskFactory;

        public TagService(ICrudRepository<TagEntity> repository, ITegFactory factory, ITestTaskFactory testTaskFactory)
		{
            _repository = repository;
            _factory = factory;
            _testTaskFactory = testTaskFactory;
		}

        public async Task<Tag> Create(Tag obj)
        {
            var tagEntity = new TagEntity
            {
                Id = obj.Id,
                Name = obj.Name,
                TestTaskId = obj.TestTaskId,
                TestTask = null
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
            var tag = _factory.Create(
                tagEntity.Id,
                tagEntity.Name,
                tagEntity.TestTaskId,
                null);
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

