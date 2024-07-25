using AecTest.Core.Entities;

namespace AecTest.Core.Contracts.Repository
{
    public interface IUserRepository : IBaseRepository<Usuario>
    {
        Task<Guid> FindByLoginIdAsync(string? loginId);
    }
}
