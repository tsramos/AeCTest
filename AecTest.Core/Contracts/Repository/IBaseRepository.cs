using AecTest.Core.Entities;

namespace AecTest.Core.Contracts.Repository
{
    public interface IBaseRepository<T> where T : Entity
    {
        IQueryable<T> GetAll();
        Task Create(T entity);
        Task UpdateAsync(T entity);
        void Delete(T entity);
    }
}
