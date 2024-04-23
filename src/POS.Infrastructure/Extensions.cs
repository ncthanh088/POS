using POS.Application.Data;
using POS.Application.Repositories;
using POS.Infrastructure.DAL;
using POS.Infrastructure.Auth;
using POS.Infrastructure.Time;
using POS.Infrastructure.Logging;
using POS.Infrastructure.Security;
using POS.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using POS.Application.Utility;
using POS.Infrastructure.Utility;

namespace POS.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddControllers();
            services.Configure<AppOptions>(configuration.GetRequiredSection("app"));
            services.AddSingleton<ExceptionMiddleware>();
            services.AddTime();
            // TODO: create and switch-cate to swap the Database test with production.
            // services.AddPostgres(configuration);
            services.AddSQLites(configuration);
            services.AddScoped<IDataGenerator, DataGenerator>();
            services.AddScoped<ICategoriesRepository, CategoriesRepository>();
            services.AddScoped<IPosUtility, PosUtility>();
            services.AddSecurity();
            services.AddAuth(configuration);
            services.AddHttpContextAccessor();
            services.AddLoggingHandler();

            return services;
        }

        public static WebApplication UseInfrastructure(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var dataGenerator = scope.ServiceProvider.GetRequiredService<IDataGenerator>();
                dataGenerator.Initialize();
            }
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();

            return app;
        }
    }
}
