using MediatR;
using POS.Domain.DAL;

namespace POS.Infrastructure.DAL.Decorators;

internal sealed class UnitOfWorkHandlerDecorator<TRequest, TResponse>
    : IRequestHandler<TRequest, TResponse> where TRequest : class, IRequest<TResponse>
{
    private readonly IRequestHandler<TRequest, TResponse> _handler;
    private readonly IUnitOfWork<TResponse> _unitOfWork;

    public UnitOfWorkHandlerDecorator(IRequestHandler<TRequest, TResponse> handler, IUnitOfWork<TResponse> unitOfWork)
    {
        _handler = handler;
        _unitOfWork = unitOfWork;
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.ExecuteAsync(() => _handler.Handle(request, cancellationToken));
    }
}
