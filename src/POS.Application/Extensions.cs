using MediatR;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace POS.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());

        return services;
    }
}
