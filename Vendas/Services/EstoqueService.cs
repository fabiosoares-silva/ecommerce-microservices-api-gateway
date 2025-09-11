using System.Text;
using System.Text.Json;

namespace Vendas.Services
{
    public class EstoqueService
    {
        private readonly HttpClient _httpClient;
        private readonly string EstoqueBaseUrl = "http://localhost:5185";

        public EstoqueService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> VerificarEstoque(int produtoId, int quantidade)
        {
            var requestData = new
            {
                ProdutoId = produtoId,
                Quantidade = quantidade
            };

            var jsonContent = new StringContent(
                JsonSerializer.Serialize(requestData),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.PostAsync($"{EstoqueBaseUrl}/api/estoque/verificar", jsonContent);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return bool.Parse(result);
            }

            return false;
        }
    }
}
