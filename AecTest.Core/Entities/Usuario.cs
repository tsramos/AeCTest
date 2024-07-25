namespace AecTest.Core.Entities
{
    public class Usuario : Entity
    {
        public string? Name { get; set; }
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }

        public ICollection<Endereco> Enderecos { get; set; } = new List<Endereco>();
    }
}
