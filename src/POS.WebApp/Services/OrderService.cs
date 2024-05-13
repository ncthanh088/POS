using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Blazored.LocalStorage;
using POS.WebApp.Models;

namespace POS.WebApp.Services;

public class OrderService : IOrderService
{

    private readonly HttpClient _client;
    private readonly JsonSerializerOptions _options;

    private readonly ILocalStorageService _localStorage;

    public OrderService(HttpClient client, ILocalStorageService localStorage)
    {
        _client = client;
        _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        _localStorage = localStorage;
    }

    public async Task<Guid> PlaceOrderAsync(PlaceOrderRequest request)
    {
        var token = await _localStorage.GetItemAsync<string>("token");
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var response = await _client.PostAsJsonAsync($"Orders", request);
        var content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new ApplicationException(content);
        }
        return Guid.NewGuid();
    }
}
