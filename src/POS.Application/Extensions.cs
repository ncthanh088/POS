using MediatR;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using POS.Application.Services;

namespace POS.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IOrderService, OrderService>();
        services.AddMediatR(Assembly.GetExecutingAssembly());

        return services;
    }
}
