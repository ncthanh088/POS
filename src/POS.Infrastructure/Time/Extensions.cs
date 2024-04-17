using Microsoft.Extensions.DependencyInjection;
using POS.Domain.Time;

namespace POS.Infrastructure.Time
{
    public static class Extensions
    {
        public static IServiceCollection AddTime(this IServiceCollection services)
        {
            services.AddSingleton<IClock, Clock>();

            return services;
        }
    }
}
