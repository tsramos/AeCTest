using AecTest.Core.Contracts.Repository;
using AecTest.Core.Entities;

namespace AeCTest.Infra.Repository
{
    public class UserRepository : BaseRepository<Usuarios>, IUserRepository
    {
        public UserRepository(Context context) : base(context)
        {
        }
    }
}
