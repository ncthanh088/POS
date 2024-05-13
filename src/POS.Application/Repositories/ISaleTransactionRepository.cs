using POS.Domain.Entities;

namespace POS.Application.Repositories;

public interface ISaleTransactionRepository
{
    Task CreateSaleTransaction(SaleTransaction saleTransaction);
}
