using System.ComponentModel.DataAnnotations;

namespace AeCTest.Web.Models
{
    public class EnderecoViewModel
    {
        public string UsuarioId { get; set; } = string.Empty;
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Informe o nome da rua")]        
        public string Logradouro { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe o número do endereço")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "Informe o numero do cep")]
        public string Cep { get; set; } = string.Empty;

        public string? Complemento { get; set; }

        [Required(ErrorMessage = "Informe o bairro")]
        public string Bairro { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe a cidade")]
        public string Cidade { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe o estado")]
        public string UF { get; set; } = string.Empty;

    }
}
