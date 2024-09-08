using System;
using InterviewTasks.Core.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace InterviewTasks.DataAccess.Repository
{
	public class CrudRepository<T>  : ICrudRepository<T> where T : class
	{
		private readonly InterviewTasksDbContext _context;
        private DbSet<T> _dbSet;
        public CrudRepository(InterviewTasksDbContext context)
		{
			_context = context;
			_dbSet = context.Set<T>();
		}

        public async Task<T> GetByIdAsync(Guid id, params string[] includeProperties)
        {
            IQueryable<T> query = _dbSet;

            // Применяем Include для указанных навигационных свойств
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            var entity = await query.FirstOrDefaultAsync(e => EF.Property<Guid>(e, "Id") == id);
            return entity;
        }

        public async Task<ICollection<T>> GetListAsync(params string[] includeProperties)
        {
            IQueryable<T> query = _dbSet;

            // Применяем Include для указанных навигационных свойств
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            var entity = await query.ToListAsync();
            return entity;
        }

        public async Task<T> PostAsync(T obj)
		{
			await _dbSet.AddAsync(obj);
			await _context.SaveChangesAsync();
			return obj;
		}

		public async Task<T> PutAsync(T obj)
		{
            _dbSet.Update(obj);
			await _context.SaveChangesAsync();
			return obj;
		}

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}

