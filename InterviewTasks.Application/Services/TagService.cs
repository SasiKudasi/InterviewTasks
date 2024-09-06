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

        public Task<Tag> Create(Tag obj)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Tag> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Tag>> GetList()
        {
            throw new NotImplementedException();
        }

        public Task<Tag> Update(Tag obj)
        {
            throw new NotImplementedException();
        }
    }
}

