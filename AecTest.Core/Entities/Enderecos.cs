namespace AecTest.Core.Entities
{
    public class Enderecos : Entity
    {        
        public string? Cep { get; set; }
        public string? Logradouro { get; set; }
        public string? Complemento { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? Uf { get; set; }
        public string? Numero { get; set; }
        
        public Guid UsuarioId { get; set; }
        public Usuarios? Usuario { get; set; }
    }
}
