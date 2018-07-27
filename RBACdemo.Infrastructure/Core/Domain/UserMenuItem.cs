using System.ComponentModel.DataAnnotations.Schema;

namespace RBACdemo.Infrastructure.Core.Domain
{
    public class UserMenuItem : BaseEntityModel
    {   
        public int UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int MenuItemId { get; set; }
        public MenuItem MenuItem { get; set; }
    }


}
