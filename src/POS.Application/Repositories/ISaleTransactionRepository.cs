using POS.Application.DTO;
using POS.Domain.Entities;

namespace POS.Application.Repositories;

public interface ISaleTransactionRepository
{
    Task<SaleTransactionDto> CreateSaleTransaction(SaleTransaction saleTransaction);
}
