using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using Blazored.LocalStorage;
using POS.WebApp.Models;

namespace POS.WebApp.Services;
public class AuthService : IAuthService
{

    private readonly HttpClient _client;
    private readonly ILocalStorageService _localStorage;
    private readonly JsonSerializerOptions _options;

    public AuthService(HttpClient client, ILocalStorageService localStorage)
    {
        _client = client;
        _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        _localStorage = localStorage;
    }

    public async Task<User> GetUserInfoAsync()
    {
        var token = await _localStorage.GetItemAsync<string>("token");
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await _client.GetAsync($"Users/me");
        var content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new ApplicationException(content);
        }
        var user = JsonSerializer.Deserialize<User>(content, _options);

        return user;
    }

    public async Task<JwtDto> SignIn(string email, string password)
    {
        // check user exists on localstorage before call api login
        var request = new SignInRequest
        {
            Email = email,
            Password = password
        };
        var response = await _client.PostAsJsonAsync($"Users/sign-in", request);
        var content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new ApplicationException(content);
        }
        var jwt = JsonSerializer.Deserialize<JwtDto>(content, _options);

        return jwt;
    }
}

