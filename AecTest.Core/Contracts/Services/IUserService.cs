using AecTest.Core.Entities;

namespace AecTest.Core.Contracts.Services
{
    public interface IUserService
    {
        Task Create(Usuario usuario);
    }
}
