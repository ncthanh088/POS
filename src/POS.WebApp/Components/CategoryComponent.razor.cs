using Microsoft.AspNetCore.Components;
using POS.WebApp.Models;
using POS.WebApp.Services;

namespace POS.WebApp.Components;

public partial class CategoryComponent
{
    public IEnumerable<Category> Categories { get; set; }

    [Inject]
    public ICategoriesService CategoriesService { get; set; }

    [Parameter]
    public EventCallback<Category> OnCategorySelected { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Categories = await CategoriesService.GetCategoriesAsync();
    }

    public async Task GetProductByCategoryAsync(Category category)
    {
        await OnCategorySelected.InvokeAsync(category);
    }
}
