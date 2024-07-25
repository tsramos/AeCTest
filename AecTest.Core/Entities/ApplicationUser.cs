using Microsoft.AspNetCore.Identity;

namespace AecTest.Core.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
    }
}
