using Microsoft.Extensions.Logging;
using POS.Domain.DAL;

namespace POS.Infrastructure.DAL;

internal sealed class PostgresUnitOfWork<TResponse> : IUnitOfWork<TResponse>
{
    private readonly POSDbContext _dbContext;
    private readonly ILogger<PostgresUnitOfWork<TResponse>> _logger;


    public PostgresUnitOfWork(POSDbContext dbContext,
        ILogger<PostgresUnitOfWork<TResponse>> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task<TResponse> ExecuteAsync(Func<Task<TResponse>> handler)
    {
        await using var transaction = await _dbContext.Database.BeginTransactionAsync();
        try
        {
            var response = await handler();
            await _dbContext.SaveChangesAsync();
            await transaction.CommitAsync();

            return response;
        }
        catch (Exception ex)
        {
            _logger.LogTrace(message: $"Database exception: {0}", ex);
            await transaction.RollbackAsync();
            throw;
        }
    }
}
