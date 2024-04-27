using POS.WebApp.Models;
using POS.WebApp.Services;
using Microsoft.AspNetCore.Components;

namespace POS.WebApp.Components;

public partial class InputCounter
{
    private int counter = 0;

    [Parameter]
    public Product Product { get; set; }

    [Parameter]
    public EventCallback<string> OnClick { get; set; }

    private void IncrementCounter()
    {
        if (CanIncrement())
        {
            counter++;
        }
    }

    private void DecrementCounter()
    {
        if (counter == 0)
        {
            return;
        }
        counter--;
    }

    private bool CanIncrement()
    {
        return Product.Quantity > counter;
    }
}
