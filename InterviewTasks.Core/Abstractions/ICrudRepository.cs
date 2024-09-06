using System;
namespace InterviewTasks.Core.Abstractions
{
	public interface ICrudRepository<T> where T : class
	{
        public Task<T> GetByIdAsync(Guid id);
        public Task<ICollection<T>> GetListAsync();
        public Task<T> PostAsync(T obj);
        public Task<T> PutAsync(T obj);
        public Task DeleteAsync(Guid id);
    }
}

