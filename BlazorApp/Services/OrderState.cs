using BlazorApp.Model;



namespace BlazorApp.Services
{
    public class OrderState
    {
        public event Action? OnChange;
        public bool ShowingConfigureDialog { get; private set; }
        public ModeloPizza? ConfiguringPizza { get; private set; }
        public Pedido PedidoAtivo { get; private set; } = new();
        public decimal PrecoTotalPedido => PedidoAtivo.Pizzas.Sum(p => p.GetPrecoTotal());
        public void ShowConfigureDialog(ModeloPizza pizza)
        {
            ConfiguringPizza = new ModeloPizza()
            {
                Id = pizza.Id,
                Nome = pizza.Nome,
                PrecoBase = pizza.PrecoBase,
                Descricao = pizza.Descricao,
                ImagemUrl = pizza.ImagemUrl,
                Vegetariana = pizza.Vegetariana,
                Vegana = pizza.Vegana
            };

            ShowingConfigureDialog = true;
            NotifySateChanged();
        }
        public void CancelConfiguringPizza()
        {
            ConfiguringPizza = null;
            ShowingConfigureDialog = false;
            NotifySateChanged();
        }
        public void ConfirmConfiguringPizza()
        {
            if (ConfiguringPizza != null)
            {
                PedidoAtivo.Pizzas.Add(ConfiguringPizza);
            }

            ConfiguringPizza = null;
            ShowingConfigureDialog = false;
            NotifySateChanged();
        }

        public void RemovePizza(ModeloPizza pizza)
        {

            PedidoAtivo.Pizzas.Remove(pizza);
            NotifySateChanged();

        }
        public void ResetOrder()
        {
            PedidoAtivo = new Pedido();
            NotifySateChanged();
        }
        private void NotifySateChanged() => OnChange?.Invoke();

    }
}
