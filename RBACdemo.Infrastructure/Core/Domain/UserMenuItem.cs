namespace RBACdemo.Infrastructure.Core.Domain
{
    public class UserMenuItem : BaseEntityModel
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int MenuItemId { get; set; }
        public MenuItem MenuItem { get; set; }
    }


}
