using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Model
{
    public class Endereco 
    {
        public int id { get; set; }

        [Required(ErrorMessage = "O campo Nome do Cliente é obrigatório."), MinLength(3, ErrorMessage = "Nome Muito curto")]
        public string NomeCliente { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo Telefone é obrigatório."), StringLength(12, MinimumLength = 11, ErrorMessage = "Número Invalido")]
        public string Telefone { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo Cidade é obrigatório.")]
        public string Cidade { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo bairro é obigatorio.")]
        public string Bairro { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo Rua é obrigatório.")]
        public string Rua { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo Número da casa é obrigatório.")]
        public string Numero { get; set; } = string.Empty;
    }
}
