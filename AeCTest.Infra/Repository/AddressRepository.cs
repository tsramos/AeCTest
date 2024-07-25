using AecTest.Core.Contracts.Repository;
using AecTest.Core.Entities;

namespace AeCTest.Infra.Repository
{
    public class AddressRepository : BaseRepository<Enderecos>, IAddressRepository
    {
        public AddressRepository(Context context) : base(context)
        {
        }
    }
}
