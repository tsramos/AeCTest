using AecTest.Core.Entities;

namespace AecTest.Core.Contracts.Services
{
    public interface IAddressService
    {
        Task Create(Endereco endereco);
        void Delete(Endereco endereco);
        Task<IEnumerable<Endereco>> GetAll();
        Task Update(Endereco endereco);
        Task<Stream> ExportCsv();
    }
}
