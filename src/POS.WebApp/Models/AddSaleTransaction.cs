using POS.WebApp.Models.Auth;

namespace POS.WebApp.Models;

public class AddSaleTransaction : BaseAuthorizedModel
{
    public string TransactionType { get; set; } = "Sale";
}
