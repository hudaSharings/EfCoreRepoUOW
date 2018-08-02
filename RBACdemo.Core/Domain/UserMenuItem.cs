using System.ComponentModel.DataAnnotations.Schema;

namespace RBACdemo.Core.Domain
{
    public class UserMenuItem : BaseEntityModel
    {   
        //public int UserId { get; set; }
        public ApplicationUser User { get; set; }
       
        //public long MenuItemNo { get; set; }
        [ForeignKey("MenuItemNo")]
        public MenuItem MenuItem { get; set; }
    }


}
