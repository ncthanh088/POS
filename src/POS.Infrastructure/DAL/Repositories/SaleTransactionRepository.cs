using POS.Application.DTO;
using POS.Application.Repositories;
using POS.Domain.Entities;

namespace POS.Infrastructure.DAL.Repositories;

public class SaleTransactionRepository : ISaleTransactionRepository
{
    private readonly POSDbContext _posDbContext;

    public SaleTransactionRepository(POSDbContext posDbContext)
    {
        _posDbContext = posDbContext;
    }

    public async Task<SaleTransactionDto> CreateSaleTransaction(SaleTransaction saleTransaction)
    {
        var result = await _posDbContext.SaleTransactions.AddAsync(saleTransaction);
        await _posDbContext.SaveChangesAsync();
        return SaleTransactionDto.Parse(result.Entity);
    }
}
