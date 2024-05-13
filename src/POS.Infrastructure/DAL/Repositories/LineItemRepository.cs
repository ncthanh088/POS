using POS.Domain.Entities;
using POS.Application.Repositories;

namespace POS.Infrastructure.DAL.Repositories;

public class LineItemRepository : ILineItemRepository
{
    private readonly POSDbContext _dbContext;

    public LineItemRepository(POSDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CreateSaleLineItemAsync(SaleLineItem saleLineItem)
    {
        await _dbContext.SaleLineItems.AddAsync(saleLineItem);
    }

    public async Task CreateTaxLineItemAsync(TaxLineItem taxLineItem)
    {
        await _dbContext.TaxLineItems.AddAsync(taxLineItem);
    }

    public async Task CreateTenderLineItemAsync(TenderLineItem tenderLineItem)
    {
        await _dbContext.TenderLineItems.AddAsync(tenderLineItem);
    }
}
