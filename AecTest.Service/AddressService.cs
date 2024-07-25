using AecTest.Core.Contracts.Repository;
using AecTest.Core.Contracts.Services;
using AecTest.Core.Entities;
using Microsoft.Extensions.Logging;

namespace AecTest.Service
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly ILogger _logger;

        public AddressService(IAddressRepository addressRepository, ILogger<AddressService> logger)
        {
            _addressRepository = addressRepository;
            _logger = logger;
        }

        public async Task Create(Endereco endereco)
        {
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

        public Task<IEnumerable<Endereco>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task Update(Endereco endereco)
        {
           await _addressRepository.UpdateAsync(endereco);
        }
    }
}
