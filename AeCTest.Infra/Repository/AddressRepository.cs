using AecTest.Core.Contracts.Repository;
using AecTest.Core.Entities;

namespace AeCTest.Infra.Repository
{
    public class AddressRepository : BaseRepository<Endereco>, IAddressRepository
    {
        public AddressRepository(Context context) : base(context)
        {
        }

        public Endereco? GetById(Guid id)
        {
            return this.GetAll().FirstOrDefault(x => x.Id == id);
        }
    }
}
