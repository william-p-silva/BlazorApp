using BlazorApp.Model;

namespace BlazorApp.Services
{
    public class EnderecoService
    {
        private HttpClient _HttpClient;
        public EnderecoService (HttpClient httpClient)
        {
            _HttpClient = httpClient;
        }

        public async Task<List<Endereco>> GetEnderecosAsync(string baseUrl)
        {
            var enderecos = await _HttpClient.GetFromJsonAsync<List<Endereco>>(baseUrl + "endereco");
            return enderecos ?? new List<Endereco>();
        }
        

        
    }
}
