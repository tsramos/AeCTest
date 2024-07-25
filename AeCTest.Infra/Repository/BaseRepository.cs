using AecTest.Core.Contracts.Repository;
using AecTest.Core.Entities;

namespace AeCTest.Infra.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : Entity
    {
        private readonly Context _context;
        public BaseRepository(Context context)
        {
            _context = context;
        }

        public async Task Create(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public IQueryable<T> GetAll()
        {
            var entities = _context.Set<T>();
            return entities.AsQueryable();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
