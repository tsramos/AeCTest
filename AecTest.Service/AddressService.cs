using AecTest.Core.Contracts.Repository;
using AecTest.Core.Contracts.Services;
using AecTest.Core.Entities;
using Microsoft.Extensions.Logging;

namespace AecTest.Service
{
    public class AddressService : IAddressService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly ILogger _logger;

        public AddressService(IUserRepository userRepository,
                              IAddressRepository addressRepository,
                              ILogger<AddressService> logger)
        {
            _userRepository = userRepository;
            _addressRepository = addressRepository;
            _logger = logger;
        }

        public async Task Create(Endereco endereco, string? loginId)
        {
            Guid usuarioId = await FindUserIdAsync(loginId);
            endereco.UsuarioId = usuarioId;
            await _addressRepository.Create(endereco);
        }

        public void Delete(Endereco endereco)
        {
            _addressRepository.Delete(endereco);
        }

        public Task<Stream> ExportCsv()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Endereco>> GetAll(string? loginId)
        {
            Guid usuarioId = await FindUserIdAsync(loginId);
            return _addressRepository.GetAll().Where(x => x.UsuarioId == usuarioId).AsEnumerable();
        }

        private async Task<Guid> FindUserIdAsync(string? loginId)
        {
            Guid usuarioId = await _userRepository.FindByLoginIdAsync(loginId);
            if (usuarioId == default)
            {
                string mensagem = $"Usuario não encontrado id de login {loginId}";
                _logger.LogError(mensagem);
                throw new ArgumentException(mensagem);
            }

            return usuarioId;
        }

        public Endereco? GetById(Guid id)
        {
            return _addressRepository.GetById(id);
        }

        public async Task Update(Endereco endereco)
        {
            await _addressRepository.UpdateAsync(endereco);
        }      
    }
}
