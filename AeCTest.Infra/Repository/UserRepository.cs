using AecTest.Core.Contracts.Repository;
using AecTest.Core.Entities;

namespace AeCTest.Infra.Repository
{
    public class UserRepository : BaseRepository<Usuario>, IUserRepository
    {
        public UserRepository(Context context) : base(context)
        {
        }
    }
}
