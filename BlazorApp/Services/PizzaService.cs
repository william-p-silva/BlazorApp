using BlazorApp.Model;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorApp.Services
{
    public class PizzaService
    {
        private readonly HttpClient _HttpClient;

        public PizzaService(HttpClient httpClient)
        {
            _HttpClient = httpClient;
        }

        public async Task<List<ModeloPizza>> GetPizzasAsync(string baseUrl)
        {
            var pizzas = await _HttpClient.GetFromJsonAsync<List<ModeloPizza>>($"{baseUrl}specials");
            return pizzas ?? new List<ModeloPizza>();
        }



    }
}
