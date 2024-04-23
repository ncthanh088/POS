using Microsoft.AspNetCore.Components;

namespace POS.WebApp.Layout;

public partial class NavMenu
{
    [Parameter]
    public IEnumerable<string> MenuItems { get; set; }

    protected override void OnInitialized()
    {
        MenuItems = ["Menu", "Reservation", "Chat", "Dashboard", "Accounting", "Settings"];
    }
}
