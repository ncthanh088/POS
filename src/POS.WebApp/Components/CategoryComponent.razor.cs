using Microsoft.AspNetCore.Components;
using POS.WebApp.Models;
using POS.WebApp.Services;

namespace POS.WebApp.Components;

public partial class CategoryComponent
{
    public IEnumerable<Category> Categories { get; set; }

    [Inject]
    public ICategoriesService CategoriesService { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Categories = await CategoriesService.GetCategoriesAsync();
    }
}
