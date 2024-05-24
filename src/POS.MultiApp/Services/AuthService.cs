using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using POS.MultiApp.LocalStorage;
using POS.MultiApp.Models;
using POS.MultiApp.Models.Auth;

namespace POS.MultiApp.Services;
public class AuthService : IAuthService
{

    private readonly HttpClient _client;
    private readonly JsonSerializerOptions _options;
    private readonly ILocalStorage _localStorage;

    public AuthService(HttpClient client, ILocalStorage localStorage)
    {
        _client = client;
        _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        _localStorage = localStorage;
    }

    public async Task<UserInfo> GetOrCreateUserInfoAsync()
    {
        var user = await _localStorage.GetValueAsync<UserInfo>(Constants.Constant.USER_INFO_KEY);
        if (user != null)
        {
            return user;
        }
        var jwt = await _localStorage.GetValueAsync<Jwt>(Constants.Constant.JWT_KEY);
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt?.AccessToken);
        var response = await _client.GetAsync($"users/me");
        var content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            _localStorage.RemoveValue<Jwt>(Constants.Constant.JWT_KEY);
            throw new ApplicationException(content);
        }
        user = JsonSerializer.Deserialize<UserInfo>(content, _options);
        return user;
    }

    public Task LogoutAsync()
    {
        _localStorage.RemoveAll();
        return Task.CompletedTask;
    }

    public async Task<Jwt> SignIn(string email, string password)
    {
        // check user exists on localstorage before call api login
        var request = new SignIn
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
        var jwt = JsonSerializer.Deserialize<Jwt>(content, _options);

        return jwt;
    }
}

