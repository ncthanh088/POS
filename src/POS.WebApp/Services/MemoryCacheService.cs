using POS.WebApp.Models;
using POS.WebApp.Services.Abstractions;
using System.Text.Json;
using Microsoft.Extensions.Caching.Memory;

namespace POS.WebApp.Services;

public class MemoryCacheService : IMemoryCacheService
{
    private readonly IMemoryCache _memoryCache;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfigurationService _configurationService;

    public MemoryCacheService(IMemoryCache memoryCache, IHttpClientFactory httpClientFactory, IConfigurationService configurationService)
    {
        _memoryCache = memoryCache;
        _httpClientFactory = httpClientFactory;
        _configurationService = configurationService;
    }

    public Task<Tax> GetAllTaxesAsync(bool useCached = true)
    {
        throw new NotImplementedException();
    }

    public Task<Configuration> GetConfigurationAsync(bool useCached = true)
    {
        return GetOrCreateAsync("pos-configuration", async entry =>
            {
                Configuration configuration = null;
                var client = _httpClientFactory.CreateClient("configuration/api");
                var url = string.Format("pos-configuration");

                var hostName = Environment.MachineName;
                // var ipAddress = _terminalService.GetLocalIpAddress();
                // var queryBuilder = new QueryBuilder();
                // queryBuilder.AddIfNotNull("deviceName", hostName);
                // queryBuilder.AddIfNotNull("machineName", ipAddress);
                var response = await client.GetAsync($"{url}");
                response.EnsureSuccessStatusCode();

                var responseContent = await response.Content.ReadAsStringAsync();
                configuration = JsonSerializer.Deserialize<Configuration>(responseContent);

                return configuration;
            }, !useCached);
    }

    public Task<string> GetReceipTemplate(bool useCached = true)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetUserAsync(int userId, bool useCached = true)
    {
        throw new NotImplementedException();
    }

    public void ClearCacheForCollection(object key)
    {
        _memoryCache.Remove(key);
    }

    private Task<TItem> GetOrCreateAsync<TItem>(object key, Func<ICacheEntry, Task<TItem>> factory, bool renewData = false)
    {
        if (renewData) ClearCacheForCollection(key);
        return _memoryCache.GetOrCreateAsync(key, factory);
    }
}
