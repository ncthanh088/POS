using POS.Domain.Entities;
using POS.Application.Repositories;
using Microsoft.EntityFrameworkCore;

namespace POS.Infrastructure.DAL.Repositories;

public class TaxRepository : ITaxRepository
{
    private readonly POSDbContext _dbContext;

    public TaxRepository(POSDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Tax>> GetTaxesAsync()
    {
        return await _dbContext.Taxes.ToListAsync();
    }
}
