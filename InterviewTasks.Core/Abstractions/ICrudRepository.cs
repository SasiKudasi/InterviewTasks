using System;
namespace InterviewTasks.Core.Abstractions
{
	public interface ICrudRepository<T> where T : class
	{
        public Task<T> GetByIdAsync(Guid id, params string[] includeProperties);
        public Task<ICollection<T>> GetListAsync(params string[] includeProperties);
        public Task<T> PostAsync(T obj);
        public Task<T> PutAsync(T obj);
        public Task DeleteAsync(Guid id);
    }
}

