using Humanizer;
using MediatR;
using Microsoft.Extensions.Logging;

namespace POS.Infrastructure.Logging.Decorators;

internal sealed class LoggingHandlerDecorator<TRequest, TResponse>
    : IRequestHandler<TRequest, TResponse> where TRequest : class, IRequest<TResponse>
{
    private readonly IRequestHandler<TRequest, TResponse> _handler;
    private readonly ILogger<LoggingHandlerDecorator<TRequest, TResponse>> _logger;

    public LoggingHandlerDecorator(IRequestHandler<TRequest, TResponse> handler,
        ILogger<LoggingHandlerDecorator<TRequest, TResponse>> logger)
    {
        _handler = handler;
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name.Underscore();

        _logger.LogInformation("Begin handling: {RequestName}...", requestName);
        var response = await _handler.Handle(request, cancellationToken);
        _logger.LogInformation("End handling: {RequestName}.", requestName);

        return response;
    }
}
