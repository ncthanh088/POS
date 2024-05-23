using System.Net.Http.Json;
using System.Text.Json;
using POS.MultiApp.Models;
using POS.MultiApp.LocalStorage;
using POS.MultiApp.Services.Abstractions;

namespace POS.MultiApp.Services;

public class PaymentService : IPaymentService
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _options;
    private readonly ILocalStorage _localStorage;

    public PaymentService(HttpClient client, ILocalStorage localStorage)
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
        var transaction = await _localStorage
                .GetValueAsync<BaseSaleTransaction>(Constants.Constant.SALE_TRANSACTION_KEY);

        if (transaction == null)
        {
            transaction = await CreateSaleTransactionAsync(request);
            await _localStorage.SetValueAsync(Constants.Constant.SALE_TRANSACTION_KEY, transaction);

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
            await _localStorage.SetValueAsync(Constants.Constant.SALE_TRANSACTION_KEY, transaction);
        }
        return transaction;
    }
}
