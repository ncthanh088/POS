using POS.MultiApp.Models.Auth;

namespace POS.MultiApp.Models;

public class AddSaleTransaction : BaseAuthorizedModel
{
    public string TransactionType { get; set; } = "Sale";
}
