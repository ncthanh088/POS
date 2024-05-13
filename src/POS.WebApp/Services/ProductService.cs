using System.Text.Json;
using POS.WebApp.Models;

namespace POS.WebApp.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;
        public event Action OnChange;

        public ProductService(HttpClient client)
        {
            _client = client;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<Product> GetProductAsync(Guid productId)
        {
            var response = await _client.GetAsync($"Products/{productId}");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var product = JsonSerializer.Deserialize<Product>(content, _options);

            return product;
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryIdAsync(int categoryId)
        {
            var response = await _client.GetAsync($"Products/categoryId?categoryId={categoryId}");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var products = JsonSerializer.Deserialize<IEnumerable<Product>>(content, _options);

            if (products is null)
            {
                return new List<Product> { };
            }
            return products;
        }
    }
}
