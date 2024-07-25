using AecTest.Core.Contracts.Repository;
using AecTest.Core.Contracts.Services;
using AecTest.Core.Entities;
using Microsoft.Extensions.Logging;
using System.Text;

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
            _logger.LogInformation($"Endereço criado com sucesso para o usuário {usuarioId}");
        }

        public void Delete(Endereco endereco)
        {
            _addressRepository.Delete(endereco);
            _logger.LogInformation($"Endereço deletado com sucesso.");
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
            _logger.LogInformation($"Endereço atualizado com sucesso para o usuário {endereco.UsuarioId}");
        }

        public async Task<Stream> ExportCsv(string loginId)
        {
           var enderecos = await this.GetAll(loginId);

            var csvBuilder = new StringBuilder();
            csvBuilder.AppendLine("Logradouro,Numero,Complemento,Bairro,Cidade,Estado");

            foreach (var endereco in enderecos)
            {
                csvBuilder.AppendLine($"{endereco.Logradouro};{endereco.Numero};{endereco.Complemento};{endereco.Bairro};{endereco.Cidade};{endereco.Uf}");
            }

            var csvBytes = Encoding.UTF8.GetBytes(csvBuilder.ToString());
            return new MemoryStream(csvBytes);
        }
    }
}
