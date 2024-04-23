using POS.WebApp;
using POS.WebApp.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazr.RenderState.WASM;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.AddBlazrRenderStateWASMServices();

var configuration = builder.Configuration;
var baseUrl = configuration.GetValue<string>("ApiSettings:BaseUrl") ?? "https://example.com"; // throw exception if  config not yet setup
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseUrl) });
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoriesService, CategoriesService>();

await builder.Build().RunAsync();
