namespace BlazorApp.Model
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public List<ModeloPizza> Pizzas { get; set; } = new();
        public string Status { get; set; } = "Em preparo";
        public Endereco EnderecoEntrega { get; set; } = new();
        public decimal GetPrecoTotal() => Pizzas.Sum(p => p.GetPrecoTotal());
    }
}
