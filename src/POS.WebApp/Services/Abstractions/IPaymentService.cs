using POS.WebApp.Models;

namespace POS.WebApp.Services.Abstractions;

public interface IPaymentService
{
    Task<BaseSaleTransaction> GetOrCreateSaleTransactionAsync(AddSaleTransaction request);
    Task<CalculateSaleTransaction> CalculateSaleTransactionAsync(CalculateSaleTransaction request);
    Task<ProcessSaleTransactionDto> ProcessSaleTransactionAsync(ProcessSaleTransaction request);
}
