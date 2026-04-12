using BlazorApp.Model;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorApp.Services
{
    public class PedidoService
    {
        private HttpClient _HttpClient;

        public PedidoService(HttpClient httpClient)
        {
            _HttpClient = httpClient;
        }

        
        public async Task<List<Pedido>> GetPedidosAsync(string baseUrl)
        {
            var pedidos = await _HttpClient.GetFromJsonAsync<List<Pedido>>(baseUrl + "orders");
            return pedidos ?? new List<Pedido>();
        }

        public async Task<Pedido> GetPedidoIdAsync(string baseUrl, int orderId)
        {
            var pedido = await _HttpClient.GetFromJsonAsync<Pedido>($"{baseUrl}orders/{orderId}");
            return pedido ?? new Pedido();
        } 

        public async Task<int> PlaceOrderAsync(string baseUrl, Pedido pedido)
        {

            var response = await _HttpClient.PostAsJsonAsync(baseUrl + "orders", pedido);
            response.EnsureSuccessStatusCode();// 🚩 Lança uma exceção se algo der errado
            var NovoId = await response.Content.ReadFromJsonAsync<int>();
            return NovoId;
        }
    }
}
