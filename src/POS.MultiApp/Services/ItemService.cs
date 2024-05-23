using System.Text.Json;
using POS.MultiApp.Models;

namespace POS.MultiApp.Services
{
    public class ItemService : IItemService
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;
        public event Action OnChange;

        public ItemService(HttpClient client)
        {
            _client = client;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<Item> GetItemAsync(int itemId)
        {
            var response = await _client.GetAsync($"items/itemId?itemId={itemId}");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var item = JsonSerializer.Deserialize<Item>(content, _options);
            return item;
        }

        public async Task<IEnumerable<Item>> GetItemsByCategoryIdAsync(int categoryId)
        {
            var response = await _client.GetAsync($"items/categoryId?categoryId={categoryId}");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var items = JsonSerializer.Deserialize<IEnumerable<Item>>(content, _options);

            if (items is null)
            {
                return [];
            }
            return items;
        }
    }
}
