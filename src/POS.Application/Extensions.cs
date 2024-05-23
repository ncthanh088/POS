using MediatR;
using POS.Application.Services;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace POS.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IPaymentService, PaymentService>();
        services.AddMediatR(Assembly.GetExecutingAssembly());

        return services;
    }
}
