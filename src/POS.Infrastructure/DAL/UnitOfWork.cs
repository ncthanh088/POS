using POS.Domain.DAL;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace POS.Infrastructure.DAL;

internal sealed class UnitOfWork<TResponse> : IUnitOfWork<TResponse>
{
    private readonly POSDbContext _dbContext;
    private readonly ILogger<UnitOfWork<TResponse>> _logger;


    public UnitOfWork(POSDbContext dbContext, ILogger<UnitOfWork<TResponse>> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task<TResponse> ExecuteAsync(Func<Task<TResponse>> handler)
    {
        try
        {
            using (var transaction = new TransactionScope())
            {
                var response = await handler();

                await _dbContext.SaveChangesAsync();

                transaction.Complete();

                return response;
            }

        }
        catch (Exception ex)
        {
            _logger.LogTrace(message: $"Database exception: {0}", ex);
            throw;
        }
    }
}
