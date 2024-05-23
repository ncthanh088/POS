namespace POS.MultiApp.Models.Auth
{
    public class BaseAuthorizedModel
    {
        public int UserId { get; set; }
        public int? MemberId { get; set; }
        public UserInfo User { get; set; }
    }
}
