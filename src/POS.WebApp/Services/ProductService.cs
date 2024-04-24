using System.Text.Json;
using POS.WebApp.Models;

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

        public Task<IEnumerable<Product>> GetProductsAsync()
        {
            throw new HttpRequestException();
        }
    }
}
