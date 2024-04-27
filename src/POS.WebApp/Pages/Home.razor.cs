using Microsoft.AspNetCore.Components;
using POS.WebApp.Models;

namespace POS.WebApp.Pages;

public partial class Home
{
    [Parameter]
    public bool IsShowProducts { get; set; } = false;

    public Category Category { get; set; }

    public void HandleShowProductsAsync(Category category)
    {
        Category = category;
    }
}
