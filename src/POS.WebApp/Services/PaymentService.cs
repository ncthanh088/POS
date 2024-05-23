using System.Net.Http.Json;
using System.Text.Json;
using Blazored.LocalStorage;
using POS.WebApp.Models;
using POS.WebApp.Services.Abstractions;

namespace POS.WebApp.Services;

public class PaymentService : IPaymentService
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _options;
    private readonly ILocalStorageService _localStorage;


    public PaymentService(HttpClient client, ILocalStorageService localStorage)
    {
        _httpClient = client;
        _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        _localStorage = localStorage;
    }



    public async Task<CalculateSaleTransaction> CalculateSaleTransactionAsync(CalculateSaleTransaction request)
    {
        var response = await _httpClient.PostAsJsonAsync($"payments/calculate", request);
        var content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new ApplicationException(content);
        }
        var transaction = JsonSerializer.Deserialize<CalculateSaleTransaction>(content, _options);

        return transaction;
    }

    public async Task<ProcessSaleTransactionDto> ProcessSaleTransactionAsync(ProcessSaleTransaction request)
    {
        var response = await _httpClient.PostAsJsonAsync($"payments/process-payment", request);
        var content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new ApplicationException(content);
        }
        var transaction = JsonSerializer.Deserialize<ProcessSaleTransactionDto>(content, _options);
        return transaction;
    }

    public async Task<BaseSaleTransaction> GetOrCreateSaleTransactionAsync(AddSaleTransaction request)
    {
        var transaction = await _localStorage.GetItemAsync<BaseSaleTransaction>("transaction");
        if (transaction is null)
        {
            transaction = await CreateSaleTransactionAsync(request);
            await _localStorage.SetItemAsync<BaseSaleTransaction>("transaction", transaction);
        }
        return transaction;
    }

    private async Task<BaseSaleTransaction> CreateSaleTransactionAsync(AddSaleTransaction request)
    {
        var response = await _httpClient.PostAsJsonAsync($"payments/transaction", request);
        var content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new ApplicationException(content);
        }
        var transaction = JsonSerializer.Deserialize<BaseSaleTransaction>(content, _options);

        if (transaction != null)
        {
            await _localStorage.SetItemAsync("transaction", transaction);
        }
        return transaction;
    }
}
