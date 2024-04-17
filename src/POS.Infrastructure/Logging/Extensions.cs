using MediatR;
using Microsoft.Extensions.DependencyInjection;
using POS.Infrastructure.Logging.Decorators;

namespace POS.Infrastructure.Logging
{
    public static class Extensions
    {
        public static IServiceCollection AddLoggingHandler(this IServiceCollection services)
        {
            // Try to log all the queries.
            services.TryDecorate(typeof(IRequestHandler<,>), typeof(LoggingHandlerDecorator<,>));

            return services;
        }
    }
}
