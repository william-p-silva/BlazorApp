namespace BlazorApp.Model
{
    public class Endereco
    {
        public int id { get; set; }
        public string NomeCliente { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public string Bairro { get; set; } = string.Empty;
        public string Rua { get; set; } = string.Empty;
        public string Numero { get; set; }
    }
}
