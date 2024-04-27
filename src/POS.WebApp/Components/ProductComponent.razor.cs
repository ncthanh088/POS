using POS.WebApp.Models;
using POS.WebApp.Services;
using Microsoft.AspNetCore.Components;

namespace POS.WebApp.Components;

public partial class ProductComponent
{
    private int counter = 0;

    [Parameter]
    public Category Category { get; set; }

    [Parameter]
    public IEnumerable<Product> Products { get; set; }

    [Inject]
    public IProductService ProductService { get; set; }

    [Parameter]
    public EventCallback<string> OnClick { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Products = await ProductService.GetProductsByCategoryIdAsync(Category.Id);
    }

    protected override async Task OnParametersSetAsync()
    {
        Products = await ProductService.GetProductsByCategoryIdAsync(Category.Id);
        StateHasChanged();
    }

    private void IncrementCounter()
    {
        counter++;
    }

    private void DecrementCounter()
    {
        if (counter == 0)
        {
            return;
        }
        counter--;
    }
}
