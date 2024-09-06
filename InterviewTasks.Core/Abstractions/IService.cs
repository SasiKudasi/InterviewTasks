using System;
namespace InterviewTasks.Core.Abstractions
{
	public interface IService<T> where T: class
	{
        public Task<T> GetById(Guid id);
        public Task<ICollection<T>> GetList();
        public Task<T> Create(T obj);
        public Task<T> Update(T obj);
        public Task Delete(Guid id);
    }
}

