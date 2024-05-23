using System.Text.Json;
using POS.MultiApp.Models;

namespace POS.MultiApp.Services
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
            var categories = JsonSerializer.Deserialize<IEnumerable<Category>>(content, _options);

            if (categories is null)
            {
                return new List<Category> { };
            }
            return categories;
        }
    }
}
