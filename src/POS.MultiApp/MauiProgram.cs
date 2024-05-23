// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Reflection;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using POS.MultiApp.Auth;
using POS.MultiApp.Helpers;
using POS.MultiApp.LocalStorage;
using POS.MultiApp.Services;
using POS.MultiApp.Services.Abstractions;

namespace POS.MultiApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        // Init Config
        var _assambly = Assembly.GetExecutingAssembly();
        using var stream = _assambly.GetManifestResourceStream("POS.MultiApp.appsettings.json");
        var config = new ConfigurationBuilder().AddJsonStream(stream).Build();
        builder.Configuration.AddConfiguration(config);
        var configuration = builder.Configuration;
        var baseUrl = configuration.GetValue<string>("ApiSettings:BaseUrl") ?? "https://example.com";
        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseUrl) });

        // Add auth
        builder.Services.AddAuthorizationCore();
        builder.Services.AddScoped<CustomAuthStateProvider>();
        builder.Services.AddScoped<AuthenticationStateProvider>(s => s.GetRequiredService<CustomAuthStateProvider>());

        // Add project services
        builder.Services.AddMauiBlazorWebView();
        builder.Services.AddScoped<AppState>();
        builder.Services.AddScoped<Utility>();
        builder.Services.AddScoped<ILocalStorage, LocalStorage.LocalStorage>();
        builder.Services.AddScoped<IItemService, ItemService>();
        builder.Services.AddScoped<ICategoriesService, CategoriesService>();
        builder.Services.AddScoped<ICartService, CartService>();
        builder.Services.AddScoped<IAuthService, AuthService>();
        builder.Services.AddScoped<IPaymentService, PaymentService>();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
