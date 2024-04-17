using Microsoft.AspNetCore.Components;
using POS.WebApp.Services;

namespace POS.WebApp.Pages;

public partial class Home
{
    [Inject]
    public IProductService ProductService { get; set; }

    [Parameter]
    public IEnumerable<Product> Products { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Products = await ProductService.GetProductsAsync();
    }
}
