using System.Text.Json;

namespace POS.WebApp.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;

        public ProductService(HttpClient client)
        {
            _client = client;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            var response = await _client.GetAsync("products");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var products = JsonSerializer.Deserialize<IEnumerable<Product>>(content, _options);

            if (products is null)
                return new List<Product> { };
            return products;

        }
    }
}
