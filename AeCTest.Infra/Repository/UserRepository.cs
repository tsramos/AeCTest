using AecTest.Core.Contracts.Repository;
using AecTest.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace AeCTest.Infra.Repository
{
    public class UserRepository : BaseRepository<Usuario>, IUserRepository
    {
        public UserRepository(Context context) : base(context)
        {
        }

        public async Task<Guid> FindByLoginIdAsync(string? loginId)
        {
           var entity = await this.GetAll().FirstOrDefaultAsync(x => x.UserId == loginId);
            return entity!.Id;
        }
    }
}
