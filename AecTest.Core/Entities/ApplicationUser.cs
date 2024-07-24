using Microsoft.AspNetCore.Identity;

namespace AecTest.Core.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Usuarios> Usuarios { get; set; } = new List<Usuarios>();
    }
}
