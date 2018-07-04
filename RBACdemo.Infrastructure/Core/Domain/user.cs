using System.Collections.Generic;

namespace RBACdemo.Infrastructure.Core.Domain
{
    #region  Entity Models
    public class User : BaseEntityModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<UserMenuItem> UserMenuItems { get; set; }
    }
    #endregion

}
