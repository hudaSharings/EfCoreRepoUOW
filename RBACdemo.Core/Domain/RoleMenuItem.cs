

namespace RBACdemo.Core.Domain
{
   public class RoleMenuItem : BaseEntityModel
    {
        public string RoleId { get; set; }
        public ApplicationRole Role { get; set; }

        public long MenuItemNo { get; set; }       
        public MenuItem MenuItem { get; set; }
    }
}
