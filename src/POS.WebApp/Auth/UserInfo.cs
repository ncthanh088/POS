namespace POS.WebApp.Models.Auth;

public class UserInfo
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName { get; set; }
    public string Role { get; set; }
    public string Status { get; set; }
}
