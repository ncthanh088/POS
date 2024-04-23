using Microsoft.AspNetCore.Components;
using POS.WebApp.Models;
using POS.WebApp.Services;

namespace POS.WebApp.Pages;

public partial class Home
{
    [Inject]
    public IProductService ProductService { get; set; }

    [Inject]
    public ICategoriesService CategoriesService { get; set; }

    [Parameter]
    public IEnumerable<Product> Products { get; set; }
    public IEnumerable<Category> Categories { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Categories = await CategoriesService.GetCategoriesAsync();
    }
}
