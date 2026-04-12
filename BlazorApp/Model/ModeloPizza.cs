namespace BlazorApp.Model
{
    public class ModeloPizza
    {
        public const int TamanhoPadrao = 30;
        public int TamanhoMinimo = 25;
        public int TamanhoMaximo = 45;
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public decimal PrecoBase { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public string ImagemUrl { get; set; } = string.Empty;
        public bool Vegetariana { get; set; }
        public bool Vegana { get; set; }
        public int Tamanho { get; set; } = TamanhoPadrao;

        public decimal GetPrecoTotal()
        {

            return Math.Round((decimal)Tamanho / TamanhoPadrao * PrecoBase, 2);
        }
        public string GetFormatPrecoBase() => PrecoBase.ToString("0.00");

        public string GetFormatPrecoTotal() => GetPrecoTotal().ToString("0.00");
    }
}
