namespace AecTest.Core.Entities
{
    public class Usuarios : Entity
    {
        public string? Name { get; set; }
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }

        public ICollection<Enderecos> Enderecos { get; set; } = new List<Enderecos>();
    }
}
