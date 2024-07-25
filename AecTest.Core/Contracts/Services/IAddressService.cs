using AecTest.Core.Entities;

namespace AecTest.Core.Contracts.Services
{
    public interface IAddressService
    {
        Task Create(Endereco endereco, string? loginId);
        void Delete(Endereco endereco);
        Task<IEnumerable<Endereco>> GetAll(string? loginId);
        Endereco? GetById(Guid id);
        Task Update(Endereco endereco);
        Task<Stream> ExportCsv();
    }
}
