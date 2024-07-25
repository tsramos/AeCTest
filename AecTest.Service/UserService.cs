using AecTest.Core.Contracts.Repository;
using AecTest.Core.Contracts.Services;
using AecTest.Core.Entities;

namespace AecTest.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Create(Usuario usuario)
        {
            await _userRepository.Create(usuario);
        }

        public Task<Guid> FindByLoginId(string loginId)
        {
            return _userRepository.FindByLoginIdAsync(loginId);
        }
    }
}
