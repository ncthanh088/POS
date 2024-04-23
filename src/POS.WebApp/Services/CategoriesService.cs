using System.Text.Json;
using POS.WebApp.Models;

namespace POS.WebApp.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;

        public CategoriesService(HttpClient client)
        {
            _client = client;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            var response = await _client.GetAsync("categories");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var products = JsonSerializer.Deserialize<IEnumerable<Category>>(content, _options);

            if (products is null)
                return new List<Category> { };
            return products;
        }
    }
}
