using Microsoft.Extensions.DependencyInjection;
using POS.Domain.Services;

namespace POS.Domain;

public static class Extensions
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        services.AddScoped<IOrderService, OrderService>();

        return services;
    }
}
