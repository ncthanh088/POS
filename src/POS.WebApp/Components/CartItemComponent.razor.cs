using Microsoft.AspNetCore.Components;
using POS.WebApp.Models;

namespace POS.WebApp.Components;

public partial class CartItemComponent
{
    [Parameter]
    public Item Item { get; set; }

    [Parameter]
    public int ItemIndex { get; set; }
}
