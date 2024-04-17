namespace POS.Domain.DAL;

public interface IUnitOfWork<TResponse>
{
    Task<TResponse> ExecuteAsync(Func<Task<TResponse>> action);
}
